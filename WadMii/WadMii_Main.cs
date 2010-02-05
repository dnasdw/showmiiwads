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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wii.cs_Tools
{
    public partial class WadMii_Main : Form
    {
        public WadMii_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = global::Wii.Properties.Resources.Wii_cs;
        }

        public WadMii_Main(string[] args)
        {
            InitializeComponent(); 
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;

            if (!File.Exists(Application.StartupPath + "\\common-key.bin") &&
                !File.Exists(Application.StartupPath + "\\key.bin"))
            {
                ErrorBox("The common-key couldn't be found and\ncan't be created in CLI Mode!");
                Environment.Exit(0);
            }

            bool trucha = false;
            string id = "";
            string input = "";
            string output = "";

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
                        case "-id":
                            id = args[i + 1].ToUpper();
                            break;
                        case "-trucha":
                            trucha = true;
                            break;
                        case "-sign":
                            trucha = true;
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
                Regex allowedchars = new Regex("[A-Z0-9]{4}$");
                if (!string.IsNullOrEmpty(id) && !allowedchars.IsMatch(id))
                {
                    ErrorBox("The Titled ID is invalid!");
                    Environment.Exit(0);
                }

                if (Directory.Exists(input)) //pack
                {
                    string[] appfiles = Directory.GetFiles(input, "*.app");
                    string[] certfile = Directory.GetFiles(input, "*.cert");
                    string[] tikfile = Directory.GetFiles(input, "*.tik");
                    string[] tmdfile = Directory.GetFiles(input, "*.tmd");

                    if (appfiles.Length > 0 &&
                        certfile.Length > 0 &&
                        tikfile.Length > 0 &&
                        tmdfile.Length > 0)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(id))
                            {
                                Wii.WadEdit.ChangeTitleID(tikfile[0], 0, id);
                                Wii.WadEdit.ChangeTitleID(tmdfile[0], 1, id);
                            }
                            else if (trucha == true)
                            {
                                Wii.WadEdit.TruchaSign(tikfile[0], 0);
                                Wii.WadEdit.TruchaSign(tmdfile[0], 1);
                            }

                            if (File.Exists(output)) File.Delete(output);
                            Wii.WadPack.PackWad(input, output);
                            MessageBox.Show("Successfully packed Wad", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (File.Exists(input)) File.Delete(output);
                            ErrorBox(ex.Message);
                        }
                    }
                    else
                    {
                        ErrorBox("At least one file is missing, the Wad cannot be packed!");
                    }
                }
                else if (File.Exists(input)) //unpack
                {
                    try
                    {
                        string[] appfiles = Directory.GetFiles(output, "*.app");
                        string[] certfile = Directory.GetFiles(output, "*.cert");
                        string[] tikfile = Directory.GetFiles(output, "*.tik");
                        string[] tmdfile = Directory.GetFiles(output, "*.tmd");

                        foreach (string appfile in appfiles)
                            File.Delete(appfile);
                        foreach (string cert in certfile)
                            File.Delete(cert);
                        foreach (string tik in tikfile)
                            File.Delete(tik);
                        foreach (string tmd in tmdfile)
                            File.Delete(tmd);

                        Wii.WadUnpack.UnpackWad(input, output);
                        MessageBox.Show("Successfully unpacked Wad", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cbChangeID.Enabled = true;
                cbTrucha.Enabled = true;
                tbID.Enabled = true;
                btnUnPack.Text = "Pack";
            }
            else
            {
                lbFolder.Text = "File:";
                lbFile.Text = "Folder:";
                cbChangeID.Enabled = false;
                cbTrucha.Enabled = false;
                tbID.Enabled = false;
                btnUnPack.Text = "Unpack";
            }

            tbFile.Text = folder;
            tbFolder.Text = file;
            tbID.Text = "";
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
                    if (tb == tbFolder && string.IsNullOrEmpty(tbFile.Text)) tbFile.Text = tbFolder.Text + ".wad";
                    if (tb == tbFile && string.IsNullOrEmpty(tbFolder.Text)) tbFolder.Text = tbFile.Text + ".wad";
                }
                catch { }
            }
        }

        private void BrowseSaveWad()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Wad Files|*.wad";
            sfd.OverwritePrompt = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = sfd.FileName;
                if (string.IsNullOrEmpty(tbFolder.Text)) tbFolder.Text = tbFile.Text.Remove(tbFile.Text.LastIndexOf('.'));
            }
        }

        private void BrowseLoadWad()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wad Files|*.wad";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = ofd.FileName;
                if (string.IsNullOrEmpty(tbFile.Text)) tbFile.Text = tbFolder.Text.Remove(tbFolder.Text.LastIndexOf('.'));
            }
        }

        private void rbPack_CheckedChanged(object sender, EventArgs e)
        {
            SwitchOver();
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
            if (cbChangeID.Checked == true)
            {
                tbID.Enabled = true;
                cbTrucha.Checked = true;
                cbTrucha.Enabled = false;
            }
            else
            {
                tbID.Enabled = false;
                cbTrucha.Enabled = true;
                cbTrucha.Checked = false;
                tbID.Text = "";
            }
        }

        private void btnUnPack_Click(object sender, EventArgs e)
        {
            bool keyexists = true;
            if (!File.Exists(Application.StartupPath + "\\common-key.bin") &&
                !File.Exists(Application.StartupPath + "\\key.bin"))
            {
                keyexists = false;
                WadMii_KeyDialog keydlg = new WadMii_KeyDialog();

                if (keydlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Wii.Tools.CreateCommonKey(keydlg.Input, Application.StartupPath);
                        keyexists = true;
                    }
                    catch (Exception ex) { ErrorBox(ex.Message); }
                }
            }

            if (keyexists == true)
            {
                if (rbPack.Checked == true)
                {
                    if (Directory.Exists(tbFolder.Text))
                    {
                        string newid = tbID.Text.ToUpper();
                        bool goodid = true;
                        if (cbChangeID.Checked == true)
                        {
                            if (tbID.Text.Length == 4)
                            {
                                Regex allowedchars = new Regex("[A-Z0-9]{4}$");
                                if (!allowedchars.IsMatch(newid))
                                {
                                    goodid = false;
                                    tbID.Focus();
                                    tbID.SelectAll();
                                    ErrorBox("The Title ID is invalid!");
                                }
                            }
                            else
                            {
                                goodid = false;
                                MessageBox.Show("Please enter a valid Title ID or uncheck the Checkbox!", "Enter Title ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        if (goodid == true)
                        {
                            bool overwrite = true;
                            if (File.Exists(tbFile.Text))
                            {
                                if (MessageBox.Show(string.Format("{0} already exists. Do you want to overwrite?", tbFile.Text.Remove(0, tbFile.Text.LastIndexOf('\\') + 1)), "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    overwrite = false;
                                else
                                    File.Delete(tbFile.Text);
                            }

                            if (overwrite == true)
                            {
                                string[] appfiles = Directory.GetFiles(tbFolder.Text, "*.app");
                                string[] certfile = Directory.GetFiles(tbFolder.Text, "*.cert");
                                string[] tikfile = Directory.GetFiles(tbFolder.Text, "*.tik");
                                string[] tmdfile = Directory.GetFiles(tbFolder.Text, "*.tmd");

                                if (appfiles.Length > 0 &&
                                    certfile.Length > 0 &&
                                    tikfile.Length > 0 &&
                                    tmdfile.Length > 0)
                                {
                                    try
                                    {
                                        if (cbChangeID.Checked == true)
                                        {
                                            Wii.WadEdit.ChangeTitleID(tikfile[0], 0, newid);
                                            Wii.WadEdit.ChangeTitleID(tmdfile[0], 1, newid);
                                        }
                                        else if (cbTrucha.Checked == true)
                                        {
                                            Wii.WadEdit.TruchaSign(tikfile[0], 0);
                                            Wii.WadEdit.TruchaSign(tmdfile[0], 1);
                                        }

                                        if (goodid == true)
                                        {
                                            Wii.WadEdit.UpdateTmdContents(tmdfile[0]);
                                            Wii.WadPack.PackWad(tbFolder.Text, tbFile.Text);
                                            MessageBox.Show("Successfully packed Wad", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (File.Exists(tbFile.Text)) File.Delete(tbFile.Text);
                                        ErrorBox(ex.Message);
                                    }
                                }
                                else
                                {
                                    ErrorBox("At least one file is missing, the Wad cannot be packed!");
                                }
                            }
                        }
                    }
                    else
                    {
                        ErrorBox("The directory to pack doesn't exist");
                    }
                }
                else
                {
                    string wadfile = tbFolder.Text;
                    string wadfolder = tbFile.Text; //I know this is confusing :P

                    if (File.Exists(wadfile))
                    {
                        if (!Directory.Exists(wadfolder)) Directory.CreateDirectory(wadfolder);
                        bool overwrite = true;

                        if (Directory.GetFiles(wadfolder, "*.app").Length > 0)
                        {
                            if (MessageBox.Show("At least one file to be unpacked might already exist.\nDo you want to overwrite?", "Overwrite?", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                overwrite = false;
                            }
                        }

                        if (overwrite == true)
                        {
                            try
                            {
                                Wii.WadUnpack.UnpackWad(wadfile, wadfolder);
                                MessageBox.Show("Successfully unpacked Wad", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex) { ErrorBox(ex.Message); }
                        }
                    }
                    else
                    {
                        ErrorBox("The Wad file doesn't exist");
                    }
                }
            }
        }
    }
}
