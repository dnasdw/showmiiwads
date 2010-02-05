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

        public U8Mii_Main(string[] args)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            string input = string.Empty;
            string output = string.Empty;
            bool lz77 = false;
            bool imd5 = false;
            bool imet = false;
            string title = string.Empty;
            string[] langtitle = new string[7];
            bool pack = true;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-input":
                            input = args[i + 1];
                            break;
                        case "-output":
                            output = args[i + 1];
                            break;
                        case "-in":
                            input = args[i + 1];
                            break;
                        case "-out":
                            output = args[i + 1];
                            break;
                        case "-imd5":
                            imd5 = true;
                            break;
                        case "-imet":
                            imet = true;
                            break;
                        case "-lz77":
                            lz77 = true;
                            break;
                        case "-title":
                            title = args[i + 1];
                            break;
                        case "-jap":
                            langtitle[0] = args[i + 1];
                            break;
                        case "-eng":
                            langtitle[1] = args[i + 1];
                            break;
                        case "-ger":
                            langtitle[2] = args[i + 1];
                            break;
                        case "-fra":
                            langtitle[3] = args[i + 1];
                            break;
                        case "-ita":
                            langtitle[4] = args[i + 1];
                            break;
                        case "-spa":
                            langtitle[5] = args[i + 1];
                            break;
                        case "-dut":
                            langtitle[6] = args[i + 1];
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
                Environment.Exit(0);
            }

            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(output))
            {
                if (imd5 == true && imet == true)
                {
                    ErrorBox("You can't attach more than one Header!");
                    Environment.Exit(0);
                }

                if (File.Exists(input))
                    pack = false;
                else if (Directory.Exists(input))
                    pack = true;
                else
                {
                    ErrorBox("The input doesn't exist!");
                    Environment.Exit(0);
                }

                if (imet == true)
                {
                    for (int j = 0; j < langtitle.Length; j++)
                    {
                        if (string.IsNullOrEmpty(langtitle[j])) langtitle[j] = title;
                    }
                    for (int y = 0; y < langtitle.Length; y++)
                    {
                        if (string.IsNullOrEmpty(langtitle[y]))
                        {
                            ErrorBox("You need to either specify a global Channel Title or one for each language to attach an IMET Header!");
                            Environment.Exit(0);
                        }
                    }
                }

                if (pack == true)
                {
                    try
                    {
                        int[] sizes = new int[3];

                        byte[] u8 = Wii.U8.PackU8(input, out sizes[0], out sizes[1], out sizes[2]);

                        if (lz77 == true && imet == false) u8 = Wii.Lz77.Compress(u8);
                        if (imd5 == true) u8 = Wii.U8.AddHeaderIMD5(u8);
                        else if (imet == true) u8 = Wii.U8.AddHeaderIMET(u8, langtitle, sizes);

                        Wii.Tools.SaveFileFromByteArray(u8, output);
                        if (imet == true && (sizes[0] == 0 || sizes[1] == 0 || sizes[2] == 0))
                            MessageBox.Show("Successfully packed U8 file\nHowever, note that this is no valid 00000000.app!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Successfully packed U8 file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { ErrorBox(ex.Message); }
                }
                else
                {
                    if (!Directory.Exists(output)) Directory.CreateDirectory(output);

                    try
                    {
                        Wii.U8.UnpackU8(input, output);
                        MessageBox.Show("Successfully unpacked U8", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { ErrorBox(ex.Message); }
                }
            }
            else
            {
                ErrorBox("Please enter input and output files!");
            }

            Environment.Exit(0);
        }

        private void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                }
                else
                {
                    ErrorBox("The directory doesn't exist");
                }
            }
            else
            {
                string u8file = tbFolder.Text;
                string u8folder = tbFile.Text; //I know this is confusing :P

                if (File.Exists(u8file))
                {
                    if (!Directory.Exists(u8folder) || Directory.GetFiles(u8folder).Length < 1)
                    {
                        if (!Directory.Exists(u8folder)) Directory.CreateDirectory(u8folder);

                        try
                        {
                            Wii.U8.UnpackU8(u8file, u8folder);
                            MessageBox.Show("Successfully unpacked U8", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                    else
                    {
                        ErrorBox("The directory already exists or is not empty.\nPlease choose an empty folder");
                    }
                }
                else
                {
                    ErrorBox("The U8 file doesn't exist");
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
