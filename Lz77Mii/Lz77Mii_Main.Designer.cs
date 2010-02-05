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
    partial class Lz77Mii_Main
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.rbCompress = new System.Windows.Forms.RadioButton();
            this.rbDecompress = new System.Windows.Forms.RadioButton();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbTpl = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnDeCompress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOverwrite = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(58, 56);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(150, 20);
            this.tbInput.TabIndex = 3;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(214, 56);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseInput.TabIndex = 4;
            this.btnBrowseInput.Text = "..";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // rbCompress
            // 
            this.rbCompress.AutoSize = true;
            this.rbCompress.Checked = true;
            this.rbCompress.Location = new System.Drawing.Point(34, 22);
            this.rbCompress.Name = "rbCompress";
            this.rbCompress.Size = new System.Drawing.Size(71, 17);
            this.rbCompress.TabIndex = 1;
            this.rbCompress.TabStop = true;
            this.rbCompress.Text = "Compress";
            this.rbCompress.UseVisualStyleBackColor = true;
            this.rbCompress.CheckedChanged += new System.EventHandler(this.rbCompress_CheckedChanged);
            // 
            // rbDecompress
            // 
            this.rbDecompress.AutoSize = true;
            this.rbDecompress.Location = new System.Drawing.Point(133, 22);
            this.rbDecompress.Name = "rbDecompress";
            this.rbDecompress.Size = new System.Drawing.Size(84, 17);
            this.rbDecompress.TabIndex = 2;
            this.rbDecompress.Text = "Decompress";
            this.rbDecompress.UseVisualStyleBackColor = true;
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(9, 60);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(34, 13);
            this.lbImage.TabIndex = 7;
            this.lbImage.Text = "Input:";
            // 
            // lbTpl
            // 
            this.lbTpl.AutoSize = true;
            this.lbTpl.Location = new System.Drawing.Point(9, 82);
            this.lbTpl.Name = "lbTpl";
            this.lbTpl.Size = new System.Drawing.Size(42, 13);
            this.lbTpl.TabIndex = 8;
            this.lbTpl.Text = "Output:";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(58, 79);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(150, 20);
            this.tbOutput.TabIndex = 5;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(214, 79);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(23, 20);
            this.btnBrowseOutput.TabIndex = 6;
            this.btnBrowseOutput.Text = "..";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnDeCompress
            // 
            this.btnDeCompress.Location = new System.Drawing.Point(12, 178);
            this.btnDeCompress.Name = "btnDeCompress";
            this.btnDeCompress.Size = new System.Drawing.Size(225, 31);
            this.btnDeCompress.TabIndex = 10;
            this.btnDeCompress.Text = "Compress";
            this.btnDeCompress.UseVisualStyleBackColor = true;
            this.btnDeCompress.Click += new System.EventHandler(this.btnDeCompress_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lz77Mii is part of the Wii.cs Tools by Leathl";
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
            // cbOverwrite
            // 
            this.cbOverwrite.AutoSize = true;
            this.cbOverwrite.Location = new System.Drawing.Point(12, 125);
            this.cbOverwrite.Name = "cbOverwrite";
            this.cbOverwrite.Size = new System.Drawing.Size(117, 17);
            this.cbOverwrite.TabIndex = 17;
            this.cbOverwrite.Text = "Overwrite Input File";
            this.cbOverwrite.UseVisualStyleBackColor = true;
            this.cbOverwrite.CheckedChanged += new System.EventHandler(this.cbOverwrite_CheckedChanged);
            // 
            // Lz77Mii_Main
            // 
            this.AcceptButton = this.btnDeCompress;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 221);
            this.Controls.Add(this.cbOverwrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeCompress);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.lbTpl);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.rbDecompress);
            this.Controls.Add(this.rbCompress);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.tbInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lz77Mii_Main";
            this.Text = "Lz77Mii - Wii.cs Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.RadioButton rbCompress;
        private System.Windows.Forms.RadioButton rbDecompress;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbTpl;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnDeCompress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbOverwrite;
    }
}

