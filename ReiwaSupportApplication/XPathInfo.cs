using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReiwaSupportApplication
{
    public partial class XPathInfo : Form
    {
        private XPathData xPathData = new XPathData();
        private string filePath = @"C:\Users\Yuki\Documents\tmp\test.json";
        private string cpFilePath = @"C:\Users\Yuki\Documents\tmp\test_{0}.json";
        internal XPathData GetXPathData()
        {
            return xPathData;
        }

        private enum EdataGridViewXPathCol 
        {
            DISPLAY_ITEM = 0,
            ITEM= 1,
            ID= 2,
            DisplayXPath = 3
        }


        public XPathInfo()
        {
            InitializeComponent();
        }

        private void XPathInfo_Load(object sender, EventArgs e)
        {
            ReadXPathJson();
            InitDataGridView();
            InitControllForIntoRegistPanel();
        }
        private void InitDataGridView()
        {
            this.dataGridViewXPath.EditMode = DataGridViewEditMode.EditOnEnter;
            if (xPathData == null || xPathData.XPathJsonItem.Count() <= 0) { return; }
            this.dataGridViewXPath.DataSource = null;
            this.dataGridViewXPath.DataSource = xPathData.XPathJsonItem;
            this.dataGridViewXPath.Columns[(int)EdataGridViewXPathCol.DisplayXPath].Width = 430;
        }
        private void InitControllForIntoRegistPanel()
        {
            // jsonファイルに登録されているItemを入れる
            if(xPathData == null) { return ; }

            var jsonItemList = new JsonItemList();
            foreach (var itemName in xPathData.XPathJsonItem.Select(x => x.ItemName).Distinct().ToArray())
            {
                var jsonItem = xPathData.XPathJsonItem.Where(x => x.ItemName == itemName).Distinct().FirstOrDefault();
                if (jsonItem == null) { continue; }
                jsonItemList.Add(new XPathJsonItem { ItemName = jsonItem.ItemName, DisplayName = jsonItem.DisplayName });
            }
            this.comboBoxDisplayName.DataSource = jsonItemList;
            this.comboBoxDisplayName.DisplayMember = "DisplayName";
            this.comboBoxDisplayName.ValueMember = "ItemName";
        }
        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (!ValidateXPathInfo()) { return; }
            // jsonに登録する
            if (RegistXPathInfo())
            {
                MessageBox.Show("登録しました");
            }
            else
            {
                MessageBox.Show("登録に失敗しました。");
            }
            // DGVの再表示
            InitDataGridView();
        }
        private bool RegistXPathInfo(bool bufJsonFile = true)
        {
            var displayName = this.comboBoxDisplayName.Text;
            var itemName = this.textBoxItemName.Text;
            var xpath = this.textBoxXPath.Text;
            var idNo = 1;
            var orgXPathData = xPathData.Copy();

            try
            {
                if (bufJsonFile) 
                {
                    BufferJsonFile();
                }
                using (var sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // itemNameから既存データを取得
                    // 既存のデータをマージした情報を作成
                    var targetJsonObject = new XPathJsonItem();
                    if (IsNewJsonFile())
                    {
                        // まったくの新規
                        xPathData = new XPathData
                        {
                            XPathJsonItem = new List<XPathJsonItem>
                            {
                                new XPathJsonItem
                                {
                                    ItemName = itemName,
                                    DisplayName = displayName,
                                    XPath = xpath,
                                    ID = idNo
                                }
                            }
                        };
                    }
                    else
                    {
                        var idList = xPathData.XPathJsonItem.OrderByDescending(o => o.ID).Select(x => x.ID).First();

                        // オブジェクトが存在しない場合は、オブジェクトを追加する
                        xPathData.XPathJsonItem.Add(
                            new XPathJsonItem
                            {
                                ItemName = itemName,
                                DisplayName = displayName,
                                XPath = xpath,
                                ID = idList + 1
                            }
                        ); ;
                    }
                    var jsonData = JsonConvert.SerializeObject(xPathData);
                    // JSON データをファイルに書き込み
                    sw.Write(jsonData);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool BufferJsonFile()
        {
            try
            {
                var copyFilePath = string.Format(cpFilePath, ($"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}"));
                File.Copy(filePath, copyFilePath);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // dgvの選択してるidを取得
                var selectedRowIdx = this.dataGridViewXPath.SelectedCells[0].RowIndex;
                var idVal = this.dataGridViewXPath[EdataGridViewXPathCol.ID.ToString(), selectedRowIdx].Value;
                var res = int.TryParse(idVal.ToString(), out int id);
                if (!res)
                {
                    throw new Exception("IDの値が不正です。");
                }
                if (DeleteXPathIndo(id))
                {
                    MessageBox.Show($"削除しました。id: {id}");
                    ReadXPathJson();
                    InitDataGridView();
                }
                else
                {
                    MessageBox.Show($"削除に失敗しました。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool DeleteXPathIndo(int id, bool bufJsonFile = true)
        {
            try
            {
                if (bufJsonFile)
                {
                    BufferJsonFile();

                }
                // jsonファイルに上書き
                using (var sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // idから対象の行を抜き取った物を取得
                    var removedDelValInfo = this.xPathData.XPathJsonItem.Where(x => x.ID != id).OrderBy(x => x.ID);
                    var removedXPathData = new XPathData();
                    removedXPathData.XPathJsonItem = removedDelValInfo.ToList<XPathJsonItem>();
                    var jsonData = JsonConvert.SerializeObject(removedXPathData);
                    // JSON データをファイルに書き込み
                    sw.Write(jsonData);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private bool IsNewJsonFile()
        {
            return xPathData == null;
        }
        private bool IsNewObjectJson(string itemName)
        {
            if (IsNewJsonFile()) { return false; }
            return xPathData.XPathJsonItem.Where(x => itemName.Equals(x.ItemName)).Count() <= 0;
        }
        private bool ValidateXPathInfo()
        {
            var valid = true;
            var itemName = this.comboBoxDisplayName.Text;
            var xpath = this.textBoxXPath.Text;

            // 入力値チェック
            if (string.IsNullOrEmpty(this.comboBoxDisplayName.Text))
            {
                valid = false;
            }
            if (string.IsNullOrEmpty(this.textBoxXPath.Text))
            {
                valid = false;
            }
            // 一意制約チェック
            // 既存データがない場合はtrueを返す。
            if (IsEmptyXPathData()) { return valid; }

            foreach(var item in xPathData.XPathJsonItem.Where(x => itemName.Equals(x.ItemName)))
            {
                if(item.XPath.Where(xp => xpath.Equals(xp)).Count() > 0){
                    valid = false;
                    MessageBox.Show("すでに登録されています。");
                    break;
                } 
            }
            return valid;
        }
        private bool IsEmptyXPathData()
        {
            return (xPathData == null || xPathData.XPathJsonItem.Count <= 0);
        }
        internal void ReadXPathJson()
        {
            using (var sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                // 変数 jsonData にファイルの内容を代入 
                var readJsonData = sr.ReadToEnd();

                // デシリアライズして person にセット
                xPathData = JsonConvert.DeserializeObject<XPathData>(readJsonData);
            }
        }

        private void comboBoxDisplayName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItemName = ((XPathJsonItem)comboBoxDisplayName.SelectedItem).ItemName;
            this.textBoxItemName.Text = selectedItemName;
        }

    }
    [JsonObject("XPathJsonItem")]
    public class XPathJsonItem
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }
        [JsonProperty("ItemName")]
        public string ItemName { get; set; }
        [JsonProperty("XPath ID")]
        public int ID { get; set; }
        [JsonProperty("XPath")]
        public string XPath { get; set; }
    }
    public class XPathData
    {
        [JsonProperty("XPathJsonItem")]
        public List<XPathJsonItem> XPathJsonItem { get; set; }
    }
    internal class JsonItemList : List<XPathJsonItem>
    {
        internal string DisplayName { get; set; }
        internal string ItemName { get; set; }
    }
}
