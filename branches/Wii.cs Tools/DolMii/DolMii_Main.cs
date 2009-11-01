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
using System.Reflection;
using System.Text;

namespace Wii.cs_Tools
{
    public partial class DolMii_Main : Form
    {
        public DolMii_Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = global::DolMii.Properties.Resources.Wii_cs;
        }

        private void btnBrowseWad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wad|*.wad";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbWad.Text = ofd.FileName;
            }
        }

        private void btnBrowseDol_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Dol|*.dol";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbDol.Text = ofd.FileName;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string temppath = Path.GetTempPath() + "\\DolMii_Temp";
            if (Directory.Exists(temppath)) Directory.Delete(temppath, true);

            if (File.Exists(tbWad.Text) && File.Exists(tbDol.Text))
            {
                bool keyexists = true;
                if (!File.Exists(Application.StartupPath + "\\common-key.bin") &&
                    !File.Exists(Application.StartupPath + "\\key.bin"))
                {
                    keyexists = false;
                    DolMii_KeyDialog keydlg = new DolMii_KeyDialog();

                    if (keydlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Wii.Tools.CreateCommonKey(keydlg.Input, Application.StartupPath);
                            keyexists = true;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                
                if (keyexists == true)
                {
                    string wad = tbWad.Text;
                    string dol = tbDol.Text;

                    try
                    {
                        Wii.WadUnpack.UnpackWad(wad, temppath);

                        string[] appfiles = Directory.GetFiles(temppath, "*.app");
                        foreach (string appfile in appfiles)
                        {
                            if (!appfile.EndsWith("00000000.app"))
                                File.Delete(appfile);
                        }
                        
                        using (BinaryReader nandloader = new BinaryReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DolMii.Resources.Nandloader.app")))
                        {
                            using (FileStream fs = new FileStream(temppath + "\\00000002.app", FileMode.Create))
                            {
                                byte[] temp = nandloader.ReadBytes((int)nandloader.BaseStream.Length);
                                fs.Write(temp, 0, temp.Length);
                            }
                        }

                        File.Copy(dol, temppath + "\\00000001.app");

                        string[] tmdfile = Directory.GetFiles(temppath, "*.tmd");
                        byte[] tmd = Wii.Tools.LoadFileToByteArray(tmdfile[0]);
                        tmd = Wii.WadEdit.ChangeTmdBootIndex(tmd, 2);
                        tmd = Wii.WadEdit.ChangeTmdContentCount(tmd, 3);

                        File.Delete(tmdfile[0]);
                        using (FileStream fs = new FileStream(tmdfile[0], FileMode.Create))
                        {
                            using (BinaryReader tmdcontents = new BinaryReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("DolMii.Resources.Tmd_Contents")))
                            {
                                {
                                    byte[] tmdconts = tmdcontents.ReadBytes((int)tmdcontents.BaseStream.Length);
                                    fs.Write(tmd, 0, 484);
                                    fs.Write(tmdconts, 0, tmdconts.Length);
                                }
                            }
                        }
                        
                        Wii.WadEdit.UpdateTmdContents(tmdfile[0]);
                        Wii.WadEdit.TruchaSign(tmdfile[0], 1);

                        File.Delete(wad);
                        Wii.WadPack.PackWad(temppath, wad, true);
                        Directory.Delete(temppath, true);

                        MessageBox.Show("Successfully inserted Dol", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
            {
                MessageBox.Show("Please choose existing files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
