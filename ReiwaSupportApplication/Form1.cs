using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private enum SupplyColumn
        {
            SupplyName = 1,
            InquiryUrl = 3
        }
        public Form1()
        {
            InitializeComponent();
            fileName = GetFileName();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetDisplayLabelValue();
        }
        private void SetDisplayLabelValue()
        {
            GetSupplyExcelData();
            this.labelExcelRowIdx.Text = (this.selectExcelRowIdx + 1) .ToString();
            this.labelInquiryUrl.Text = this.supplyUrl.ToString();
            this.labelSupplyName.Text = this.supplyName.ToString();
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
        private OccupationExcelData GetOccupationExcelData(Occupation occupation)
        {
            OccupationExcelData excelData = new OccupationExcelData(occupation);
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
        }
        /// <summary>
        /// 定型文の作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTemplate_Click(object sender, EventArgs e)
        {
            // ラジオボタンの読込み
            var occupation = GetCheckedOccupRadioButton();
            // xmlの読込み
            var excelData = GetOccupationExcelData(occupation);
            // 取引先を渡す
            excelData.Supply = this.supplyName;
            SetDataGridView(excelData);

            // 定型文を出力する
            this.TemplateTextBox.Text = excelData.Content;
        }
        private Occupation GetCheckedOccupRadioButton()
        {
            Occupation occupation = Occupation.None;

            if (radioOccupConstruction.Checked)
            {
                occupation = Occupation.Construction;
            }
            else if (radioOccupManufacturing.Checked)
            {
                occupation = Occupation.Manufacturing;
            }
            else if (radioOccupTransportation.Checked)
            {
                occupation = Occupation.Transportation;
            }
            else if (radioOccupPassenger.Checked)
            {
                occupation = Occupation.Passenger;
            }
            else if (radioOccupEtc.Checked)
            {
                occupation = Occupation.Etc;
            }
            return occupation;
        }
        private void SetDataGridView(OccupationExcelData excelData)
        {
            var excelDataList = new OccupationExcelDataList(excelData);  
            this.dataGridView.DataSource = excelDataList.Data.ToList();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.selectExcelRowIdx++;
            SetDisplayLabelValue();
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

                SetDisplayLabelValue();
            }
        }

        private void labelInquiryUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = labelInquiryUrl.Text;
            //ブラウザで開く
            System.Diagnostics.Process.Start(url);
        }
    }
}
