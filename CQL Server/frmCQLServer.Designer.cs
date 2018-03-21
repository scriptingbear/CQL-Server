namespace CQL_Server
{
    partial class frmCQLServer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Databases");
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxmnuAddDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmnuRenameDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmnuRemoveDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tvDatabases = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvExport = new System.Windows.Forms.DataGridView();
            this.chkSkipFirstRow = new System.Windows.Forms.CheckBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnRenameFields = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTrim = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnToUpper = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxmnuAddDatabase,
            this.ctxmnuRenameDatabase,
            this.ctxmnuRemoveDatabase});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 70);
            // 
            // ctxmnuAddDatabase
            // 
            this.ctxmnuAddDatabase.Name = "ctxmnuAddDatabase";
            this.ctxmnuAddDatabase.Size = new System.Drawing.Size(167, 22);
            this.ctxmnuAddDatabase.Text = "Add database";
            this.ctxmnuAddDatabase.Click += new System.EventHandler(this.ctxmnuAddDatabase_Click);
            // 
            // ctxmnuRenameDatabase
            // 
            this.ctxmnuRenameDatabase.Name = "ctxmnuRenameDatabase";
            this.ctxmnuRenameDatabase.Size = new System.Drawing.Size(167, 22);
            this.ctxmnuRenameDatabase.Text = "Rename database";
            this.ctxmnuRenameDatabase.Click += new System.EventHandler(this.ctxmnuRenameDatabase_Click);
            // 
            // ctxmnuRemoveDatabase
            // 
            this.ctxmnuRemoveDatabase.Name = "ctxmnuRemoveDatabase";
            this.ctxmnuRemoveDatabase.Size = new System.Drawing.Size(167, 22);
            this.ctxmnuRemoveDatabase.Text = "Remove database";
            this.ctxmnuRemoveDatabase.Click += new System.EventHandler(this.ctxmnuRemoveDatabase_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newDatabaseToolStripMenuItem.Text = "New Database";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            // 
            // closeDatabaseToolStripMenuItem
            // 
            this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
            this.closeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.closeDatabaseToolStripMenuItem.Text = "Close Database";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allRecordsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // allRecordsToolStripMenuItem
            // 
            this.allRecordsToolStripMenuItem.Name = "allRecordsToolStripMenuItem";
            this.allRecordsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.allRecordsToolStripMenuItem.Text = "All records";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableNameToolStripMenuItem,
            this.fieldNamesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // tableNameToolStripMenuItem
            // 
            this.tableNameToolStripMenuItem.Name = "tableNameToolStripMenuItem";
            this.tableNameToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tableNameToolStripMenuItem.Text = "Rename table";
            // 
            // fieldNamesToolStripMenuItem
            // 
            this.fieldNamesToolStripMenuItem.Name = "fieldNamesToolStripMenuItem";
            this.fieldNamesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fieldNamesToolStripMenuItem.Text = "Rename fields";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countRecordsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // countRecordsToolStripMenuItem
            // 
            this.countRecordsToolStripMenuItem.Name = "countRecordsToolStripMenuItem";
            this.countRecordsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.countRecordsToolStripMenuItem.Text = "Filter records";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Databases";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tvDatabases
            // 
            this.tvDatabases.ContextMenuStrip = this.contextMenuStrip1;
            this.tvDatabases.Location = new System.Drawing.Point(8, 60);
            this.tvDatabases.Name = "tvDatabases";
            treeNode1.Name = "root";
            treeNode1.Text = "Databases";
            this.tvDatabases.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvDatabases.ShowNodeToolTips = true;
            this.tvDatabases.Size = new System.Drawing.Size(240, 439);
            this.tvDatabases.TabIndex = 3;
            this.tvDatabases.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabases_AfterSelect);
            this.tvDatabases.Click += new System.EventHandler(this.tvDatabases_Click);
            this.tvDatabases.DoubleClick += new System.EventHandler(this.tvDatabases_DoubleClick);
            // 
            // dgvExport
            // 
            this.dgvExport.AllowUserToResizeRows = false;
            this.dgvExport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect});
            this.dgvExport.Location = new System.Drawing.Point(254, 227);
            this.dgvExport.Name = "dgvExport";
            this.dgvExport.RowHeadersWidth = 15;
            this.dgvExport.Size = new System.Drawing.Size(970, 271);
            this.dgvExport.TabIndex = 4;
            // 
            // chkSkipFirstRow
            // 
            this.chkSkipFirstRow.AutoSize = true;
            this.chkSkipFirstRow.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkSkipFirstRow.Checked = true;
            this.chkSkipFirstRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipFirstRow.Location = new System.Drawing.Point(115, 37);
            this.chkSkipFirstRow.Name = "chkSkipFirstRow";
            this.chkSkipFirstRow.Size = new System.Drawing.Size(121, 17);
            this.chkSkipFirstRow.TabIndex = 5;
            this.chkSkipFirstRow.Text = "1st row has headers";
            this.chkSkipFirstRow.UseVisualStyleBackColor = false;
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(6, 19);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 21);
            this.cboField.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboField, "Select field upon which to perform an operation");
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // colSelect
            // 
            this.colSelect.Frozen = true;
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.Width = 62;
            // 
            // btnRenameFields
            // 
            this.btnRenameFields.Location = new System.Drawing.Point(133, 19);
            this.btnRenameFields.Name = "btnRenameFields";
            this.btnRenameFields.Size = new System.Drawing.Size(75, 23);
            this.btnRenameFields.TabIndex = 8;
            this.btnRenameFields.Text = "Rename...";
            this.btnRenameFields.UseVisualStyleBackColor = true;
            this.btnRenameFields.Click += new System.EventHandler(this.btnRenameFields_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(263, 206);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(70, 17);
            this.chkAll.TabIndex = 9;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRenameFields);
            this.groupBox1.Controls.Add(this.cboField);
            this.groupBox1.Location = new System.Drawing.Point(339, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 42);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fields";
            // 
            // btnTrim
            // 
            this.btnTrim.Location = new System.Drawing.Point(562, 196);
            this.btnTrim.Name = "btnTrim";
            this.btnTrim.Size = new System.Drawing.Size(75, 23);
            this.btnTrim.TabIndex = 11;
            this.btnTrim.Text = "Trim";
            this.toolTip1.SetToolTip(this.btnTrim, "Remove excess whitespace");
            this.btnTrim.UseVisualStyleBackColor = true;
            this.btnTrim.Click += new System.EventHandler(this.btnTrim_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(643, 196);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 12;
            this.btnClean.Text = "Clean";
            this.toolTip1.SetToolTip(this.btnClean, "Remove non printing characters");
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnToUpper
            // 
            this.btnToUpper.Location = new System.Drawing.Point(724, 196);
            this.btnToUpper.Name = "btnToUpper";
            this.btnToUpper.Size = new System.Drawing.Size(75, 23);
            this.btnToUpper.TabIndex = 13;
            this.btnToUpper.Text = "Upper";
            this.toolTip1.SetToolTip(this.btnToUpper, "Convert to upper case");
            this.btnToUpper.UseVisualStyleBackColor = true;
            this.btnToUpper.Click += new System.EventHandler(this.btnToUpper_Click);
            // 
            // frmCQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 509);
            this.Controls.Add(this.btnToUpper);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnTrim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkSkipFirstRow);
            this.Controls.Add(this.dgvExport);
            this.Controls.Add(this.tvDatabases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CQL Server 2018";
            this.Load += new System.EventHandler(this.frmCQLServer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxmnuAddDatabase;
        private System.Windows.Forms.ToolStripMenuItem ctxmnuRenameDatabase;
        private System.Windows.Forms.ToolStripMenuItem ctxmnuRemoveDatabase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvExport;
        private System.Windows.Forms.TreeView tvDatabases;
        private System.Windows.Forms.CheckBox chkSkipFirstRow;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.Button btnRenameFields;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrim;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnToUpper;
    }
}