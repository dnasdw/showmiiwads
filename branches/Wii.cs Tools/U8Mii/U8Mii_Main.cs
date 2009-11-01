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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Wii.cs_Tools
{
    public partial class U8Mii_Main : Form
    {
        public U8Mii_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = global::Wii.Properties.Resources.Wii_cs;
        }

        private void SwitchOver()
        {
            string file = tbFile.Text;
            string folder = tbFolder.Text;

            if (rbPack.Checked == true)
            {
                lbFolder.Text = "Folder:";
                lbFile.Text = "File:";
                cbHeader.Enabled = true;
                cbCompress.Enabled = true;
                btnUnPack.Text = "Pack";
            }
            else
            {
                lbFolder.Text = "File:";
                lbFile.Text = "Folder:";
                cbHeader.Enabled = false;
                cbCompress.Enabled = false;
                btnUnPack.Text = "Unpack";
            }

            tbFile.Text = folder;
            tbFolder.Text = file;
        }

        private void BrowseFolder(TextBox tb)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb.Text = fbd.SelectedPath;
                try
                {
                    if (tb == tbFolder && string.IsNullOrEmpty(tbFile.Text))
                    {
                        if (tbFolder.Text.Contains("."))
                            tbFile.Text = tbFolder.Text.Replace("_OUT", "");
                        else tbFile.Text = tbFolder.Text.Replace("_OUT", "") + ".bin";
                    }
                    if (tb == tbFile && string.IsNullOrEmpty(tbFolder.Text))
                    {
                        if (tbFile.Text.Contains("."))
                            tbFolder.Text = tbFile.Text.Replace("_OUT", "");
                        else tbFolder.Text = tbFile.Text.Replace("_OUT", "") + ".bin";
                    }
                    
                }
                catch { }
            }
        }

        private void BrowseSaveWad()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "U8 Files|*.bin;*.app;*.arc;*.u8;*.bnr|All|*.*";
            sfd.OverwritePrompt = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = sfd.FileName;
                if (string.IsNullOrEmpty(tbFolder.Text)) tbFolder.Text = tbFile.Text + "_OUT";
            }
        }

        private void BrowseLoadWad()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "U8 Files|*.bin;*.app;*.arc;*.u8;*.bnr|All|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = ofd.FileName;
                if (string.IsNullOrEmpty(tbFile.Text)) tbFile.Text = tbFolder.Text + "_OUT";
            }
        }

        private void rbPack_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOver();
        }

        private void cmbHeader_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbHeader.Enabled == true)
            {
                cmbHeader.SelectedIndex = 0;
            }
            else
            {
                cmbHeader.SelectedIndex = -1;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (rbPack.Checked == true)
            {
                BrowseFolder(tbFolder);
            }
            else
            {
                BrowseLoadWad();
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (rbPack.Checked == true)
            {
                BrowseSaveWad();
            }
            else
            {
                BrowseFolder(tbFile);
            }
        }

        private void cbChangeID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHeader.Checked == true)
            {
                cmbHeader.Enabled = true;
            }
            else
            {
                cmbHeader.Enabled = false;
                cbCompress.Enabled = true;
            }
        }

        private void btnUnPack_Click(object sender, EventArgs e)
        {
            if (rbPack.Checked == true)
            {
                if (Directory.Exists(tbFolder.Text))
                {
                    bool overwrite = true;

                    if (File.Exists(tbFile.Text))
                    {
                        if (MessageBox.Show("The file already exists, do you want to overwrite?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            overwrite = false;
                    }

                    if (overwrite == true)
                    {
                        bool compress = cbCompress.Checked;
                        int header = 0; //No Header

                        if (cmbHeader.SelectedIndex == 1) header = 2; //IMET
                        else if (cmbHeader.SelectedIndex == 0) header = 1; //IMD5

                        try
                        {
                            int[] sizes = new int[3];
                            bool reallydoit = true;

                            byte[] u8 = Wii.U8.PackU8(tbFolder.Text, out sizes[0], out sizes[1], out sizes[2]);
                            if (compress == true) u8 = Wii.Lz77.Compress(u8);

                            if (header == 1) u8 = Wii.U8.AddHeaderIMD5(u8);
                            else if (header == 2)
                            {
                                ChannelNameBox.ChannelNameDialog cnd = new ChannelNameBox.ChannelNameDialog();
                                cnd.btnCancelText = "Cancel";
                                cnd.FormCaption = "Enter Channel Titles";

                                if (cnd.ShowDialog() == DialogResult.OK)
                                {
                                    string[] titles = cnd.Titles;
                                    u8 = Wii.U8.AddHeaderIMET(u8, titles, sizes);
                                }
                                else reallydoit = false;
                            }

                            if (reallydoit == true)
                            {
                                Wii.Tools.SaveFileFromByteArray(u8, tbFile.Text);
                                if (header == 2 && (sizes[0] == 0 || sizes[1] == 0 || sizes[2] == 0))
                                    MessageBox.Show("Successfully packed U8 file\nHowever, note that this is no valid 00000000.app!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Successfully packed U8 file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    MessageBox.Show("The directory doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string u8file = tbFolder.Text;
                string u8folder = tbFile.Text; //I know this is confusing :P

                if (File.Exists(u8file))
                {
                    if (!Directory.Exists(u8folder) || Directory.GetFiles(u8folder).Length > 0)
                    {
                        if (!Directory.Exists(u8folder)) Directory.CreateDirectory(u8folder);

                        try
                        {
                            Wii.U8.UnpackU8(u8file, u8folder);
                            MessageBox.Show("Successfully unpacked U8", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("The directory already exists or is not empty.\nPlease choose an empty folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The U8 file doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHeader.SelectedIndex == 1)
            {
                cbCompress.Enabled = false;
                cbCompress.Checked = false;
            }
            else
                cbCompress.Enabled = true;
        }
    }
}
