namespace CQL_Server
{
    partial class frmRenameFields
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
            this.dgvRenameFields = new System.Windows.Forms.DataGridView();
            this.btnRename = new System.Windows.Forms.Button();
            this.OriginalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenameFields)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRenameFields
            // 
            this.dgvRenameFields.AllowUserToAddRows = false;
            this.dgvRenameFields.AllowUserToDeleteRows = false;
            this.dgvRenameFields.AllowUserToResizeRows = false;
            this.dgvRenameFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRenameFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OriginalName,
            this.NewName});
            this.dgvRenameFields.Location = new System.Drawing.Point(12, 12);
            this.dgvRenameFields.Name = "dgvRenameFields";
            this.dgvRenameFields.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRenameFields.Size = new System.Drawing.Size(373, 237);
            this.dgvRenameFields.TabIndex = 0;
            // 
            // btnRename
            // 
            this.btnRename.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRename.Location = new System.Drawing.Point(391, 12);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(98, 32);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // OriginalName
            // 
            this.OriginalName.HeaderText = "Original";
            this.OriginalName.Name = "OriginalName";
            this.OriginalName.ReadOnly = true;
            this.OriginalName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.OriginalName.Width = 150;
            // 
            // NewName
            // 
            this.NewName.HeaderText = "Rename To";
            this.NewName.Name = "NewName";
            this.NewName.Width = 150;
            // 
            // frmRenameFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 261);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.dgvRenameFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenameFields";
            this.Text = "Rename Fields";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenameFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRename;
        internal System.Windows.Forms.DataGridView dgvRenameFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
    }
}