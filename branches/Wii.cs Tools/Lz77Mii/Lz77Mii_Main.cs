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
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Wii.cs_Tools
{
    public partial class Lz77Mii_Main : Form
    {
        public Lz77Mii_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = global::Lz77Mii.Properties.Resources.Wii_cs;
        }

        private void SwitchOver()
        {
            if (rbCompress.Checked == true)
            {
                btnDeCompress.Text = "Compress";
            }
            else
            {
                btnDeCompress.Text = "Decompress";
            }
        }

        private void rbCompress_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOver();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbInput.Text = ofd.FileName;

                if (tbOutput.Enabled == true)
                {
                    if (rbCompress.Checked == true)
                    {
                        if (string.IsNullOrEmpty(tbOutput.Text)) tbOutput.Text = tbInput.Text.Insert(tbInput.Text.LastIndexOf('.'), "_compressed");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tbOutput.Text)) tbOutput.Text = tbInput.Text.Insert(tbInput.Text.LastIndexOf('.'), "_decompressed");
                    }
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All|*.*";
            if (!string.IsNullOrEmpty(tbInput.Text))
            {
                if (rbCompress.Checked == true)
                {
                    if (tbInput.Text.Contains("_decompressed"))
                        sfd.FileName = tbInput.Text.Replace("_decompressed", "");
                    else
                        sfd.FileName = tbInput.Text.Insert(tbInput.Text.LastIndexOf('.'), "_compressed").Remove(0, tbInput.Text.LastIndexOf('\\') + 1);
                }
                else
                {
                    if (tbInput.Text.Contains("_compressed"))
                        sfd.FileName = tbInput.Text.Replace("_compressed", "");
                    else
                        sfd.FileName = tbInput.Text.Insert(tbInput.Text.LastIndexOf('.'), "_decompressed").Remove(0, tbInput.Text.LastIndexOf('\\') + 1);
                }
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tbOutput.Text = sfd.FileName;
            }
        }

        private void cbOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOverwrite.Checked == true)
            {
                tbOutput.Enabled = false;
                tbOutput.Text = "";
                btnBrowseOutput.Enabled = false;
            }
            else
            {
                tbOutput.Enabled = true;
                btnBrowseOutput.Enabled = true;
            }
        }

        private void btnDeCompress_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbInput.Text))
            {
                string input = tbInput.Text;
                string output;
                bool overwrite = true;

                if (cbOverwrite.Checked == true)
                    output = input;
                else
                {
                    output = tbOutput.Text;

                    if (File.Exists(output))
                    {
                        if (MessageBox.Show("The output file already exists, do you want to overwrite?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            overwrite = false;
                    }
                }

                if (overwrite == true)
                {
                    try
                    {
                        if (rbCompress.Checked == true)
                        {
                            Wii.Lz77.Compress(input, output);
                            MessageBox.Show("Successfully compressed file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Wii.Lz77.Decompress(input, output);
                            MessageBox.Show("Successfully decompressed file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
            {
                MessageBox.Show("The file doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
