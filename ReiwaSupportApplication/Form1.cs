using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ReiwaSupportApplication.OccupationExcelData;

namespace ReiwaSupportApplication
{
    public partial class Form1 : Form
    {
        private string fileName = string.Empty;
        private string sheetName = "シート1";
        private int selectExcelRowIdx = 2;
        private string supplyName = string.Empty;
        private string supplyUrl = string.Empty;
        private EOccupation occupation = EOccupation.None;

        private enum SupplyColumn
        {
            SupplyName = 1,
            InquiryUrl = 3,
            Occupation = 10,
        }
        public Form1()
        {
            InitializeComponent();
            fileName = GetFileName();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetDisplayValue();
        }
        private void SetDisplayValue()
        {
            this.occupation = EOccupation.None;
            GetSupplyExcelData();
            this.labelExcelRowIdx.Text = (this.selectExcelRowIdx + 1) .ToString();
            this.labelInquiryUrl.Text = this.supplyUrl;
            this.labelSupplyName.Text = this.supplyName;
            this.radioButtonContentType.Checked = true;
            this.radioButtonWithoutURL.Checked = false;
            this.radioButtonUnder500WithoutURL.Checked = false;
        }
        private string GetFileName()
        {
            //DateTime dt = DateTime.Now;
            //string result = dt.ToString("yyyy_MM_dd");

            string result = string.Empty;
            var fileName = @"G:\マイドライブ\ドライブ\クラウドワークス\Reiwa\【6周目】240226　全国　端数 2" + result +  ".xlsx";
            return fileName;
        }
        /// <summary>
        /// xmlを読み込む
        /// </summary>
        /// <param name="occupation"></param>
        private OccupationExcelData GetOccupationExcelData(EOccupation occupation, EContentType contentType)
        {
            OccupationExcelData excelData = new OccupationExcelData(occupation, contentType);
            return excelData;
        }
        /// <summary>
        /// 取引先情報を読み込む
        /// </summary>
        /// <returns></returns>
        private void GetSupplyExcelData()
        {
            Excel excel = new Excel(fileName, sheetName);
            var sheet = excel.Book.GetSheet(sheetName);
            var cell = sheet.GetRow(this.selectExcelRowIdx);
            this.supplyName =  cell.GetCell((int)SupplyColumn.SupplyName).StringCellValue;
            this.supplyUrl = cell.GetCell((int)SupplyColumn.InquiryUrl).StringCellValue;
            if (cell.GetCell((int)SupplyColumn.Occupation) != null)
            {
                var occupationTypeName = cell.GetCell((int)SupplyColumn.Occupation).StringCellValue;
                this.occupation = GetEOccupationByOcuupationTypeName(occupationTypeName);
            }
        }
        private EOccupation GetEOccupationByOcuupationTypeName(string occupationTypeName)
        {
            var occupation = EOccupation.None;

            if(occupationTypeName == "製造")
            {
                occupation = EOccupation.Manufacturing;
            }
            if (occupationTypeName == "建設")
            {
                occupation = EOccupation.Construction;
            }
            if (occupationTypeName == "運送")
            {
                occupation = EOccupation.Transportation;
            }
            if (occupationTypeName == "旅客")
            {
                occupation = EOccupation.Passenger;
            }
            if (occupationTypeName == "その他")
            {
                occupation = EOccupation.Etc;
            }
            return occupation;
        }
        /// <summary>
        /// 定型文の作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTemplate_Click(object sender, EventArgs e)
        {
            // ラジオボタンの読込み
            //var occupation = GetCheckedOccupRadioButton();
            var contentType = GetContentType();
            // xmlの読込み
            var excelData = GetOccupationExcelData(occupation, contentType);
            // 取引先を渡す
            excelData.Supply = this.supplyName;
            SetDataGridView(excelData);

            // 定型文を出力する
            this.TemplateTextBox.Text = excelData.Content;
        }
        private EOccupation GetCheckedOccupRadioButton()
        {
            EOccupation occupation = EOccupation.None;

            if (radioOccupConstruction.Checked)
            {
                occupation = EOccupation.Construction;
            }
            else if (radioOccupManufacturing.Checked)
            {
                occupation = EOccupation.Manufacturing;
            }
            else if (radioOccupTransportation.Checked)
            {
                occupation = EOccupation.Transportation;
            }
            else if (radioOccupPassenger.Checked)
            {
                occupation = EOccupation.Passenger;
            }
            else if (radioOccupEtc.Checked)
            {
                occupation = EOccupation.Etc;
            }
            return occupation;
        }
        private EContentType GetContentType()
        {
            var contentType = EContentType.Content;

            if (radioButtonWithoutURL.Checked)
            {
                contentType = EContentType.ContentWithoutURL;
            }
            else if (radioButtonUnder500WithoutURL.Checked)
            {
                contentType = EContentType.ContentUnder500WithoutURL;
            }
            return contentType;
        }
        private void SetDataGridView(OccupationExcelData excelData)
        {
            var excelDataList = new OccupationExcelDataList(excelData);  
            this.dataGridView.DataSource = excelDataList.Data.ToList();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.selectExcelRowIdx++;
            SetDisplayValue();
            this.dataGridView.DataSource = null;
            this.TemplateTextBox.Text = string.Empty;

            // サイトURLのリンクを開く
            if (this.checkLinkAutoOpen.Checked)
            {
                OpenLinkUrl();
            }
            if (this.checkBoxEnableAuto.Checked)
            {
                CallTypedBrouserControll();
            }
        }
        private void CallTypedBrouserControll()
        {
            var contentType = GetContentType();
            // xmlの読込み
            if(occupation == EOccupation.None)
            {
                MessageBox.Show($"職種が未設定です。\n {this.supplyUrl}", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            var excelData = GetOccupationExcelData(occupation, contentType);
            var brouserContoroll = new TypingBrouserControll(excelData, new Url(this.supplyUrl));
            brouserContoroll.TypedBrouserControll();
        }


        private void textBoxSelectExcelRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int rowIdx = this.selectExcelRowIdx;
                if (this.textBoxSelectExcelRow != null)
                {
                    var text = this.textBoxSelectExcelRow.Text.Trim();
                    int.TryParse(text, out rowIdx);
                }
                if(rowIdx > 0)
                {
                    rowIdx = rowIdx - 1;
                }
                this.selectExcelRowIdx = rowIdx;

                SetDisplayValue();
            }
        }

        private void labelInquiryUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLinkUrl();
        }
        /// <summary>
        /// URLのリンクを開く
        /// </summary>
        private void OpenLinkUrl()
        {
            if (this.checkBoxEnableAuto.Checked)
            {
                CallTypedBrouserControll();
            }
            else
            {
                //ブラウザで開く
                System.Diagnostics.Process.Start(this.supplyUrl);
            }
        }

        private void checkBoxEnableAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxEnableAuto.Checked)
            {
                this.checkLinkAutoOpen.Checked = false;
                this.checkLinkAutoOpen.Enabled = false;
            }
            else
            {
                this.checkLinkAutoOpen.Enabled = true;
            }
        }
    }
}
