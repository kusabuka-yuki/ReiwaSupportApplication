namespace ReiwaSupportApplication
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSelectExcelRow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOccupEtc = new System.Windows.Forms.RadioButton();
            this.radioOccupPassenger = new System.Windows.Forms.RadioButton();
            this.radioOccupTransportation = new System.Windows.Forms.RadioButton();
            this.radioOccupManufacturing = new System.Windows.Forms.RadioButton();
            this.radioOccupConstruction = new System.Windows.Forms.RadioButton();
            this.TemplateTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonCreateTemplate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelSupplyName = new System.Windows.Forms.Label();
            this.labelExcelRowIdx = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.labelInquiryUrl = new System.Windows.Forms.LinkLabel();
            this.checkLinkAutoOpen = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonContentType = new System.Windows.Forms.RadioButton();
            this.radioButtonWithoutURL = new System.Windows.Forms.RadioButton();
            this.radioButtonUnder500WithoutURL = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "エクセルの行番号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "取引先名：";
            // 
            // textBoxSelectExcelRow
            // 
            this.textBoxSelectExcelRow.Location = new System.Drawing.Point(243, 78);
            this.textBoxSelectExcelRow.Name = "textBoxSelectExcelRow";
            this.textBoxSelectExcelRow.Size = new System.Drawing.Size(72, 19);
            this.textBoxSelectExcelRow.TabIndex = 3;
            this.textBoxSelectExcelRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSelectExcelRow_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "開始行番号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioOccupEtc);
            this.groupBox1.Controls.Add(this.radioOccupPassenger);
            this.groupBox1.Controls.Add(this.radioOccupTransportation);
            this.groupBox1.Controls.Add(this.radioOccupManufacturing);
            this.groupBox1.Controls.Add(this.radioOccupConstruction);
            this.groupBox1.Location = new System.Drawing.Point(21, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "職種選択";
            // 
            // radioOccupEtc
            // 
            this.radioOccupEtc.AutoSize = true;
            this.radioOccupEtc.Location = new System.Drawing.Point(267, 34);
            this.radioOccupEtc.Name = "radioOccupEtc";
            this.radioOccupEtc.Size = new System.Drawing.Size(54, 16);
            this.radioOccupEtc.TabIndex = 1;
            this.radioOccupEtc.Text = "その他";
            this.radioOccupEtc.UseVisualStyleBackColor = true;
            // 
            // radioOccupPassenger
            // 
            this.radioOccupPassenger.AutoSize = true;
            this.radioOccupPassenger.Location = new System.Drawing.Point(209, 34);
            this.radioOccupPassenger.Name = "radioOccupPassenger";
            this.radioOccupPassenger.Size = new System.Drawing.Size(47, 16);
            this.radioOccupPassenger.TabIndex = 1;
            this.radioOccupPassenger.Text = "旅客";
            this.radioOccupPassenger.UseVisualStyleBackColor = true;
            // 
            // radioOccupTransportation
            // 
            this.radioOccupTransportation.AutoSize = true;
            this.radioOccupTransportation.Location = new System.Drawing.Point(155, 34);
            this.radioOccupTransportation.Name = "radioOccupTransportation";
            this.radioOccupTransportation.Size = new System.Drawing.Size(47, 16);
            this.radioOccupTransportation.TabIndex = 1;
            this.radioOccupTransportation.Text = "運送";
            this.radioOccupTransportation.UseVisualStyleBackColor = true;
            // 
            // radioOccupManufacturing
            // 
            this.radioOccupManufacturing.AutoSize = true;
            this.radioOccupManufacturing.Location = new System.Drawing.Point(70, 34);
            this.radioOccupManufacturing.Name = "radioOccupManufacturing";
            this.radioOccupManufacturing.Size = new System.Drawing.Size(77, 16);
            this.radioOccupManufacturing.TabIndex = 1;
            this.radioOccupManufacturing.Text = "製造・機械";
            this.radioOccupManufacturing.UseVisualStyleBackColor = true;
            // 
            // radioOccupConstruction
            // 
            this.radioOccupConstruction.AutoSize = true;
            this.radioOccupConstruction.Checked = true;
            this.radioOccupConstruction.Location = new System.Drawing.Point(12, 34);
            this.radioOccupConstruction.Name = "radioOccupConstruction";
            this.radioOccupConstruction.Size = new System.Drawing.Size(47, 16);
            this.radioOccupConstruction.TabIndex = 0;
            this.radioOccupConstruction.TabStop = true;
            this.radioOccupConstruction.Text = "建設";
            this.radioOccupConstruction.UseVisualStyleBackColor = true;
            // 
            // TemplateTextBox
            // 
            this.TemplateTextBox.Location = new System.Drawing.Point(375, 204);
            this.TemplateTextBox.Name = "TemplateTextBox";
            this.TemplateTextBox.Size = new System.Drawing.Size(395, 210);
            this.TemplateTextBox.TabIndex = 7;
            this.TemplateTextBox.Text = "";
            // 
            // buttonCreateTemplate
            // 
            this.buttonCreateTemplate.Location = new System.Drawing.Point(375, 150);
            this.buttonCreateTemplate.Name = "buttonCreateTemplate";
            this.buttonCreateTemplate.Size = new System.Drawing.Size(97, 39);
            this.buttonCreateTemplate.TabIndex = 8;
            this.buttonCreateTemplate.Text = "定型文の作成";
            this.buttonCreateTemplate.UseVisualStyleBackColor = true;
            this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(21, 204);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(332, 210);
            this.dataGridView.TabIndex = 9;
            // 
            // labelSupplyName
            // 
            this.labelSupplyName.AutoSize = true;
            this.labelSupplyName.Location = new System.Drawing.Point(84, 50);
            this.labelSupplyName.Name = "labelSupplyName";
            this.labelSupplyName.Size = new System.Drawing.Size(53, 12);
            this.labelSupplyName.TabIndex = 1;
            this.labelSupplyName.Text = "取引先名";
            // 
            // labelExcelRowIdx
            // 
            this.labelExcelRowIdx.AutoSize = true;
            this.labelExcelRowIdx.Location = new System.Drawing.Point(119, 81);
            this.labelExcelRowIdx.Name = "labelExcelRowIdx";
            this.labelExcelRowIdx.Size = new System.Drawing.Size(11, 12);
            this.labelExcelRowIdx.TabIndex = 0;
            this.labelExcelRowIdx.Text = "0";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(668, 527);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(102, 39);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "次へ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "送信不可の理由";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "文字制限文字数";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(174, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 88);
            this.listBox1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "実施日";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(98, 19);
            this.textBox2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton7);
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 45);
            this.panel1.TabIndex = 15;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(88, 14);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(47, 16);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "失敗";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(12, 14);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(47, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "成功";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(513, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 39);
            this.button1.TabIndex = 16;
            this.button1.Text = "結果を保存";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(319, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 19);
            this.textBox3.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "その他理由";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(21, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 136);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "結果";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(319, 93);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(176, 39);
            this.richTextBox2.TabIndex = 19;
            this.richTextBox2.Text = "";
            // 
            // labelInquiryUrl
            // 
            this.labelInquiryUrl.AutoSize = true;
            this.labelInquiryUrl.Location = new System.Drawing.Point(19, 21);
            this.labelInquiryUrl.Name = "labelInquiryUrl";
            this.labelInquiryUrl.Size = new System.Drawing.Size(127, 12);
            this.labelInquiryUrl.TabIndex = 17;
            this.labelInquiryUrl.TabStop = true;
            this.labelInquiryUrl.Text = "お問い合わせフォームURL";
            this.labelInquiryUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelInquiryUrl_LinkClicked);
            // 
            // checkLinkAutoOpen
            // 
            this.checkLinkAutoOpen.AutoSize = true;
            this.checkLinkAutoOpen.Location = new System.Drawing.Point(673, 492);
            this.checkLinkAutoOpen.Name = "checkLinkAutoOpen";
            this.checkLinkAutoOpen.Size = new System.Drawing.Size(96, 16);
            this.checkLinkAutoOpen.TabIndex = 18;
            this.checkLinkAutoOpen.Text = "リンク自動遷移";
            this.checkLinkAutoOpen.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonUnder500WithoutURL);
            this.panel2.Controls.Add(this.radioButtonWithoutURL);
            this.panel2.Controls.Add(this.radioButtonContentType);
            this.panel2.Location = new System.Drawing.Point(506, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 46);
            this.panel2.TabIndex = 19;
            // 
            // radioButtonContentType
            // 
            this.radioButtonContentType.AutoSize = true;
            this.radioButtonContentType.Location = new System.Drawing.Point(16, 19);
            this.radioButtonContentType.Name = "radioButtonContentType";
            this.radioButtonContentType.Size = new System.Drawing.Size(47, 16);
            this.radioButtonContentType.TabIndex = 0;
            this.radioButtonContentType.TabStop = true;
            this.radioButtonContentType.Text = "通常";
            this.radioButtonContentType.UseVisualStyleBackColor = true;
            // 
            // radioButtonWithoutURL
            // 
            this.radioButtonWithoutURL.AutoSize = true;
            this.radioButtonWithoutURL.Location = new System.Drawing.Point(69, 19);
            this.radioButtonWithoutURL.Name = "radioButtonWithoutURL";
            this.radioButtonWithoutURL.Size = new System.Drawing.Size(64, 16);
            this.radioButtonWithoutURL.TabIndex = 0;
            this.radioButtonWithoutURL.TabStop = true;
            this.radioButtonWithoutURL.Text = "URLなし";
            this.radioButtonWithoutURL.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnder500WithoutURL
            // 
            this.radioButtonUnder500WithoutURL.AutoSize = true;
            this.radioButtonUnder500WithoutURL.Location = new System.Drawing.Point(139, 19);
            this.radioButtonUnder500WithoutURL.Name = "radioButtonUnder500WithoutURL";
            this.radioButtonUnder500WithoutURL.Size = new System.Drawing.Size(110, 16);
            this.radioButtonUnder500WithoutURL.TabIndex = 0;
            this.radioButtonUnder500WithoutURL.TabStop = true;
            this.radioButtonUnder500WithoutURL.Text = "500以下 URLなし";
            this.radioButtonUnder500WithoutURL.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkLinkAutoOpen);
            this.Controls.Add(this.labelInquiryUrl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonCreateTemplate);
            this.Controls.Add(this.TemplateTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSelectExcelRow);
            this.Controls.Add(this.labelSupplyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelExcelRowIdx);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSelectExcelRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioOccupEtc;
        private System.Windows.Forms.RadioButton radioOccupPassenger;
        private System.Windows.Forms.RadioButton radioOccupTransportation;
        private System.Windows.Forms.RadioButton radioOccupManufacturing;
        private System.Windows.Forms.RadioButton radioOccupConstruction;
        private System.Windows.Forms.RichTextBox TemplateTextBox;
        private System.Windows.Forms.Button buttonCreateTemplate;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelSupplyName;
        private System.Windows.Forms.Label labelExcelRowIdx;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.LinkLabel labelInquiryUrl;
        private System.Windows.Forms.CheckBox checkLinkAutoOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonUnder500WithoutURL;
        private System.Windows.Forms.RadioButton radioButtonWithoutURL;
        private System.Windows.Forms.RadioButton radioButtonContentType;
    }
}

