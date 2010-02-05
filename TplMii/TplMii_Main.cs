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
    public partial class TplMii_Main : Form
    {
        public TplMii_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            cmbFormat.SelectedIndex = 0;
            this.Icon = global::Wii.Properties.Resources.Wii_cs;
        }

        public TplMii_Main(string[] args)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            string input = "";
            string output = "";
            int format = 6;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
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
                        case "-rgba8":
                            format = 6;
                            break;
                        case "-rgb565":
                            format = 4;
                            break;
                        case "-rgb5a3":
                            format = 5;
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
                if (File.Exists(input))
                {
                    if (input.EndsWith(".tpl")) //Tpl to Image
                    {
                        try
                        {
                            Image img = Wii.TPL.ConvertFromTPL(input);

                            switch (output.Remove(0, output.LastIndexOf('.')))
                            {
                                case ".bmp":
                                    img.Save(output, System.Drawing.Imaging.ImageFormat.Bmp);
                                    break;
                                case ".jpg":
                                    img.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    break;
                                case ".gif":
                                    img.Save(output, System.Drawing.Imaging.ImageFormat.Gif);
                                    break;
                                default:
                                    img.Save(output, System.Drawing.Imaging.ImageFormat.Png);
                                    break;
                            }
                            MessageBox.Show("Successfully converted Tpl", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                    else //Image to Tpl
                    {
                        try
                        {
                            Image img = Image.FromFile(input);
                            Wii.TPL.ConvertToTPL(img, output, format);
                            MessageBox.Show("Successfully converted to Tpl", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
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

        private void SwitchOver()
        {
            string tpltext = tbTpl.Text;
            string imagetext = tbImage.Text;

            if (rbToTpl.Checked == true)
            {
                lbTpl.Text = "Tpl:";
                lbImage.Text = "Image:";
                cmbFormat.SelectedIndex = 0;
                cmbFormat.Enabled = true;
            }
            else
            {
                lbTpl.Text = "Image:";
                lbImage.Text = "Tpl:";
                cmbFormat.Enabled = false;
                cmbFormat.SelectedIndex = -1;
            }

            tbTpl.Text = imagetext;
            tbImage.Text = tpltext;
        }

        private void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rbToTpl_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOver();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (rbToTpl.Checked == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Png|*.png|Jpg|*.jpg|Gif|*.gif|Bmp|*.bmp|All|*.png;*.jpg;*.gif;*.bmp";
                ofd.FilterIndex = 5;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbImage.Text = ofd.FileName;
                    if (string.IsNullOrEmpty(tbTpl.Text)) tbTpl.Text = tbImage.Text.Remove(tbImage.Text.LastIndexOf('.')) + ".tpl";
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Tpl|*.tpl";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbImage.Text = ofd.FileName;
                    if (string.IsNullOrEmpty(tbTpl.Text)) tbTpl.Text = tbImage.Text.Remove(tbImage.Text.LastIndexOf('.')) + ".png";
                }
            }
        }

        private void btnBrowseTpl_Click(object sender, EventArgs e)
        {
            if (rbToTpl.Checked == false)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Png|*.png|Jpg|*.jpg|Gif|*.gif|Bmp|*.bmp|All|*.png;*.jpg;*.gif;*.bmp";
                sfd.FilterIndex = 5;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    tbTpl.Text = sfd.FileName;
                    if (string.IsNullOrEmpty(tbImage.Text)) tbImage.Text = tbTpl.Text.Remove(tbTpl.Text.LastIndexOf('.')) + ".tpl";
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Tpl|*.tpl";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    tbTpl.Text = sfd.FileName;
                    if (string.IsNullOrEmpty(tbImage.Text)) tbImage.Text = tbTpl.Text.Remove(tbTpl.Text.LastIndexOf('.')) + ".png";
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (rbToTpl.Checked == true)
            {
                if (File.Exists(tbImage.Text))
                {
                    bool overwrite = true;

                    if (File.Exists(tbTpl.Text))
                        if (MessageBox.Show("The file already exists, do you want to overwrite?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            overwrite = false;

                    if (overwrite == true)
                    {
                        try
                        {
                            Image img = Image.FromFile(tbImage.Text);
                            byte[] tpl;

                            switch (cmbFormat.SelectedIndex)
                            {
                                case 1: //RGB565
                                    tpl = Wii.TPL.ConvertToTPL(img, 4);
                                    break;
                                case 2: //RGB5A3
                                    tpl = Wii.TPL.ConvertToTPL(img, 5);
                                    break;
                                default: //RGBA8
                                    tpl = Wii.TPL.ConvertToTPL(img, 6);
                                    break;
                            }

                            if (File.Exists(tbTpl.Text)) File.Delete(tbTpl.Text);
                            Wii.Tools.SaveFileFromByteArray(tpl, tbTpl.Text);
                            MessageBox.Show("Successfully converted to Tpl", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                }
                else
                {
                    ErrorBox("The Image doesn't exist");
                }
            }
            else
            {
                string tpl = tbImage.Text;
                string image = tbTpl.Text; //Again confusing, huh?

                if (File.Exists(tpl))
                {
                    bool overwrite = true;

                    if (File.Exists(image))
                        if (MessageBox.Show("The image already exists, do you want to overwrite?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            overwrite = false;
                    
                    if (overwrite == true)
                    {
                        try
                        {
                            Image img = Wii.TPL.ConvertFromTPL(tpl);

                            if (File.Exists(image)) File.Delete(image);
                            switch (image.Remove(0, image.LastIndexOf('.')))
                            {
                                case ".bmp":
                                    img.Save(image, System.Drawing.Imaging.ImageFormat.Bmp);
                                    break;
                                case ".jpg":
                                    img.Save(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    break;
                                case ".gif":
                                    img.Save(image, System.Drawing.Imaging.ImageFormat.Gif);
                                    break;
                                default:
                                    img.Save(image, System.Drawing.Imaging.ImageFormat.Png);
                                    break;
                            }
                            MessageBox.Show("Successfully converted Tpl", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { ErrorBox(ex.Message); }
                    }
                }
                else
                {
                    ErrorBox("The Tpl doesn't exist");
                }
            }
        }

        private void lbPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(tbImage.Text))
            {
                try
                {
                    Image img = Wii.TPL.ConvertFromTPL(tbImage.Text);

                    TplMii_Preview preview = new TplMii_Preview();

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
            else
            {
                ErrorBox("The Tpl file doesn't exist");
            }
        }

        private void tbImage_TextChanged(object sender, EventArgs e)
        {
            if (rbToImage.Checked == true)
            {
                if (File.Exists(tbImage.Text))
                    lbPreview.Enabled = true;
                else
                    lbPreview.Enabled = false;
            }
            else lbPreview.Enabled = false;
        }
    }
}
