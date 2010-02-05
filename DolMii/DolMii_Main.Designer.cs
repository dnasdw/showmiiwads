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

namespace Wii.cs_Tools
{
    partial class DolMii_Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbWad = new System.Windows.Forms.TextBox();
            this.btnBrowseWad = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbTpl = new System.Windows.Forms.Label();
            this.tbDol = new System.Windows.Forms.TextBox();
            this.btnBrowseDol = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbWad
            // 
            this.tbWad.Location = new System.Drawing.Point(58, 47);
            this.tbWad.Name = "tbWad";
            this.tbWad.Size = new System.Drawing.Size(150, 20);
            this.tbWad.TabIndex = 3;
            // 
            // btnBrowseWad
            // 
            this.btnBrowseWad.Location = new System.Drawing.Point(214, 47);
            this.btnBrowseWad.Name = "btnBrowseWad";
            this.btnBrowseWad.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseWad.TabIndex = 4;
            this.btnBrowseWad.Text = "..";
            this.btnBrowseWad.UseVisualStyleBackColor = true;
            this.btnBrowseWad.Click += new System.EventHandler(this.btnBrowseWad_Click);
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(9, 51);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(33, 13);
            this.lbImage.TabIndex = 7;
            this.lbImage.Text = "Wad:";
            // 
            // lbTpl
            // 
            this.lbTpl.AutoSize = true;
            this.lbTpl.Location = new System.Drawing.Point(9, 73);
            this.lbTpl.Name = "lbTpl";
            this.lbTpl.Size = new System.Drawing.Size(26, 13);
            this.lbTpl.TabIndex = 8;
            this.lbTpl.Text = "Dol:";
            // 
            // tbDol
            // 
            this.tbDol.Location = new System.Drawing.Point(58, 70);
            this.tbDol.Name = "tbDol";
            this.tbDol.Size = new System.Drawing.Size(150, 20);
            this.tbDol.TabIndex = 5;
            // 
            // btnBrowseDol
            // 
            this.btnBrowseDol.Location = new System.Drawing.Point(214, 70);
            this.btnBrowseDol.Name = "btnBrowseDol";
            this.btnBrowseDol.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseDol.TabIndex = 6;
            this.btnBrowseDol.Text = "..";
            this.btnBrowseDol.UseVisualStyleBackColor = true;
            this.btnBrowseDol.Click += new System.EventHandler(this.btnBrowseDol_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(12, 178);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(225, 31);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "DolMii is part of the Wii.cs Tools by Leathl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Version 0.3";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Uses Waninkoko\'s Nandloader";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DolMii_Main
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 221);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnBrowseDol);
            this.Controls.Add(this.tbDol);
            this.Controls.Add(this.lbTpl);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.btnBrowseWad);
            this.Controls.Add(this.tbWad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DolMii_Main";
            this.Text = "DolMii - Wii.cs Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWad;
        private System.Windows.Forms.Button btnBrowseWad;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbTpl;
        private System.Windows.Forms.TextBox tbDol;
        private System.Windows.Forms.Button btnBrowseDol;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

