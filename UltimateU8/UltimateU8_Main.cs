/* This file is part of Wii.cs Tools
 * Copyright (C) 2009 Leathl
 * 
 * Wii.cs Tools is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Wii.cs Tools is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace UltimateU8
{
    public partial class UltimateU8_Main : Form
    {
        string TempPath = Path.GetTempPath() + "UltimateU8_Temp";
        string OpenFile = "";
        string TempExtension = "";
        string TempFile = "";
        string[] TempChannelTitles = new string[7];


        public UltimateU8_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = global::UltimateU8.Properties.Resources.Wii_cs;
        }

        private void UltimateU8_Main_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(TempPath)) try { Directory.Delete(TempPath, true); }
                catch { }
            if (File.Exists(TempFile)) try { File.Delete(TempFile); }
                catch { }

            tvU8.KeyUp += new KeyEventHandler(UltimateU8_Main_KeyUp);
        }

        void UltimateU8_Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (tvU8.SelectedNode != null)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (tvU8.SelectedNode.ImageIndex == 0) //folder
                    {
                        cmFolderRename_Click(null, null);
                    }
                    else if (tvU8.SelectedNode.ImageIndex == 1) //file
                    {
                        cmFileRename_Click(null, null);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (tvU8.SelectedNode.ImageIndex == 0) //folder
                    {
                        cmFolderDelete_Click(null, null);
                    }
                    else if (tvU8.SelectedNode.ImageIndex == 1) //file
                    {
                        cmFileDelete_Click(null, null);
                    }
                }
            }
        }

        private void UltimateU8_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(TempPath)) try { Directory.Delete(TempPath, true); }
                catch { }
            if (File.Exists(TempFile)) try { File.Delete(TempFile); }
                catch { }

        }

        private void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InfoBox(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetNodePath(TreeNode node)
        {
            if (node.FullPath.Length < 5) return TempPath;
            else return               
                TempPath + "\\" + node.FullPath.Remove(0, 5);
        }

        private void AddNodes()
        {

            tvU8.BeginUpdate();
            tvU8.Nodes.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(TempPath);
            TreeNode node = new TreeNode("Root");
            AddNodes(dirInfo, node);
            tvU8.Nodes.Add(node);
            tvU8.EndUpdate();
        }

        private void AddNodes(DirectoryInfo dirinfo, TreeNode node)
        {
            DirectoryInfo[] mainDir = dirinfo.GetDirectories();
            if (mainDir.Length > 0)
            {
                foreach (DirectoryInfo subDir in mainDir)
                {
                    TreeNode newNode = new TreeNode(subDir.Name, 0, 0);
                    node.Nodes.Add(newNode);
                    AddNodes(subDir, newNode);
                }

            }

            FileInfo[] subfileInfo = dirinfo.GetFiles("*.*");

            if (subfileInfo.Length > 0)
            {
                for (int j = 0; j < subfileInfo.Length; j++)
                {
                    TreeNode newNode = new TreeNode(subfileInfo[j].Name, 1, 1);
                    if (Wii.U8.CheckU8(subfileInfo[j].FullName)) newNode.Tag = "U8";
                    if (subfileInfo[j].Name.EndsWith(".tpl")) newNode.Tag = "TPL";
                    node.Nodes.Add(newNode);
                }
            }
        }

        private List<TreeNode> GetAllNodes()
        {
            List<TreeNode> treelist = new List<TreeNode>();
            GetAllNodes(tvU8, treelist);
            return treelist;
        }

        private void GetAllNodes(TreeView treeview, List<TreeNode> nodelist)
        {
            foreach (TreeNode childNode in treeview.Nodes)
            {
                nodelist.Add(childNode);
                GetAllNodes(childNode, nodelist);
            }
        }

        private void GetAllNodes(TreeNode parent, List<TreeNode> nodelist)
        {
            foreach (TreeNode childNode in parent.Nodes)
            {
                nodelist.Add(childNode);
                GetAllNodes(childNode, nodelist);
            }
        }

        private void SaveFile(string destination)
        {
            try
            {
                int[] sizes = new int[3];
                byte[] u8 = Wii.U8.PackU8(TempPath, out sizes[0], out sizes[1], out sizes[2]);
                bool reallydoit = true;

                if (cbLz77.Checked == true && cbLz77.Enabled == true) u8 = Wii.Lz77.Compress(u8);

                if (rbIMD5.Checked == true)
                    u8 = Wii.U8.AddHeaderIMD5(u8);
                else if (rbIMET.Checked == true)
                {
                    ChannelNameBox.ChannelNameDialog cnd = new ChannelNameBox.ChannelNameDialog();
                    cnd.Titles = TempChannelTitles;
                    cnd.FormCaption = "Enter Channel Titles";
                    cnd.btnCancelText = "Cancel";

                    if (cnd.ShowDialog() == DialogResult.OK)
                    {
                        string[] titles = cnd.Titles;
                        u8 = Wii.U8.AddHeaderIMET(u8, titles, sizes);
                    }
                    else reallydoit = false;
                }

                if (reallydoit == true)
                {
                    Wii.Tools.SaveFileFromByteArray(u8, destination);
                    InfoBox(string.Format("Successfully packed U8 archive to:\n{0}", destination));
                }
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool cont = true;
            if (tvU8.Nodes.Count > 0)
            {
                if (MessageBox.Show("The currently opened file will be closed, do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    cont = false;
            }

            if (cont == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "U8 Archives|*.arc;*.bin;*.app;*.bnr;*.u8|All|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tvU8.BeginUpdate();
                    string u8file = ofd.FileName;

                    if (Wii.U8.CheckU8(u8file) == true)
                    {
                        try
                        {
                            if (Directory.Exists(TempPath)) Directory.Delete(TempPath, true);
                            Wii.U8.UnpackU8(u8file, TempPath);
                            AddNodes();
                            tvU8.ExpandAll();
                            OpenFile = u8file;
                            TempExtension = "";
                            TempChannelTitles = new string[7];

                            switch (Wii.U8.DetectHeader(u8file))
                            {
                                case 1:
                                    rbIMD5.Checked = true;
                                    break;
                                case 2:
                                    rbIMET.Checked = true;
                                    TempChannelTitles = Wii.WadInfo.GetChannelTitlesFromApp(u8file);
                                    break;
                                default:
                                    rbNoHeader.Checked = true;
                                    break;
                            }
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                    else
                    {
                        ErrorBox("It seems that the file is no valid U8 archive!");
                    }
                    tvU8.EndUpdate();
                }
            }
        }

        private void tvU8_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvU8.BeginUpdate();
                Point p = new Point(e.X, e.Y);
                TreeNode selectednode = tvU8.GetNodeAt(p);

                if (selectednode != null)
                {
                    tvU8.SelectedNode = selectednode;
                    
                    cmFolderRename.Visible = true;
                    cmFolderDelete.Visible = true;
                    cmFolderSep.Visible = true;

                    if (selectednode.Text == "Root" && selectednode.Parent == null) //root
                    {
                        cmFolderRename.Visible = false;
                        cmFolderDelete.Visible = false;
                        cmFolderSep.Visible = false;
                        cmFolder.Show(MousePosition);
                    }
                    else if (selectednode.ImageIndex == 0) //folder
                    {
                        cmFolder.Show(MousePosition);
                    }
                    else if (selectednode.ImageIndex == 1) //file
                    {
                        if (selectednode.Tag == (object)"U8") cmOpenFile.Visible = true;
                        else cmOpenFile.Visible = false;

                        if (selectednode.Tag == (object)"TPL") cmPreview.Visible = true;
                        else cmPreview.Visible = false;

                        cmFile.Show(MousePosition);
                    }
                }
                tvU8.EndUpdate();
            }
        }

        private void rbIMET_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIMET.Checked == true)
                cbLz77.Enabled = false;
            else
                cbLz77.Enabled = true;
        }

        private void cmAddFolder_Click(object sender, EventArgs e)
        {
            try
            {
                tvU8.BeginUpdate();
                int index = 1;
                bool exists = false;
                string newfolder = "";

                do
                {
                    newfolder = "New Folder" + index.ToString();
                    exists = false;

                    for (int i = 0; i < tvU8.SelectedNode.Nodes.Count; i++)
                    {
                        if (tvU8.SelectedNode.Nodes[i].Text == newfolder)
                        {
                            index++;
                            exists = true;
                        }
                    }

                } while (exists == true);

                Directory.CreateDirectory(GetNodePath(tvU8.SelectedNode) + "\\New Folder" + index.ToString());

                TreeNode newNode = new TreeNode("New Folder" + index.ToString(), 0, 0);
                tvU8.SelectedNode.Nodes.Add(newNode);

                tvU8.ExpandAll();
                tvU8.Sort();
            }
            catch (Exception ex){ ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void cmAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tvU8.BeginUpdate();
                string filename = ofd.FileName.Remove(0, ofd.FileName.LastIndexOf('\\') + 1);
                string destination = GetNodePath(tvU8.SelectedNode) + "\\" + filename;

                File.Copy(ofd.FileName, destination);

                TreeNode newNode = new TreeNode(filename, 1, 1);
                if (Wii.U8.CheckU8(destination)) newNode.Tag = "U8";
                if (destination.EndsWith(".tpl")) newNode.Tag = "TPL";
                tvU8.SelectedNode.Nodes.Add(newNode);
                tvU8.Sort();
                tvU8.EndUpdate();
            }
        }

        private void cmFolderRename_Click(object sender, EventArgs e)
        {
            try
            {
                tvU8.BeginUpdate();
                string folder = GetNodePath(tvU8.SelectedNode);

                UltimateU8_InputBox ib = new UltimateU8_InputBox();
                ib.isfolder = true;
                ib.tbInput.Text = folder.Remove(0, folder.LastIndexOf('\\') + 1);

                if (ib.ShowDialog() == DialogResult.OK)
                {
                    Directory.Move(folder, folder.Remove(folder.LastIndexOf('\\') + 1) + ib.tbInput.Text);
                    tvU8.SelectedNode.Text = ib.tbInput.Text;
                }
                tvU8.Sort();
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void cmFolderDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tvU8.BeginUpdate();
                Directory.Delete(GetNodePath(tvU8.SelectedNode), true);
                tvU8.SelectedNode.Remove();
                tvU8.Sort();
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void cmFileRename_Click(object sender, EventArgs e)
        {
            try
            {
                tvU8.BeginUpdate();
                string file = GetNodePath(tvU8.SelectedNode);

                UltimateU8_InputBox ib = new UltimateU8_InputBox();
                ib.isfolder = false;
                ib.tbInput.Text = file.Remove(0, file.LastIndexOf('\\') + 1);

                if (ib.ShowDialog() == DialogResult.OK)
                {
                    File.Move(file, file.Remove(file.LastIndexOf('\\') + 1) + ib.tbInput.Text);
                    tvU8.SelectedNode.Text = ib.tbInput.Text;
                }
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void cmFileDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tvU8.BeginUpdate();
                File.Delete(GetNodePath(tvU8.SelectedNode));
                tvU8.SelectedNode.Remove();
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OpenFile.EndsWith(".temp") && !string.IsNullOrEmpty(TempExtension))
                btnSaveAs_Click((object)"Temp", null);
            else
                SaveFile(OpenFile);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All|*.*";

            if (sender == (object)"Temp" || (OpenFile.EndsWith(".temp") && !string.IsNullOrEmpty(TempExtension))) 
                sfd.FileName = OpenFile.Replace(".temp", TempExtension).Remove(0, OpenFile.LastIndexOf('\\') + 1);
            else sfd.FileName = OpenFile.Remove(0, OpenFile.LastIndexOf('\\') + 1);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfd.FileName);
            }
        }

        private void cmFileExtract_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All|*.*";
            sfd.FileName = tvU8.SelectedNode.Text.Replace(".temp", "");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(GetNodePath(tvU8.SelectedNode), sfd.FileName);
            }
        }

        private void cmOpenFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close the current file and open the selected one, do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string tempfile = Path.GetTempPath() + tvU8.SelectedNode.Text.Remove(tvU8.SelectedNode.Text.LastIndexOf('.')) + ".temp";
                    TempExtension = tvU8.SelectedNode.Text.Remove(0, tvU8.SelectedNode.Text.LastIndexOf('.'));
                    
                    if (File.Exists(TempFile)) File.Delete(TempFile);
                    if (File.Exists(tempfile)) File.Delete(tempfile);
                    TempFile = tempfile;
                    OpenFile = tempfile;
                    File.Copy(GetNodePath(tvU8.SelectedNode), tempfile);

                    if (Directory.Exists(TempPath)) Directory.Delete(TempPath, true);
                    Wii.U8.UnpackU8(tempfile, TempPath);
                    AddNodes();
                    tvU8.ExpandAll();
                    TempChannelTitles = new string[7];

                    switch (Wii.U8.DetectHeader(tempfile))
                    {
                        case 1:
                            rbIMD5.Checked = true;
                            break;
                        case 2:
                            rbIMET.Checked = true;
                            TempChannelTitles = Wii.WadInfo.GetChannelTitlesFromApp(tempfile);
                            break;
                        default:
                            rbNoHeader.Checked = true;
                            break;
                    }
                }
                catch (Exception ex) { ErrorBox(ex.Message); }
            }
        }

        private void cmPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = Wii.TPL.ConvertFromTPL(GetNodePath(tvU8.SelectedNode));

                Wii.UltimateU8_Preview preview = new Wii.UltimateU8_Preview();

                if (img.Height > 150)
                    preview.Height = img.Height + 50;
                else
                    preview.Height = 200;

                if (img.Width > 150)
                    preview.Width = img.Width + 50;
                else
                    preview.Width = 200;

                preview.pbImage.Image = img;

                preview.ShowDialog();
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
        }
    }
}