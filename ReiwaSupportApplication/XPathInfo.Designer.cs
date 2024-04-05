namespace ReiwaSupportApplication
{
    partial class XPathInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewXPath = new System.Windows.Forms.DataGridView();
            this.comboBoxDisplayName = new System.Windows.Forms.ComboBox();
            this.textBoxXPath = new System.Windows.Forms.TextBox();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXPath)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewXPath
            // 
            this.dataGridViewXPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewXPath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewXPath.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewXPath.Name = "dataGridViewXPath";
            this.dataGridViewXPath.ReadOnly = true;
            this.dataGridViewXPath.RowTemplate.Height = 21;
            this.dataGridViewXPath.Size = new System.Drawing.Size(776, 386);
            this.dataGridViewXPath.TabIndex = 1;
            // 
            // comboBoxDisplayName
            // 
            this.comboBoxDisplayName.FormattingEnabled = true;
            this.comboBoxDisplayName.Location = new System.Drawing.Point(12, 414);
            this.comboBoxDisplayName.Name = "comboBoxDisplayName";
            this.comboBoxDisplayName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDisplayName.TabIndex = 4;
            this.comboBoxDisplayName.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisplayName_SelectedIndexChanged);
            // 
            // textBoxXPath
            // 
            this.textBoxXPath.Location = new System.Drawing.Point(247, 415);
            this.textBoxXPath.Name = "textBoxXPath";
            this.textBoxXPath.Size = new System.Drawing.Size(371, 19);
            this.textBoxXPath.TabIndex = 3;
            // 
            // buttonRegist
            // 
            this.buttonRegist.Location = new System.Drawing.Point(624, 413);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(75, 23);
            this.buttonRegist.TabIndex = 4;
            this.buttonRegist.Text = "登録";
            this.buttonRegist.UseVisualStyleBackColor = true;
            this.buttonRegist.Click += new System.EventHandler(this.buttonRegist_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(139, 414);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(102, 19);
            this.textBoxItemName.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(713, 412);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // XPathInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonRegist);
            this.Controls.Add(this.textBoxXPath);
            this.Controls.Add(this.comboBoxDisplayName);
            this.Controls.Add(this.dataGridViewXPath);
            this.Name = "XPathInfo";
            this.Text = "XPath登録画面";
            this.Load += new System.EventHandler(this.XPathInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewXPath;
        private System.Windows.Forms.ComboBox comboBoxDisplayName;
        private System.Windows.Forms.TextBox textBoxXPath;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Button buttonDelete;
    }
}