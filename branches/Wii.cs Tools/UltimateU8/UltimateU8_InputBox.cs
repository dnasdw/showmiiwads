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

namespace UltimateU8
{
    public partial class UltimateU8_InputBox : Form
    {
        string extension = "";
        public bool isfolder = false;

        public UltimateU8_InputBox()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void UltimateU8_InputBox_Load(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 0)
            {
                try
                {
                    extension = tbInput.Text.Remove(0, tbInput.Text.LastIndexOf('.'));
                }
                catch { }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 0)
            {
                if (isfolder == false)
                    if (!tbInput.Text.Remove(0, tbInput.Text.LastIndexOf('\\') + 1).Contains("."))
                        tbInput.Text = tbInput.Text + extension;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else tbInput.Focus();
        }
    }
}
