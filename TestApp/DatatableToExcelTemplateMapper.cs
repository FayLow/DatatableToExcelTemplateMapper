using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Properties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Util;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;
using System.Linq.Dynamic.Core;

namespace TestApp
{
    public partial class DatatableToExcelTemplateMapper : Form
    {
        public DatatableToExcelTemplateMapper()
        {
            InitializeComponent();
            dataTable = new DataTable();
            paramList = new Dictionary<string, string>();
        }

        DataTable dataTable;
        Dictionary<string, string> paramList;
        
        string directory = "C:\\DatatableToExcelTemplateMapper\\Sample Excels";
        Regex matchRowGroup = new Regex(@"^@(?<Row>.+)$");
        Regex matchParamName = new Regex(@"^{(?<Param>.+)}$");
        Regex matchColName = new Regex(@"^\[(?<Column>.+)\]$");

        private void ReadExcelToDatatable(string iDataPath)
        {
            string sConnection = string.Format("Provider=Microsoft.ACE.OLEDB.16.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"", iDataPath);
            string sSheetName = null;

            OleDbConnection oleExcelConnection = new OleDbConnection(sConnection);
            oleExcelConnection.Open();

            DataTable dtTablesList = oleExcelConnection.GetSchema("Tables");

            if (dtTablesList.Rows.Count > 0)
            {
                sSheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
            }

            dtTablesList.Clear();
            dtTablesList.Dispose();

            dataTable.Clear();
            dataTable.Dispose(); 
            dataTable = new DataTable();

            if (!string.IsNullOrEmpty(sSheetName))
            {
                OleDbCommand oleExcelCommand = oleExcelConnection.CreateCommand();
                oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                oleExcelCommand.CommandType = CommandType.Text;

                OleDbDataReader oleDbDataReader = oleExcelCommand.ExecuteReader();
                dataTable.Load(oleDbDataReader);

                foreach (DataColumn column in dataTable.Columns)
                {
                    string colName = dataTable.Rows[0][column.ColumnName].ToString();
                    if (!dataTable.Columns.Contains(colName) && colName != "")
                    {
                        column.ColumnName = colName;
                    }
                }

                dataTable.Rows[0].Delete();
                dataTable.AcceptChanges();

                dgvExtractedData.DataSource = dataTable;

                //while (oleExcelReader.Read())
                //{
                //}
                //oleExcelReader.Close();
            }
            oleExcelConnection.Close();
        }

        public String GenExcel()
        {
            String fileFullPath = null;

            try
            {
                string templatePath = txtExcelPath.Text;

                byte[] byteArray = File.ReadAllBytes(templatePath);

                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(stream, true))
                    {
                        // Do work here
                        WorkbookPart wbPart = spreadsheetDoc.WorkbookPart;
                        WorksheetPart worksheetPart = OpenXMLUtil.GetWorksheetPartByName(spreadsheetDoc, "Result");

                        if (worksheetPart != null)
                        {
                            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                            // Fill params first
                            foreach (Row r in sheetData.Elements<Row>())
                            {
                                foreach (Cell rc in r.Elements<Cell>())
                                {
                                    string text = OpenXMLUtil.ReadCell(wbPart, rc);
                                    if (matchParamName.IsMatch(text))
                                    {
                                        string param = matchParamName.Match(text).Groups["Param"].Value;

                                        if (paramList.ContainsKey(param))
                                        {
                                            rc.CellValue = new CellValue(paramList[param].ToString());
                                            rc.DataType = new EnumValue<CellValues>(CellValues.String);
                                        }
                                    }
                                }
                            }

                            // Fill iterating rows
                            Dictionary<string, TypeCode> dataTypeDict = new Dictionary<string, TypeCode>();
                            foreach (DataColumn col in dataTable.Columns)
                            {
                                if (!dataTypeDict.ContainsKey(col.ColumnName))
                                    dataTypeDict.Add(col.ColumnName, Type.GetTypeCode(col.DataType));
                            }

                            foreach (Row r in sheetData.Elements<Row>())
                            {
                                foreach (Cell rc in r.Elements<Cell>())
                                {
                                    string text = OpenXMLUtil.ReadCell(wbPart, rc);
                                    if (matchRowGroup.IsMatch(text))
                                    {
                                        string rowGroup = matchRowGroup.Match(text).Groups["Row"].Value;

                                        Dictionary<string, List<DataRow>> groupedDataRows = new Dictionary<string, List<DataRow>>();
                                        if (!dataTable.Columns.Contains(rowGroup))
                                        {
                                            groupedDataRows.Add(string.Empty, dataTable.Rows.ToDynamicList<DataRow>());
                                        }
                                        else
                                        {
                                            foreach (DataRow row in dataTable.Rows)
                                            {
                                                if (!groupedDataRows.ContainsKey(row[rowGroup].ToString()))
                                                {
                                                    groupedDataRows.Add(row[rowGroup].ToString(), new List<DataRow> { row });
                                                }
                                                else
                                                {
                                                    groupedDataRows[row[rowGroup].ToString()].Add(row);
                                                }
                                            }
                                        }

                                        foreach (var group in groupedDataRows)
                                        {
                                            foreach (DataRow row in group.Value)
                                            {
                                                Row aRow = (Row)r.Clone();
                                                foreach (Cell c in aRow.Elements<Cell>())
                                                {
                                                    text = OpenXMLUtil.ReadCell(wbPart, c);

                                                    string colName = string.Empty;

                                                    if (matchRowGroup.IsMatch(text))
                                                    {
                                                        colName = matchRowGroup.Match(text).Groups["Row"].Value;
                                                    }
                                                    else if (matchColName.IsMatch(text))
                                                    {
                                                        colName = matchColName.Match(text).Groups["Column"].Value;
                                                    }

                                                    c.DataType = new EnumValue<CellValues>(CellValues.String);
                                                    if (dataTable.Columns.Contains(colName))
                                                    {
                                                        TypeCode dataType = dataTypeDict.ContainsKey(colName) ? dataTypeDict[colName] : TypeCode.Empty;

                                                        switch (dataType)
                                                        {
                                                            case TypeCode.DateTime:
                                                                c.CellValue = new CellValue(((DateTime)row[colName]).ToString("yyyy/MM/dd"));
                                                                break;
                                                            default:
                                                                c.CellValue = new CellValue(row[colName].ToString());
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        c.CellValue = new CellValue(string.Empty);
                                                    }
                                                }
                                                OpenXMLUtil.InsertRow((uint)(r.RowIndex), worksheetPart, aRow);
                                            }
                                        }

                                        //remove the last row.
                                        OpenXMLUtil.RemoveRow(worksheetPart.Worksheet, (uint)(r.RowIndex));
                                        break;
                                    }
                                }
                            }

                            // Save the worksheet.
                            worksheetPart.Worksheet.Save();
                        }
                    }

                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    // Initialize the data context to obtain new report sequence
                    // Compose file name
                    string file = new StringBuilder()
                                      .Append(DateTime.Now.ToFileTime())
                                      .Append(".xlsx")
                                      .ToString();
                    fileFullPath = Path.Combine(directory, file);

                    File.WriteAllBytes(fileFullPath, stream.ToArray());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("PrintWorklistFail: " + e.ToString());
            }

            return fileFullPath;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Excel files(.xlsx)| *.xlsx";

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                this.txtExcelPath.Text = fileDialog.FileName;
            }
        }

        private void btnBrowseData_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Excel files(.xls;.xlsx)|*.xls;*.xlsx";

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                this.txtDataPath.Text = fileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(this.txtDataPath.Text))
            {
                ReadExcelToDatatable(txtDataPath.Text);
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                FileInfo fileInfo = new FileInfo(folderDialog.SelectedPath);

                this.txtOutputPath.Text = folderDialog.SelectedPath;
                directory = folderDialog.SelectedPath;
            }

            if (!string.IsNullOrEmpty(this.txtDataPath.Text))
            {
                ReadExcelToDatatable(txtDataPath.Text);
            }
        }
        private void btnGenExcel_Click(object sender, EventArgs e)
        {
            string path = GenExcel();
            if (!string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Print success:\n" + path);
            }
            else
            {
                MessageBox.Show("Print failed");
            }
        }

        private void btnAddParam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParamName.Text))
            {
                MessageBox.Show("Param Name cannot be empty.");
                dgvParamList.DataSource = paramList.ToList();
                return;
            }
            
            if (!paramList.ContainsKey(txtParamName.Text))
            {
                if (!string.IsNullOrEmpty(txtParamValue.Text))
                    paramList.Add(txtParamName.Text, txtParamValue.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(txtParamValue.Text))
                    paramList.Remove(txtParamName.Text);
                else
                    paramList[txtParamName.Text] = txtParamValue.Text;
            }

            txtParamName.Text = string.Empty;
            txtParamValue.Text = string.Empty;
            dgvParamList.DataSource = paramList.ToList();
        }
    }
}
