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

        public Lz77Mii_Main(string[] args)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            string input = "";
            string output = "";
            bool compress = false;

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
                        case "-pack":
                            compress = true;
                            break;
                        case "-compress":
                            compress = true;
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
                if (File.Exists(input) == true)
                {
                    try
                    {
                        if (compress == true)
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
                    catch (Exception ex) { ErrorBox(ex.Message); }
                }
                else
                {
                    ErrorBox("The file doesn't exist!");
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
                    catch (Exception ex) { ErrorBox(ex.Message); }
                }
            }
            else
            {
                ErrorBox("The file doesn't exist");
            }
        }
    }
}
