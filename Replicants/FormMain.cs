using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Replicants
{
	public partial class FormMain : Form
	{
		int _foundReplicants = 0;
		bool _allowedDigitKey;

		public FormMain()
		{
			InitializeComponent();
			components.Add(_replicantFinder);
		}

		private void AddScanDirectory(string dir)
		{
			int index = Properties.Settings.Default.ScanDirectories.IndexOf(dir);
			if (index >= 0)
				Properties.Settings.Default.ScanDirectories.RemoveAt(index);

			Properties.Settings.Default.ScanDirectories.Insert(0, dir);
			while (Properties.Settings.Default.ScanDirectories.Count > 10)
				Properties.Settings.Default.ScanDirectories.RemoveAt(10);

			SaveSettings();
		}

		private TreeNode GetSourceTreeNode(FileItem fileItem)
		{
			foreach (TreeNode treeNode in _treeViewReplicants.Nodes)
			{
				if (ReferenceEquals(treeNode.Tag, fileItem))
					return treeNode;
			}

			return null;
		}

		private void SaveSettings()
		{
			_timerSaveSettings.Stop();
			_timerSaveSettings.Start();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			_comboBoxSearchPattern.SelectedIndex = 0;

			_comboBoxDir.DataSource = Properties.Settings.Default.ScanDirectories;
			_timerSaveSettings.Interval = Properties.Settings.Default.SaveSettingsInterval;
		}

		private void ButtonAddDir_Click(object sender, EventArgs e)
		{
			if (_replicantFinder.IsBusy)
			{
				if (MessageBox.Show("Stop searching for file replicants?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				if (_replicantFinder.IsBusy && !_replicantFinder.CancellationPending)
					_replicantFinder.CancelAsync();

				return;
			}

			_clearToolStripMenuItem.PerformClick();

			_foundReplicants = 0;
			AddScanDirectory(_comboBoxDir.Text);
			_buttonScan.Text = "Stop";
			Cursor = Cursors.AppStarting;
			long value;
			_replicantFinder._minSize = long.TryParse(_textBoxMinSize.Text, out value) ? (long?)value : null;
			_replicantFinder._maxSize = long.TryParse(_textBoxMaxSize.Text, out value) ? (long?)value : null;
			_replicantFinder.Replicants = _checkBoxNames.Checked ? new FileItemMap(new FileItem.NameComparer()) : new FileItemMap();
			_replicantFinder.RunWorkerAsync(new ReplicantFinderArgs(_comboBoxDir.Text, _comboBoxSearchPattern.Text, _checkBoxNames.Checked));
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			if (_replicantFinder.IsBusy)
				return;

			_treeViewReplicants.BeginUpdate();
			_treeViewReplicants.Nodes.Clear();
			_treeViewReplicants.EndUpdate();
		}

		private void ReplicantFinder_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			_treeViewReplicants.BeginUpdate();

			var args = (ReplicantEventArgs)e.UserState;
			var containerTreeNode = GetSourceTreeNode(args.Source);
			var replicantTreeNode = new TreeNode()
			{
				Text = args.Replicant.Path,
				Tag = args.Replicant
			};

			if (containerTreeNode == null)
			{
				containerTreeNode = new TreeNode()
				{
					Tag = args.Source
				};

				var sourceTreeNode = new TreeNode()
				{
					Text = args.Source.Path,
					Tag = args.Source
				};
				_treeViewReplicants.Nodes.Add(containerTreeNode);
				containerTreeNode.Nodes.Add(sourceTreeNode);
			}

			containerTreeNode.Nodes.Add(replicantTreeNode);
			containerTreeNode.Text = string.Format("{0} (x {1}, {2} bytes)", args.Source.Info.Name, containerTreeNode.Nodes.Count, args.Source.Info.Length);
			containerTreeNode.Expand();

			_treeViewReplicants.EndUpdate();

			_foundReplicants++;
		}

		private void ReplicantFinder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_buttonScan.Text = "Scan directory";
			Cursor = Cursors.Default;

			if (_foundReplicants == 0)
				MessageBox.Show("No replicants found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_treeViewReplicants.SelectedNode == null || _treeViewReplicants.SelectedNode.Parent == null)
				return;

			var fileItem = _treeViewReplicants.SelectedNode.Tag as FileItem;
			if (fileItem == null)
				return;

			Process.Start(fileItem.Path);
		}

		private void TreeViewReplicants_DoubleClick(object sender, EventArgs e)
		{
			_openToolStripMenuItem.PerformClick();
		}

		private void ButtonBrowseDir_Click(object sender, EventArgs e)
		{
			if (_folderBrowserDialogAddDir.ShowDialog() != DialogResult.OK)
				return;

			AddScanDirectory(_folderBrowserDialogAddDir.SelectedPath);

			_comboBoxDir.DataSource = null;
			_comboBoxDir.DataSource = Properties.Settings.Default.ScanDirectories;

			_comboBoxDir.SelectedIndex = 0;
		}

		private void TimerSaveSettings_Tick(object sender, EventArgs e)
		{
			_timerSaveSettings.Stop();

			Properties.Settings.Default.Save();
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_treeViewReplicants.BeginUpdate();
			_treeViewReplicants.ExpandAll();
			_treeViewReplicants.EndUpdate();
		}

		private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_treeViewReplicants.BeginUpdate();
			_treeViewReplicants.CollapseAll();
			_treeViewReplicants.EndUpdate();
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_treeViewReplicants.SelectedNode == null || _treeViewReplicants.SelectedNode.Parent == null)
				return;

			var fileItem = _treeViewReplicants.SelectedNode.Tag as FileItem;
			if (fileItem == null)
				return;

			var msg = string.Format("Delete '{0}'?", fileItem.Path);
			if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
				return;

			try
			{
				FileSystem.DeleteFile(fileItem.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

				// TODO: Remove file item from list.
				//Replicants.Remove(fileItem

				_treeViewReplicants.BeginUpdate();
				var parent = _treeViewReplicants.SelectedNode.Parent;
				parent.Nodes.Remove(_treeViewReplicants.SelectedNode);

				if (parent.Nodes.Count <= 1)
					_treeViewReplicants.Nodes.Remove(parent);
				else
				{
					fileItem = parent.Tag as FileItem;
					parent.Text = string.Format("{0} (x {1}, {2} bytes)", fileItem.Info.Name, parent.Nodes.Count, fileItem.Info.Length);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				_treeViewReplicants.EndUpdate();
			}
		}

		private void TreeViewReplicants_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					_deleteToolStripMenuItem.PerformClick();
					e.Handled = true;
					break;

				case Keys.Enter:
					_openToolStripMenuItem.PerformClick();
					e.Handled = true;
					break;

				default:
					break;
			}
		}

		private void OnlyNumbers_KeyDown(object sender, KeyEventArgs e)
		{
			_allowedDigitKey = Control.ModifierKeys != Keys.Shift
				&& ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
				|| (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
				|| e.KeyCode == Keys.Back);
		}

		private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!_allowedDigitKey)
				e.Handled = true;
		}

		private void OnlyNumbers_Leave(object sender, EventArgs e)
		{
			var textBox = sender as TextBox;
			if (string.IsNullOrWhiteSpace(textBox.Text))
				return;

			long number;
			if (!long.TryParse(textBox.Text, out number))
			{
				textBox.Focus();
				textBox.SelectAll();
			}
		}

		private void OpenContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_treeViewReplicants.SelectedNode == null)
				return;

			var fileItem = _treeViewReplicants.SelectedNode.Tag as FileItem;
			if (fileItem == null)
				return;

			string cmd = "explorer.exe";
			string args = string.Format("/select,\"{0}\"", fileItem.Path);
			Process.Start(cmd, args);
		}
	}
}
