/* This file is part of the Wii.cs Tools
 * Copyright (C) 2009 Leathl
 * 
 * Wii.cs Tools is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * Wii.cs Tools is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
        string TempPath = Path.GetTempPath() + "\\UltimateU8_Temp";
        string openfile = "";

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
        }

        private void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InfoBox(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddNodes()
        {

            tvU8.BeginUpdate();
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

                if (cbLz77.Checked == true && cbLz77.Enabled == true) u8 = Wii.Lz77.Compress(u8);

                if (rbIMD5.Checked == true)
                    u8 = Wii.U8.AddHeaderIMD5(u8);
                else if (rbIMET.Checked == true)
                {
                    ChannelNameBox.ChannelNameDialog cnd = new ChannelNameBox.ChannelNameDialog();
                    cnd.FormCaption = "Enter Channel Titles";
                    cnd.btnCancelText = "Cancel";

                    if (cnd.ShowDialog() == DialogResult.OK)
                    {
                        string[] titles = cnd.Titles;
                        u8 = Wii.U8.AddHeaderIMET(u8, titles, sizes);
                    }
                }

                Wii.Tools.SaveFileFromByteArray(u8, destination);
                InfoBox(string.Format("Successfully packed U8 archive to:\n{0}", destination));
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
                            tvU8.Nodes.Clear();
                            if (Directory.Exists(TempPath)) Directory.Delete(TempPath, true);
                            Wii.U8.UnpackU8(u8file, TempPath);
                            AddNodes();
                            openfile = u8file;
                            tvU8.ExpandAll();
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

                for (int i = 0; i < tvU8.SelectedNode.Nodes.Count; i++)
                {
                    if (tvU8.SelectedNode.Nodes[i].Text.Contains("New Folder"))
                    {
                        int thisindex = int.Parse(tvU8.SelectedNode.Nodes[i].Text.Substring(tvU8.SelectedNode.Nodes[i].Text.Length - 1));
                        if (thisindex >= index) index = thisindex + 1;
                    }
                }

                Directory.CreateDirectory(TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4) + "\\New Folder" + index.ToString());

                TreeNode newNode = new TreeNode("New Folder" + index.ToString(), 0, 0);
                tvU8.SelectedNode.Nodes.Add(newNode);

                tvU8.ExpandAll();
                tvU8.Sort();
            }
            catch { ErrorBox("An error occured"); }
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
                string destination = TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4) + "\\" + filename;

                File.Copy(ofd.FileName, destination);

                TreeNode newNode = new TreeNode(filename, 1, 1);
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
                string folder = TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4);

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
                Directory.Delete(TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4), true);
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
                string file = TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4);

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
                File.Delete(TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4));
                tvU8.SelectedNode.Remove();
            }
            catch (Exception ex) { ErrorBox(ex.Message); }
            finally { tvU8.EndUpdate(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile(openfile);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfd.FileName);
            }
        }

        private void cmFileExtract_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All|*.*";
            sfd.FileName = tvU8.SelectedNode.Text;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(TempPath + tvU8.SelectedNode.FullPath.Remove(0, 4), sfd.FileName);
            }
        }
    }
}