namespace DataStructuresWiki2
{
    partial class WikiForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.listViewWiki = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(132, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Structures Wiki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(25, 118);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(219, 23);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxName_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(31, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Category:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(25, 163);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(219, 24);
            this.comboBoxCategory.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonNonLinear);
            this.groupBox1.Controls.Add(this.radioButtonLinear);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Location = new System.Drawing.Point(28, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Structure:";
            // 
            // radioButtonNonLinear
            // 
            this.radioButtonNonLinear.AutoSize = true;
            this.radioButtonNonLinear.Location = new System.Drawing.Point(110, 22);
            this.radioButtonNonLinear.Name = "radioButtonNonLinear";
            this.radioButtonNonLinear.Size = new System.Drawing.Size(96, 20);
            this.radioButtonNonLinear.TabIndex = 4;
            this.radioButtonNonLinear.TabStop = true;
            this.radioButtonNonLinear.Text = "Non-Linear";
            this.radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(6, 22);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(66, 20);
            this.radioButtonLinear.TabIndex = 3;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(34, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Definition:";
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(28, 270);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(216, 182);
            this.textBoxDefinition.TabIndex = 5;
            // 
            // listViewWiki
            // 
            this.listViewWiki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewWiki.HideSelection = false;
            this.listViewWiki.Location = new System.Drawing.Point(288, 118);
            this.listViewWiki.MultiSelect = false;
            this.listViewWiki.Name = "listViewWiki";
            this.listViewWiki.Size = new System.Drawing.Size(286, 334);
            this.listViewWiki.TabIndex = 14;
            this.toolTip1.SetToolTip(this.listViewWiki, "Complete list of all current Data Structures.");
            this.listViewWiki.UseCompatibleStateImageBehavior = false;
            this.listViewWiki.View = System.Windows.Forms.View.Details;
            this.listViewWiki.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewWiki_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 127;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonSearch.Location = new System.Drawing.Point(499, 80);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.buttonSearch, "Search all Data Structures. Based on data in Search TextBox to the left.");
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(288, 80);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(205, 23);
            this.textBoxSearch.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textBoxSearch, "Enter Data Structure NAME to search for here. NOTE: Case Sensitive");
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonAdd.Location = new System.Drawing.Point(28, 473);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonAdd, "Add a new Data Structure to Wiki. Based on your entry in the four input items abo" +
        "ve.");
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEdit.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonEdit.Location = new System.Drawing.Point(109, 473);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.buttonEdit, "Edit a Data Structure. Based on your entry in the four input items above.");
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonDelete.Location = new System.Drawing.Point(190, 473);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.buttonDelete, "Delete the selected Data Structure from the List.");
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpen.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonOpen.Location = new System.Drawing.Point(418, 473);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 10;
            this.buttonOpen.Text = "Open";
            this.toolTip1.SetToolTip(this.buttonOpen, "Open a saved file which contains a list of Data Structures previously saved.");
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonSave.Location = new System.Drawing.Point(499, 473);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.toolTip1.SetToolTip(this.buttonSave, "Save the current list of Data Structures to a file.");
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReset.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonReset.Location = new System.Drawing.Point(271, 473);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Clear";
            this.toolTip1.SetToolTip(this.buttonReset, "Clear the Name, Category, Structure and Definition input items.");
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(586, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // WikiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(586, 538);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listViewWiki);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WikiForm";
            this.ShowIcon = false;
            this.Text = "Data Structures Wiki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WikiForm_FormClosing);
            this.Load += new System.EventHandler(this.WikiForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNonLinear;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.ListView listViewWiki;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

