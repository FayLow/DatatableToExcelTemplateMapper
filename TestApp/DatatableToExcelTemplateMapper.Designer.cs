namespace TestApp
{
    partial class DatatableToExcelTemplateMapper
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
            this.btnBrowseTemplate = new System.Windows.Forms.Button();
            this.btnGenExcel = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.btnBrowseData = new System.Windows.Forms.Button();
            this.dgvExtractedData = new System.Windows.Forms.DataGridView();
            this.dgvParamList = new System.Windows.Forms.DataGridView();
            this.txtParamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.btnUpdateParam = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtractedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseTemplate
            // 
            this.btnBrowseTemplate.Location = new System.Drawing.Point(40, 40);
            this.btnBrowseTemplate.Name = "btnBrowseTemplate";
            this.btnBrowseTemplate.Size = new System.Drawing.Size(200, 40);
            this.btnBrowseTemplate.TabIndex = 0;
            this.btnBrowseTemplate.Text = "Browse Template";
            this.btnBrowseTemplate.UseVisualStyleBackColor = true;
            this.btnBrowseTemplate.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenExcel
            // 
            this.btnGenExcel.Location = new System.Drawing.Point(40, 220);
            this.btnGenExcel.Name = "btnGenExcel";
            this.btnGenExcel.Size = new System.Drawing.Size(200, 40);
            this.btnGenExcel.TabIndex = 1;
            this.btnGenExcel.Text = "Gen Excel";
            this.btnGenExcel.UseVisualStyleBackColor = true;
            this.btnGenExcel.Click += new System.EventHandler(this.btnGenExcel_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(250, 40);
            this.txtExcelPath.MinimumSize = new System.Drawing.Size(0, 40);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.ReadOnly = true;
            this.txtExcelPath.Size = new System.Drawing.Size(500, 40);
            this.txtExcelPath.TabIndex = 2;
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(250, 100);
            this.txtDataPath.MinimumSize = new System.Drawing.Size(0, 40);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.ReadOnly = true;
            this.txtDataPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataPath.Size = new System.Drawing.Size(500, 40);
            this.txtDataPath.TabIndex = 3;
            // 
            // btnBrowseData
            // 
            this.btnBrowseData.Location = new System.Drawing.Point(40, 100);
            this.btnBrowseData.Name = "btnBrowseData";
            this.btnBrowseData.Size = new System.Drawing.Size(200, 40);
            this.btnBrowseData.TabIndex = 4;
            this.btnBrowseData.Text = "Browse Data File";
            this.btnBrowseData.UseVisualStyleBackColor = true;
            this.btnBrowseData.Click += new System.EventHandler(this.btnBrowseData_Click);
            // 
            // dgvExtractedData
            // 
            this.dgvExtractedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtractedData.Location = new System.Drawing.Point(250, 220);
            this.dgvExtractedData.Name = "dgvExtractedData";
            this.dgvExtractedData.RowHeadersWidth = 62;
            this.dgvExtractedData.RowTemplate.Height = 28;
            this.dgvExtractedData.Size = new System.Drawing.Size(1600, 350);
            this.dgvExtractedData.TabIndex = 5;
            // 
            // dgvParamList
            // 
            this.dgvParamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamList.Location = new System.Drawing.Point(850, 600);
            this.dgvParamList.Name = "dgvParamList";
            this.dgvParamList.RowHeadersWidth = 62;
            this.dgvParamList.RowTemplate.Height = 28;
            this.dgvParamList.Size = new System.Drawing.Size(1000, 350);
            this.dgvParamList.TabIndex = 6;
            // 
            // txtParamName
            // 
            this.txtParamName.Location = new System.Drawing.Point(450, 600);
            this.txtParamName.MinimumSize = new System.Drawing.Size(4, 40);
            this.txtParamName.Name = "txtParamName";
            this.txtParamName.Size = new System.Drawing.Size(350, 26);
            this.txtParamName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 600);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Param Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 660);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Param Value";
            // 
            // txtParamValue
            // 
            this.txtParamValue.Location = new System.Drawing.Point(450, 660);
            this.txtParamValue.MinimumSize = new System.Drawing.Size(4, 40);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(350, 26);
            this.txtParamValue.TabIndex = 9;
            // 
            // btnUpdateParam
            // 
            this.btnUpdateParam.Location = new System.Drawing.Point(600, 720);
            this.btnUpdateParam.Name = "btnUpdateParam";
            this.btnUpdateParam.Size = new System.Drawing.Size(200, 40);
            this.btnUpdateParam.TabIndex = 11;
            this.btnUpdateParam.Text = "Update Param";
            this.btnUpdateParam.UseVisualStyleBackColor = true;
            this.btnUpdateParam.Click += new System.EventHandler(this.btnAddParam_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(250, 160);
            this.txtOutputPath.MinimumSize = new System.Drawing.Size(4, 40);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputPath.Size = new System.Drawing.Size(500, 40);
            this.txtOutputPath.TabIndex = 12;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(40, 160);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(200, 40);
            this.btnBrowseOutput.TabIndex = 13;
            this.btnBrowseOutput.Text = "Browse Output Folder";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // DatatableToExcelTemplateMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnUpdateParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParamValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParamName);
            this.Controls.Add(this.dgvParamList);
            this.Controls.Add(this.dgvExtractedData);
            this.Controls.Add(this.btnBrowseData);
            this.Controls.Add(this.txtDataPath);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.btnGenExcel);
            this.Controls.Add(this.btnBrowseTemplate);
            this.Name = "DatatableToExcelTemplateMapper";
            this.Text = "Datatable To Excel Template Mapper";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtractedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseTemplate;
        private System.Windows.Forms.Button btnGenExcel;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Button btnBrowseData;
        private System.Windows.Forms.DataGridView dgvExtractedData;
        private System.Windows.Forms.DataGridView dgvParamList;
        private System.Windows.Forms.TextBox txtParamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParamValue;
        private System.Windows.Forms.Button btnUpdateParam;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnBrowseOutput;
    }
}

