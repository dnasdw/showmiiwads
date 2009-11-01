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

namespace Wii.cs_Tools
{
    partial class TplMii_Main
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
            this.tbImage = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.rbToTpl = new System.Windows.Forms.RadioButton();
            this.rbToImage = new System.Windows.Forms.RadioButton();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbTpl = new System.Windows.Forms.Label();
            this.tbTpl = new System.Windows.Forms.TextBox();
            this.btnBrowseTpl = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPreview = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(58, 56);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(150, 20);
            this.tbImage.TabIndex = 3;
            this.tbImage.TextChanged += new System.EventHandler(this.tbImage_TextChanged);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(214, 56);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseImage.TabIndex = 4;
            this.btnBrowseImage.Text = "..";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // rbToTpl
            // 
            this.rbToTpl.AutoSize = true;
            this.rbToTpl.Checked = true;
            this.rbToTpl.Location = new System.Drawing.Point(14, 22);
            this.rbToTpl.Name = "rbToTpl";
            this.rbToTpl.Size = new System.Drawing.Size(84, 17);
            this.rbToTpl.TabIndex = 1;
            this.rbToTpl.TabStop = true;
            this.rbToTpl.Text = "Image to Tpl";
            this.rbToTpl.UseVisualStyleBackColor = true;
            this.rbToTpl.CheckedChanged += new System.EventHandler(this.rbToTpl_CheckedChanged);
            // 
            // rbToImage
            // 
            this.rbToImage.AutoSize = true;
            this.rbToImage.Location = new System.Drawing.Point(153, 22);
            this.rbToImage.Name = "rbToImage";
            this.rbToImage.Size = new System.Drawing.Size(84, 17);
            this.rbToImage.TabIndex = 2;
            this.rbToImage.Text = "Tpl to Image";
            this.rbToImage.UseVisualStyleBackColor = true;
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(9, 60);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(39, 13);
            this.lbImage.TabIndex = 7;
            this.lbImage.Text = "Image:";
            // 
            // lbTpl
            // 
            this.lbTpl.AutoSize = true;
            this.lbTpl.Location = new System.Drawing.Point(9, 82);
            this.lbTpl.Name = "lbTpl";
            this.lbTpl.Size = new System.Drawing.Size(25, 13);
            this.lbTpl.TabIndex = 8;
            this.lbTpl.Text = "Tpl:";
            // 
            // tbTpl
            // 
            this.tbTpl.Location = new System.Drawing.Point(58, 79);
            this.tbTpl.Name = "tbTpl";
            this.tbTpl.Size = new System.Drawing.Size(150, 20);
            this.tbTpl.TabIndex = 5;
            // 
            // btnBrowseTpl
            // 
            this.btnBrowseTpl.Location = new System.Drawing.Point(214, 79);
            this.btnBrowseTpl.Name = "btnBrowseTpl";
            this.btnBrowseTpl.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseTpl.TabIndex = 6;
            this.btnBrowseTpl.Text = "..";
            this.btnBrowseTpl.UseVisualStyleBackColor = true;
            this.btnBrowseTpl.Click += new System.EventHandler(this.btnBrowseTpl_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 178);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(225, 31);
            this.btnConvert.TabIndex = 10;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "TplMii is part of the Wii.cs Tools by Leathl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Version 0.1";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Items.AddRange(new object[] {
            "RGBA8 (High Quality)",
            "RGB565 (Moderate Quality)",
            "RGB5A3 (Low Quality)"});
            this.cmbFormat.Location = new System.Drawing.Point(57, 115);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(180, 21);
            this.cmbFormat.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Format:";
            // 
            // lbPreview
            // 
            this.lbPreview.Enabled = false;
            this.lbPreview.Location = new System.Drawing.Point(0, 143);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(255, 13);
            this.lbPreview.TabIndex = 16;
            this.lbPreview.TabStop = true;
            this.lbPreview.Text = "Preview Tpl";
            this.lbPreview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbPreview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbPreview_LinkClicked);
            // 
            // TplMii_Main
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 221);
            this.Controls.Add(this.lbPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowseTpl);
            this.Controls.Add(this.tbTpl);
            this.Controls.Add(this.lbTpl);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.rbToImage);
            this.Controls.Add(this.rbToTpl);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.tbImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TplMii_Main";
            this.Text = "TplMii - Wii.cs Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.RadioButton rbToTpl;
        private System.Windows.Forms.RadioButton rbToImage;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbTpl;
        private System.Windows.Forms.TextBox tbTpl;
        private System.Windows.Forms.Button btnBrowseTpl;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lbPreview;
    }
}

