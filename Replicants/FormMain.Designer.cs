namespace Replicants
{
	partial class FormMain
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
			this.panel1 = new System.Windows.Forms.Panel();
			this._checkBoxNames = new System.Windows.Forms.CheckBox();
			this._textBoxMaxSize = new System.Windows.Forms.TextBox();
			this._textBoxMinSize = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._comboBoxDir = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this._comboBoxSearchPattern = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this._buttonBrowseDir = new System.Windows.Forms.Button();
			this._buttonScan = new System.Windows.Forms.Button();
			this._treeViewReplicants = new System.Windows.Forms.TreeView();
			this._contextMenuStripReplicant = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._separator1toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this._expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._separator2toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this._clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._folderBrowserDialogAddDir = new System.Windows.Forms.FolderBrowserDialog();
			this._timerSaveSettings = new System.Windows.Forms.Timer(this.components);
			this._replicantFinder = new Replicants.ReplicantFinder();
			this.panel1.SuspendLayout();
			this._contextMenuStripReplicant.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this._checkBoxNames);
			this.panel1.Controls.Add(this._textBoxMaxSize);
			this.panel1.Controls.Add(this._textBoxMinSize);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this._comboBoxDir);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this._comboBoxSearchPattern);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this._buttonBrowseDir);
			this.panel1.Controls.Add(this._buttonScan);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(641, 109);
			this.panel1.TabIndex = 0;
			// 
			// _checkBoxNames
			// 
			this._checkBoxNames.AutoSize = true;
			this._checkBoxNames.Location = new System.Drawing.Point(247, 76);
			this._checkBoxNames.Margin = new System.Windows.Forms.Padding(2);
			this._checkBoxNames.Name = "_checkBoxNames";
			this._checkBoxNames.Size = new System.Drawing.Size(81, 17);
			this._checkBoxNames.TabIndex = 5;
			this._checkBoxNames.Text = "Only names";
			this._checkBoxNames.UseVisualStyleBackColor = true;
			// 
			// _textBoxMaxSize
			// 
			this._textBoxMaxSize.Location = new System.Drawing.Point(183, 76);
			this._textBoxMaxSize.Margin = new System.Windows.Forms.Padding(2);
			this._textBoxMaxSize.Name = "_textBoxMaxSize";
			this._textBoxMaxSize.Size = new System.Drawing.Size(60, 20);
			this._textBoxMaxSize.TabIndex = 4;
			this._textBoxMaxSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnlyNumbers_KeyDown);
			this._textBoxMaxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
			this._textBoxMaxSize.Leave += new System.EventHandler(this.OnlyNumbers_Leave);
			// 
			// _textBoxMinSize
			// 
			this._textBoxMinSize.Location = new System.Drawing.Point(113, 76);
			this._textBoxMinSize.Margin = new System.Windows.Forms.Padding(2);
			this._textBoxMinSize.Name = "_textBoxMinSize";
			this._textBoxMinSize.Size = new System.Drawing.Size(60, 20);
			this._textBoxMinSize.TabIndex = 3;
			this._textBoxMinSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnlyNumbers_KeyDown);
			this._textBoxMinSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
			this._textBoxMinSize.Leave += new System.EventHandler(this.OnlyNumbers_Leave);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(181, 59);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Max size";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(111, 59);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Min size";
			// 
			// _comboBoxDir
			// 
			this._comboBoxDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._comboBoxDir.FormattingEnabled = true;
			this._comboBoxDir.Location = new System.Drawing.Point(11, 28);
			this._comboBoxDir.Margin = new System.Windows.Forms.Padding(2);
			this._comboBoxDir.Name = "_comboBoxDir";
			this._comboBoxDir.Size = new System.Drawing.Size(556, 21);
			this._comboBoxDir.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 12);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Directory";
			// 
			// _comboBoxSearchPattern
			// 
			this._comboBoxSearchPattern.FormattingEnabled = true;
			this._comboBoxSearchPattern.Items.AddRange(new object[] {
            "*.*",
            "*.jpg",
            "*.mp3",
            "*.flac"});
			this._comboBoxSearchPattern.Location = new System.Drawing.Point(11, 76);
			this._comboBoxSearchPattern.Margin = new System.Windows.Forms.Padding(2);
			this._comboBoxSearchPattern.Name = "_comboBoxSearchPattern";
			this._comboBoxSearchPattern.Size = new System.Drawing.Size(92, 21);
			this._comboBoxSearchPattern.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 59);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search pattern";
			// 
			// _buttonBrowseDir
			// 
			this._buttonBrowseDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonBrowseDir.Location = new System.Drawing.Point(570, 27);
			this._buttonBrowseDir.Margin = new System.Windows.Forms.Padding(2);
			this._buttonBrowseDir.Name = "_buttonBrowseDir";
			this._buttonBrowseDir.Size = new System.Drawing.Size(62, 22);
			this._buttonBrowseDir.TabIndex = 1;
			this._buttonBrowseDir.Text = "Browse...";
			this._buttonBrowseDir.UseVisualStyleBackColor = true;
			this._buttonBrowseDir.Click += new System.EventHandler(this.ButtonBrowseDir_Click);
			// 
			// _buttonScan
			// 
			this._buttonScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonScan.Location = new System.Drawing.Point(570, 74);
			this._buttonScan.Margin = new System.Windows.Forms.Padding(2);
			this._buttonScan.Name = "_buttonScan";
			this._buttonScan.Size = new System.Drawing.Size(62, 22);
			this._buttonScan.TabIndex = 6;
			this._buttonScan.Text = "Scan";
			this._buttonScan.UseVisualStyleBackColor = true;
			this._buttonScan.Click += new System.EventHandler(this.ButtonAddDir_Click);
			// 
			// _treeViewReplicants
			// 
			this._treeViewReplicants.ContextMenuStrip = this._contextMenuStripReplicant;
			this._treeViewReplicants.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treeViewReplicants.Location = new System.Drawing.Point(0, 109);
			this._treeViewReplicants.Margin = new System.Windows.Forms.Padding(2);
			this._treeViewReplicants.Name = "_treeViewReplicants";
			this._treeViewReplicants.Size = new System.Drawing.Size(641, 378);
			this._treeViewReplicants.TabIndex = 0;
			this._treeViewReplicants.DoubleClick += new System.EventHandler(this.TreeViewReplicants_DoubleClick);
			this._treeViewReplicants.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeViewReplicants_KeyDown);
			// 
			// _contextMenuStripReplicant
			// 
			this._contextMenuStripReplicant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._openContainingFolderToolStripMenuItem,
            this._deleteToolStripMenuItem,
            this._separator1toolStripMenuItem,
            this._expandAllToolStripMenuItem,
            this._collapseAllToolStripMenuItem,
            this._separator2toolStripMenuItem,
            this._clearToolStripMenuItem});
			this._contextMenuStripReplicant.Name = "_contextMenuStripReplicant";
			this._contextMenuStripReplicant.Size = new System.Drawing.Size(198, 148);
			// 
			// _openToolStripMenuItem
			// 
			this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
			this._openToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._openToolStripMenuItem.Text = "Open";
			this._openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// _openContainingFolderToolStripMenuItem
			// 
			this._openContainingFolderToolStripMenuItem.Name = "_openContainingFolderToolStripMenuItem";
			this._openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._openContainingFolderToolStripMenuItem.Text = "Open containing folder";
			this._openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenContainingFolderToolStripMenuItem_Click);
			// 
			// _deleteToolStripMenuItem
			// 
			this._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem";
			this._deleteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._deleteToolStripMenuItem.Text = "Delete";
			this._deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// _separator1toolStripMenuItem
			// 
			this._separator1toolStripMenuItem.Name = "_separator1toolStripMenuItem";
			this._separator1toolStripMenuItem.Size = new System.Drawing.Size(194, 6);
			// 
			// _expandAllToolStripMenuItem
			// 
			this._expandAllToolStripMenuItem.Name = "_expandAllToolStripMenuItem";
			this._expandAllToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._expandAllToolStripMenuItem.Text = "Expand all";
			this._expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
			// 
			// _collapseAllToolStripMenuItem
			// 
			this._collapseAllToolStripMenuItem.Name = "_collapseAllToolStripMenuItem";
			this._collapseAllToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._collapseAllToolStripMenuItem.Text = "Collapse all";
			this._collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
			// 
			// _separator2toolStripMenuItem
			// 
			this._separator2toolStripMenuItem.Name = "_separator2toolStripMenuItem";
			this._separator2toolStripMenuItem.Size = new System.Drawing.Size(194, 6);
			// 
			// _clearToolStripMenuItem
			// 
			this._clearToolStripMenuItem.Name = "_clearToolStripMenuItem";
			this._clearToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this._clearToolStripMenuItem.Text = "Clear";
			this._clearToolStripMenuItem.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// _folderBrowserDialogAddDir
			// 
			this._folderBrowserDialogAddDir.Description = "Select the folder that contains files to search for replicants.";
			// 
			// _timerSaveSettings
			// 
			this._timerSaveSettings.Interval = 2000;
			this._timerSaveSettings.Tick += new System.EventHandler(this.TimerSaveSettings_Tick);
			// 
			// _replicantFinder
			// 
			this._replicantFinder.WorkerReportsProgress = true;
			this._replicantFinder.WorkerSupportsCancellation = true;
			this._replicantFinder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ReplicantFinder_ProgressChanged);
			this._replicantFinder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReplicantFinder_RunWorkerCompleted);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 487);
			this.Controls.Add(this._treeViewReplicants);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(420, 39);
			this.Name = "FormMain";
			this.Text = "File Replicants";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this._contextMenuStripReplicant.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView _treeViewReplicants;
		private System.Windows.Forms.Button _buttonScan;
		private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialogAddDir;
		private System.Windows.Forms.ComboBox _comboBoxSearchPattern;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip _contextMenuStripReplicant;
		private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _deleteToolStripMenuItem;
		private System.Windows.Forms.ComboBox _comboBoxDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripSeparator _separator1toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _clearToolStripMenuItem;
		private System.Windows.Forms.Button _buttonBrowseDir;
		private System.Windows.Forms.Timer _timerSaveSettings;
		private System.Windows.Forms.ToolStripMenuItem _expandAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _collapseAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator _separator2toolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _textBoxMaxSize;
		private System.Windows.Forms.TextBox _textBoxMinSize;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripMenuItem _openContainingFolderToolStripMenuItem;
		private System.Windows.Forms.CheckBox _checkBoxNames;
		private ReplicantFinder _replicantFinder;
	}
}

