using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Configuration;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Text.RegularExpressions;


namespace CQL_Server
{
    public partial class frmCQLServer : Form
    {
        public frmCQLServer()
        {
            InitializeComponent();
        }

        DataTable dataTable;
        private const string CAPTION = "CQL Server 2018";
        

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Adds subkey under Databases key for each folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctxmnuAddDatabase_Click(object sender, EventArgs e)
        {
            var folder = "";
            var alias = "";
            var str = "";
            TreeNode treeNode;
            RegistryKey cqlServerKey;
            RegistryKey databasesKey;

            folderBrowserDialog1.Description = "Select folder (database) containing csv files";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder = folderBrowserDialog1.SelectedPath;
                if (IsDatabase(folder))
                {
                    MessageBox.Show("Folder has already been added to Databases", "CQL Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                alias = Microsoft.VisualBasic.Interaction.InputBox("Enter alias for folder (database)", "CQL Server");
                if (alias == string.Empty) return;

                if (IsAlias(alias))
                {
                    MessageBox.Show("Database alias already in use.", "CQL Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                AddDatabaseNode(alias, folder);
               
                //store alias and folder in Registry
                cqlServerKey = Registry.CurrentUser.OpenSubKey("CQL Server");
                if (cqlServerKey == null)
                {
                    cqlServerKey = Registry.CurrentUser.CreateSubKey("CQL Server", true);
                }


                //open or create Databases key
                databasesKey = cqlServerKey.OpenSubKey("Databases", true);
                if (databasesKey == null)
                {
                    databasesKey = cqlServerKey.CreateSubKey("Databases", true);
                }//(databasesKey != null)


                //add entry to Databases subkey with name = alias and value = folder
                using (databasesKey)
                {
                    databasesKey.SetValue(alias, folder);
                }

                FillObjectExplorer();
            }//(folderBrowserDialog1.ShowDialog() == DialogResult.OK)


        }//ctxmnuAddDatabase_Click()

        private void ctxmnuRenameDatabase_Click(object sender, EventArgs e)
        {
            var folder = "";
            var oldAlias = "";
            var newAlias = "";
            TreeNode treeNode;
            RegistryKey cqlServerKey;
            RegistryKey databasesKey;

            //can't rename root node
            if (tvDatabases.SelectedNode.Parent == null) return;

            treeNode = tvDatabases.SelectedNode;
            if (treeNode.Tag.ToString() == "FILE") return;

            //open or create base level Registry key
            cqlServerKey = Registry.CurrentUser.OpenSubKey("CQL Server");
            if (cqlServerKey == null)
            {
                cqlServerKey = Registry.CurrentUser.CreateSubKey("CQL Server", true);
            }// (cqlServerKey == null)

            //open or create Databases key
            databasesKey = cqlServerKey.OpenSubKey("Databases", true);
            if (databasesKey == null)
            {
                databasesKey = cqlServerKey.CreateSubKey("Databases", true);
            }//(databasesKey != null)

            //get entry under Databases subkey corresponding to current TreeView node

            oldAlias = treeNode.Text;
            folder = treeNode.Tag.ToString();

            newAlias = Microsoft.VisualBasic.Interaction.InputBox($"Enter alias for folder {folder}", "CQL Server");
            if (newAlias == string.Empty) return;
            if (newAlias.ToLower() == "databases")
            {
                MessageBox.Show("Invalid database name.", "CQL Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            using (databasesKey)
            {
                databasesKey.DeleteValue(oldAlias, false);
                databasesKey.SetValue(newAlias, folder);
            }

            treeNode.Text = newAlias;

        }//ctxmnuRenameDatabase_Click()

       

        private void frmCQLServer_Load(object sender, EventArgs e)
        {
            FillObjectExplorer();
        }//frmCQLServer_Load


        /// <summary>
        /// Check if supplied folder is a value under the Databases subkey 
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private bool IsDatabase(string folder)
        {

            RegistryKey cqlServerKey;
            RegistryKey databasesKey;

            //open base level Registry key
            cqlServerKey = Registry.CurrentUser.OpenSubKey("CQL Server");
            if (cqlServerKey == null)
            {
                return false;
            }
            else if (cqlServerKey.SubKeyCount == 0)
            {
                return false;
            }// (cqlServerKey == null)


            databasesKey = cqlServerKey.OpenSubKey("Databases", true);
            if (databasesKey != null)
            {


                using (databasesKey)
                {
                    foreach (string valueName in databasesKey.GetValueNames())
                    {
                        if (databasesKey.GetValue(valueName).ToString() == folder)
                        {
                            return true;
                        }
                    }//foreach (string valueName in databasesKey.GetValueNames()) 
                }//using (databasesKey)
                return false;
            }

            else
            {
                return false;
            }//(databasesKey != null)

        }//IsDatabase()

        private bool IsAlias(string alias)
        {
            //check if a node with this alias already exists
            foreach (TreeNode node in tvDatabases.Nodes[0].Nodes)
            {
                if (node.Text.ToLower() == alias.ToLower())
                {

                    return true;
                }
            }//foreach (TreeNode node in tvDatabases.Nodes[0].Nodes)
            return false;
        }//IsAlias

        private void ctxmnuRemoveDatabase_Click(object sender, EventArgs e)
        {
            RegistryKey cqlServerKey;
            RegistryKey databasesKey;

            //can't delete root node
            if (tvDatabases.SelectedNode.Parent == null) return;

            var alias = tvDatabases.SelectedNode.Text;
            //must remove entry in Registry
            //open base level Registry key
            cqlServerKey = Registry.CurrentUser.OpenSubKey("CQL Server");
            databasesKey = cqlServerKey.OpenSubKey("Databases", true);
            using (databasesKey)
            {
                databasesKey.DeleteValue(alias);
            }
            FillObjectExplorer();


        }//ctxmnuRemoveDatabase_Click()

        private void tvDatabases_Click(object sender, EventArgs e)
        {
            
 

        }//tvDatabases_Click()

        private void tvDatabases_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvDatabases.SelectedNode;

            if (node.Tag != null)
            {
                if (node.Tag.ToString() == "FILE")
                {
                    renameTableToolStripMenuItem.Enabled = true;
                    ctxmnuRenameDatabase.Enabled = false;
                    var fullPath = node.Parent.Tag.ToString() + @"\" + node.Text;
                    StreamReader reader = new StreamReader(fullPath);
                    var toolText = "";
                    var lineCount = 0;
                    //preview file in tooltip
                    using (reader)
                    {
                        while ((!reader.EndOfStream) && (lineCount < 5))
                        {
                            toolText += reader.ReadLine() + Environment.NewLine;
                            lineCount += 1;
                        }
                    }//using (reader)

                    node.ToolTipText = toolText;

                    //load csv file into datagridview control
                }
                else
                {
                    renameTableToolStripMenuItem.Enabled = false;
                    ctxmnuRenameDatabase.Enabled = true;
                }//(node.Tag.ToString() == "FILE")
            }//(node.Tag != null)
        }//tvDatabases_AfterSelect()

        private void tvDatabases_DoubleClick(object sender, EventArgs e)
        {
            //load csv file into datagridview
            LoadFile();

        }

        private void LoadFile()
        {
            var file = "";
            var lineCount = 0;
            int rowCount = 0;

            TreeNode node = tvDatabases.SelectedNode;

            if ((node.Tag != null) && (node.Tag.ToString() == "FILE"))
            {
                ClearDataGridView();


                file = node.Parent.Tag.ToString() + @"\" + node.Text;
                StreamReader reader = new StreamReader(file);
                using (reader)
                {
                    while ((!reader.EndOfStream))
                    {
                        var line = reader.ReadLine() + Environment.NewLine;
                        rowCount += 1;
                        //use VB's TextReader class, which can handle CSV files
                        TextReader textReader = new StringReader(line);
                        TextFieldParser textFieldParser = new TextFieldParser(textReader);
                        textFieldParser.TextFieldType = FieldType.Delimited;
                        textFieldParser.SetDelimiters(",");

                        string[] currentRow;

                        while (!textFieldParser.EndOfData)
                        {
                            try
                            {
                                currentRow = textFieldParser.ReadFields();
                               
                                AddCSVDataRow(currentRow, (rowCount == 1));

                            }
                            catch (MalformedLineException e)
                            {
                                //invalid line so don't process
                            }//(MalformedLineException e)

                        }//(!textFieldParser.EndOfData)


                        lineCount += 1;

                    }//((!reader.EndOfStream))
                }//using (reader)

                UpdateFieldList();
                this.Text = $"CQL Server 2018 [VIEWING {file}]";

            }//((node.Tag != null) && (node.Tag.ToString() == "FILE"))
        }//LoadFile()

        private void AddCSVDataRow(string[] currentRow, bool IsFirstRow = false)
        {
            //adjust number of columns in datagridview control
            AdjustDataGridView(currentRow.Length);

            if (IsFirstRow)
            {
                if (chkSkipFirstRow.Checked)
                {
                    //populate header column
                    for (int i = 0; i <= (currentRow.Length - 1); i++)
                    {
                        dgvExport.Columns[i + 1].HeaderText = currentRow[i];
                    }
                    return;
                }//(chkSkipFirstRow.Checked)

            }//(IsFirstRow)

           
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(dgvExport);
            dataGridViewRow.Cells[0].Value = false;
            for (int i = 0; i <= (currentRow.Length - 1); i++)
            {
                dataGridViewRow.Cells[i + 1].Value = currentRow[i];
            }

           dgvExport.Rows.Add(dataGridViewRow);
           
        }//AddCSVDataRow()

        private void AdjustDataGridView(int length)
        {
            int exportColumnCount = dgvExport.ColumnCount - 1;
            if (length > exportColumnCount)
            {
                for (int fieldCount = 0; fieldCount < (length - exportColumnCount); fieldCount++)
                {
                    /* When adding a new column name must take into account how many columns already exist
                     * E.g. if dgvExport has Field1, Field2, and Field3 and now we want to add a new column
                     * it should be named Field4, which means we must include the value of exportColumnCount
                     * in determing the header for the new column
                     */
                    dgvExport.Columns.Add($"Field{exportColumnCount + fieldCount + 1}", $"Field{exportColumnCount + fieldCount + 1}");
                }//(int fieldCount = 0; fieldCount < (length - exportColumnCount); fieldCount++)
            }//(length > exportColumnCount)
        }////AdjustDataGridView()


        private void ClearDataGridView()
        {
            if (dgvExport.RowCount > 0)
            {
                dgvExport.Rows.Clear();
            }

            //remove all columns except Select
            while (dgvExport.ColumnCount > 1)
            {
                dgvExport.Columns.RemoveAt(1);
            }
        }//ClearDataGridView


        private void FillObjectExplorer()
        {

            TreeNode treeNode;
            RegistryKey cqlServerKey;
            RegistryKey databasesKey;

            //open base level Registry key
            cqlServerKey = Registry.CurrentUser.OpenSubKey("CQL Server");
            if (cqlServerKey == null)
            {
                return;
            }
            else if (cqlServerKey.SubKeyCount == 0)
            {
                return;
            }// (cqlServerKey == null)

            tvDatabases.Nodes[0].Nodes.Clear();

            //open Databases key
            databasesKey = cqlServerKey.OpenSubKey("Databases", true);
            if (databasesKey == null)
            {
                return;
            }//(databasesKey != null)

            using (databasesKey)
            {
                if (databasesKey.ValueCount > 0)
                {
                    foreach (string valueName in databasesKey.GetValueNames())
                    {
                        var folder =  databasesKey.GetValue(valueName).ToString();
                        if (Directory.Exists(folder))
                        {
                            treeNode = tvDatabases.Nodes[0].Nodes.Add(valueName.ToString());
                            treeNode.Tag = folder;
                            treeNode.ToolTipText = $"Alias for {@folder}";
                            //put child nodes for any files contained in the folder
                            foreach (string file in Directory.EnumerateFiles(folder, "*.csv"))
                            {
                                var subTreeNode = treeNode.Nodes.Add(Path.GetFileName(file));
                                subTreeNode.Tag = "FILE";
                            }
                        }
                        else
                        {
                            //delete registry entry for non existent folder
                            databasesKey.DeleteValue(valueName);


                        }//(Directory.Exists(folder))

                    }//foreach (string subkey in databasesKey.GetValueNames())
                }//(databasesKey.ValueCount > 0)
            }//using (databasesKey)
            tvDatabases.Sort();
        }//FillObjectExplorer()

        private void AddDatabaseNode(string alias, string folder)
        {
            TreeNode treeNode;

            //add node to tree view
            treeNode = new TreeNode(alias);
            treeNode.Tag = folder;
            tvDatabases.Nodes[0].Nodes.Add(treeNode);
            FillObjectExplorer();
        }//AddDatabaseNode()


        //clear DataTable and fill with contents of DataGridView
        private void FillDataTable()
        {
            //not currently used; for reference only
            if (dataTable == null)
            {
                dataTable = new DataTable("GridData");
            }
            else
            {
                //empty DataTable so we can put the contents of the DataGridView into it
                dataTable.Rows.Clear();
                dataTable.Columns.Clear();
            }//(dataTable == null)

            if (dgvExport.RowCount == 0) return;

            //add columns to DataTable based on structure of DataGridView
            //excluding Select column
            for (int i = 1; i < dgvExport.ColumnCount; i++)
            {
                dataTable.Columns.Add(dgvExport.Columns[i].HeaderText);

            }//(int i = 0; i < dgvExport.ColumnCount; i++)

            //now add data rows, exluding Select column

            for (int i = 1; i < dgvExport.ColumnCount; i++)
            {
                DataGridViewRow dataGridViewRow = dgvExport.Rows[i];
                var dataTableRow = new List<string>();
                dataTableRow.Clear();
                for (int j = 1; j < dataGridViewRow.Cells.Count; j++)
                {
                    dataTableRow.Add(dataGridViewRow.Cells[j].ToString());
                }
                dataTable.Rows.Add(dataTableRow);
                

            }//(int i = 0; i < dgvExport.ColumnCount; i++)


        }//FillDataTable

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            //scroll DataGridView so that column is leftmost
            //if All is selected, then reset DGV control to default
            //MessageBox.Show(cboField.Text);
            //first column (Select) is frozen so can't scroll to it

            //reset visibility of all columns
            for (int i = 1; i < dgvExport.ColumnCount; i++)
            {
                dgvExport.Columns[i].Visible = true;
            }

            if (cboField.SelectedIndex != 0)
            {

                for (int i = 1; i < cboField.SelectedIndex; i++)
                {
                    dgvExport.Columns[i].Visible = false;
                    //dgvExport.FirstDisplayedScrollingColumnIndex = cboField.SelectedIndex;
                }
            }
            else
            {
                dgvExport.FirstDisplayedScrollingColumnIndex = 1;
            }//(cboField.SelectedIndex != 0)
        }//cboField_SelectedIndexChanged()

        private void UpdateFieldList()
        {
            //populate field name dropdown
            cboField.Items.Clear();
            cboField.Items.Add("All");
            for (int i = 1; i <= dgvExport.ColumnCount - 1; i++)
            {
                cboField.Items.Add(dgvExport.Columns[i].HeaderText);
            }
        }//UpdateFieldList()

        private void btnRenameFields_Click(object sender, EventArgs e)
        {
            frmRenameFields frm = new frmRenameFields();
            if (cboField.Items.Count > 0)
            {
                for (int i = 1; i < cboField.Items.Count; i++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(frm.dgvRenameFields);
                    dataGridViewRow.Tag = i.ToString(); //store column position in Tag property
                    dataGridViewRow.Cells[0].Value = cboField.Items[i].ToString();
                    dataGridViewRow.Cells[1].Value = null;
                    frm.dgvRenameFields.Rows.Add(dataGridViewRow);
                }//for (int i = 0; i < cboField.Items.Count; i++)

                frm.dgvRenameFields.Sort(frm.dgvRenameFields.Columns[0], ListSortDirection.Ascending);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < frm.dgvRenameFields.RowCount; i++)
                    {
                        /*only rename fields that have a value in the Rename To column
                        *original CSV file *could* have duplicated field names
                        * but that's not our responsibility to fix so we will allow
                        * duplicate names
                        * Assign names by position; don't seek for values in Original name 
                        * column
                        */
                        DataGridViewRow dataGridViewRow;
                        dataGridViewRow = frm.dgvRenameFields.Rows[i];
                        if (dataGridViewRow.Cells[1].Value != null)
                        {
                            int colPosition = int.Parse(dataGridViewRow.Tag.ToString());
                            dgvExport.Columns[colPosition].HeaderText = dataGridViewRow.Cells[1].Value.ToString();
                        }
                    }//for (int i = 0; i < frm.dgvRenameFields.RowCount; i++)

                    frm.Dispose();
                    UpdateFieldList();
                }
                else
                {
                    frm.Dispose();
                }
                
            }//(cboField.Items.Count > 0)
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvExport.RowCount == 0)
            {
                return;
            }


            for (int i = 0; i < dgvExport.Rows.Count; i++)
            {
                dgvExport.Rows[i].Cells[0].Value = chkAll.Checked;
            }
            chkAll.Text = (chkAll.Checked) ? "Deselect All" : "Select All";
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            EditDataGridView(DGViewEditType.Trim);

            //if (cboField.SelectedIndex != -1)
            //{
            //    if (cboField.Text != "All")
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {

            //            if (dgvExport.Rows[i].Cells[cboField.Text].Value != null)
            //            {
            //                string temp = dgvExport.Rows[i].Cells[cboField.Text].Value.ToString();
            //                dgvExport.Rows[i].Cells[cboField.Text].Value = temp.Trim();
            //            }
            //        }//(int i = 0; i < dgvExport.RowCount; i++)
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {
            //            for (int j = 1; j < dgvExport.ColumnCount; j++)
            //            {
            //                if (dgvExport.Rows[i].Cells[j].Value != null)
            //                {
            //                    string temp = dgvExport.Rows[i].Cells[j].Value.ToString();
            //                    dgvExport.Rows[i].Cells[j].Value = temp.Trim();
            //                }
            //            }
            //        }//(int i = 0; i < dgvExport.RowCount; i++)

            //    }//(cboField.Text != "All")
            //}//(cboField.SelectedIndex != -1)
        }//btnTrim_Click()

        private void btnClean_Click(object sender, EventArgs e)
        {
            EditDataGridView(DGViewEditType.Clean);
            //if (cboField.SelectedIndex != -1)
            //{
            //    if (cboField.Text != "All")
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {

            //            if (dgvExport.Rows[i].Cells[cboField.Text].Value != null)
            //            {
            //                string temp = dgvExport.Rows[i].Cells[cboField.Text].Value.ToString();
            //                dgvExport.Rows[i].Cells[cboField.Text].Value = Regex.Replace(temp, @"[^\w -]", "");
            //            }
            //        }//(int i = 0; i < dgvExport.RowCount; i++)
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {
            //            for (int j = 1; j < dgvExport.ColumnCount; j++)
            //            {
            //                if (dgvExport.Rows[i].Cells[j].Value != null)
            //                {
            //                    string temp = dgvExport.Rows[i].Cells[j].Value.ToString();
            //                    dgvExport.Rows[i].Cells[j].Value = Regex.Replace(temp, @"[^\w -]", "");
            //                }
            //            }
            //        }//(int i = 0; i < dgvExport.RowCount; i++)

            //    }//(cboField.Text != "All")
            //}//(cboField.SelectedIndex != -1)
        }//btnClean_Click()

        private void btnToUpper_Click(object sender, EventArgs e)
        {
            EditDataGridView(DGViewEditType.Upper);
            //if (cboField.SelectedIndex != -1)
            //{
            //    if (cboField.Text != "All")
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {

            //            if (dgvExport.Rows[i].Cells[cboField.Text].Value != null)
            //            {
            //                string temp = dgvExport.Rows[i].Cells[cboField.Text].Value.ToString().ToUpper();
            //                dgvExport.Rows[i].Cells[cboField.Text].Value = temp;
            //            }
            //        }//(int i = 0; i < dgvExport.RowCount; i++)
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dgvExport.RowCount; i++)
            //        {
            //            for (int j = 1; j < dgvExport.ColumnCount; j++)
            //            {
            //                if (dgvExport.Rows[i].Cells[j].Value != null)
            //                {
            //                    string temp = dgvExport.Rows[i].Cells[j].Value.ToString().ToUpper();
            //                    dgvExport.Rows[i].Cells[j].Value = temp;
            //                }
            //            }//(int j = 1; j < dgvExport.ColumnCount; j++)
            //        }//(int i = 0; i < dgvExport.RowCount; i++)

            //    }//(cboField.Text != "All")
            //}//(cboField.SelectedIndex != -1)
        }//btnToUpper_Click()

        private void EditDataGridView(DGViewEditType type)
        {
            if (cboField.SelectedIndex != -1)
            {
                if (cboField.Text != "All")
                {
                    for (int i = 0; i < dgvExport.RowCount; i++)
                    {
                        if (dgvExport.Rows[i].Cells[cboField.Text].Value != null)
                        {
                            string temp = dgvExport.Rows[i].Cells[cboField.Text].Value.ToString();
                            switch (type)
                            {
                                case DGViewEditType.Clean:
                                    dgvExport.Rows[i].Cells[cboField.Text].Value = Regex.Replace(temp, @"[^\w -]", "");
                                    break;

                                case DGViewEditType.Trim:
                                    dgvExport.Rows[i].Cells[cboField.Text].Value = temp.Trim();
                                    break;

                                case DGViewEditType.Upper:
                                    dgvExport.Rows[i].Cells[cboField.Text].Value = temp.ToUpper();
                                    break;
                            }//switch (type)
                        }//if (dgvExport.Rows[i].Cells[cboField.Text].Value != null)
                    }//for (int i = 0; i < dgvExport.RowCount; i++)
                }
                else
                {
                    for (int i = 0; i < dgvExport.RowCount; i++)
                    {
                        for (int j = 1; j < dgvExport.ColumnCount; j++)
                        {
                            if (dgvExport.Rows[i].Cells[j].Value != null)
                            {
                                string temp = dgvExport.Rows[i].Cells[j].Value.ToString();
                                switch (type)
                                {
                                    case DGViewEditType.Clean:
                                        dgvExport.Rows[i].Cells[j].Value = Regex.Replace(temp, @"[^\w -]", "");
                                        break;

                                    case DGViewEditType.Trim:
                                        dgvExport.Rows[i].Cells[j].Value = temp.Trim();
                                        break;

                                    case DGViewEditType.Upper:
                                        dgvExport.Rows[i].Cells[j].Value = temp.ToUpper();
                                        break;
                                }//switch (type)
                            }//if (dgvExport.Rows[i].Cells[j].Value != null)
                        }//for (int j = 1; j < dgvExport.ColumnCount; j++)
                    }//for (int i = 0; i < dgvExport.RowCount; i++)
                }//if (cboField.Text != "All")
            }//if (cboField.SelectedIndex != -1)

        }//EditDataGridView()

        private void btnExport_Click(object sender, EventArgs e)
        {
            var filePath = "";
            var output = "";


            if (dgvExport.RowCount == 0)
            {
                return;
            }

            saveFileDialog1.Title = "Export selected records to file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Export files (*.csv)|*.csv";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }


        /* Can't use Linq to query a DataGridView object but we can
        * use the GetRowCount() method to count up which records
        * have been selected for export. But that method works
        * for records highlighted by the user, not records
        * for which the Select column has been checked
        */

        var selectedRecordCount = 0;

        //may come in handy later but can't use to determine which records should be exported
        //selectedRecordCount = dgvExport.Rows.GetRowCount(DataGridViewElementStates.Selected);


        for (int i = 0; i < dgvExport.RowCount; i++)
        {
            if ((bool)dgvExport.Rows[i].Cells["colSelect"].Value)
            {
                selectedRecordCount += 1;
            }
        }//(int i = 0; i < dgvExport.RowCount; i++)


            if (MessageBox.Show($"About to export {selectedRecordCount} records. Continue?",
                                CAPTION, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
      
            //write header to output variable
            for (int j = 1; j < dgvExport.ColumnCount; j++)
            {
                output += dgvExport.Columns[j].HeaderText + ",";
            }//(int j = 1; j < dgvExport.ColumnCount; j++)

            //strip off final ","
            output = output.TrimEnd(',');
            output += Environment.NewLine;

            //write records in csv format
     

            for (int i = 0; i < dgvExport.RowCount; i++)
            {
                if ((bool)dgvExport.Rows[i].Cells["colSelect"].Value)
                {
                    for (int j = 1; j < dgvExport.ColumnCount; j++)
                    {
                        var line = (string)dgvExport.Rows[i].Cells[j].Value;
                        if (line != null)
                        {
                            if (line.IndexOfAny(new char[] { '"', ',' }) != -1)
                            {
                                line = Regex.Replace(line,  "\"", "\"\"");
                                line = "\"" + line + "\"";
                            }
                            
                            
                            output += line + ",";
                            
                        }
                        else
                        {
                            output += string.Empty + ",";
                        }//(line != null)
                    }//(int j = 1; j < dgvExport.ColumnCount; j++)

                    //strip off final ","
                    output = output.TrimEnd(',');
                    output += Environment.NewLine;
                }//((bool)dgvExport.Rows[i].Cells["colSelect"].Value)

            }//(int i = 0; i < dgvExport.RowCount; i++)

            // MessageBox.Show(output);
                
            File.WriteAllText(filePath, output);
            MessageBox.Show("Records have been exported to specified file.", CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
  
        }//btnExport_Click()

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillObjectExplorer();
        }

        private void tableNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameTable();
        }//tableNameToolStripMenuItem_Click()

        private void RenameTable()
        {
            //rename file corresponding to selected TreeView node
            TreeNode node = tvDatabases.SelectedNode;
            if (node.Tag != null)
            {
                if (node.Tag.ToString() == "FILE")
                {
                    var fullPath = node.Parent.Tag.ToString() + @"\" + node.Text;
                    FileInfo fileInfo = new FileInfo(fullPath);
                    var oldFilename = fileInfo.Name;
                    var newFilename = Microsoft.VisualBasic.Interaction.InputBox("Enter new filename", CAPTION, oldFilename);
                    if (newFilename == string.Empty) return;
                    if (newFilename.Trim().ToLower() == oldFilename.ToLower()) return;
                    var parentPath = Directory.GetParent(fullPath).ToString();
                    System.IO.File.Move(fullPath, Path.Combine(parentPath, newFilename));
                    FillObjectExplorer();
                }//if (node.Tag.ToString() == "FILE")
            }//if (node.Tag != null)
        }//RenameTable()

        private void renameTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameTable();
        }
    }//frmCQLServer : Form
}//CQL_Server
