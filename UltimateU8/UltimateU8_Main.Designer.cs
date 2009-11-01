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

namespace UltimateU8
{
    partial class UltimateU8_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UltimateU8_Main));
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cbLz77 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbIMET = new System.Windows.Forms.RadioButton();
            this.rbIMD5 = new System.Windows.Forms.RadioButton();
            this.rbNoHeader = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tvU8 = new System.Windows.Forms.TreeView();
            this.cmFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFolderSep = new System.Windows.Forms.ToolStripSeparator();
            this.cmFolderRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFolderDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmFileExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmFolder.SuspendLayout();
            this.cmFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "Folder Icon.png");
            this.IconList.Images.SetKeyName(1, "File Icon.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSaveAs);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.cbLz77);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(410, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 470);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 47);
            this.label4.TabIndex = 6;
            this.label4.Text = "Shortcuts:\r\nF2 - Rename\r\nDel - Delete";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(14, 116);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(110, 34);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(14, 17);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(110, 34);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cbLz77
            // 
            this.cbLz77.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbLz77.AutoSize = true;
            this.cbLz77.Location = new System.Drawing.Point(13, 328);
            this.cbLz77.Name = "cbLz77";
            this.cbLz77.Size = new System.Drawing.Size(112, 17);
            this.cbLz77.TabIndex = 2;
            this.cbLz77.Text = "Lz77 Compression";
            this.cbLz77.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbIMET);
            this.groupBox1.Controls.Add(this.rbIMD5);
            this.groupBox1.Controls.Add(this.rbNoHeader);
            this.groupBox1.Location = new System.Drawing.Point(7, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "( 00000000.app )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "( banner / icon.bin )";
            // 
            // rbIMET
            // 
            this.rbIMET.AutoSize = true;
            this.rbIMET.Location = new System.Drawing.Point(6, 96);
            this.rbIMET.Name = "rbIMET";
            this.rbIMET.Size = new System.Drawing.Size(51, 17);
            this.rbIMET.TabIndex = 2;
            this.rbIMET.Text = "IMET";
            this.rbIMET.UseVisualStyleBackColor = true;
            this.rbIMET.CheckedChanged += new System.EventHandler(this.rbIMET_CheckedChanged);
            // 
            // rbIMD5
            // 
            this.rbIMD5.AutoSize = true;
            this.rbIMD5.Location = new System.Drawing.Point(6, 58);
            this.rbIMD5.Name = "rbIMD5";
            this.rbIMD5.Size = new System.Drawing.Size(51, 17);
            this.rbIMD5.TabIndex = 1;
            this.rbIMD5.Text = "IMD5";
            this.rbIMD5.UseVisualStyleBackColor = true;
            // 
            // rbNoHeader
            // 
            this.rbNoHeader.AutoSize = true;
            this.rbNoHeader.Checked = true;
            this.rbNoHeader.Location = new System.Drawing.Point(6, 19);
            this.rbNoHeader.Name = "rbNoHeader";
            this.rbNoHeader.Size = new System.Drawing.Size(51, 17);
            this.rbNoHeader.TabIndex = 0;
            this.rbNoHeader.TabStop = true;
            this.rbNoHeader.Text = "None";
            this.rbNoHeader.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "UltimateU8 is part of \r\nthe Wii.cs Tools by Leathl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tvU8
            // 
            this.tvU8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvU8.ImageIndex = 0;
            this.tvU8.ImageList = this.IconList;
            this.tvU8.Location = new System.Drawing.Point(0, 0);
            this.tvU8.Name = "tvU8";
            this.tvU8.SelectedImageIndex = 0;
            this.tvU8.Size = new System.Drawing.Size(410, 470);
            this.tvU8.TabIndex = 0;
            this.tvU8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvU8_MouseUp);
            // 
            // cmFolder
            // 
            this.cmFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAddFolder,
            this.cmAddFile,
            this.cmFolderSep,
            this.cmFolderRename,
            this.cmFolderDelete});
            this.cmFolder.Name = "cmFolder";
            this.cmFolder.Size = new System.Drawing.Size(133, 98);
            // 
            // cmAddFolder
            // 
            this.cmAddFolder.Name = "cmAddFolder";
            this.cmAddFolder.Size = new System.Drawing.Size(132, 22);
            this.cmAddFolder.Text = "Add Folder";
            this.cmAddFolder.Click += new System.EventHandler(this.cmAddFolder_Click);
            // 
            // cmAddFile
            // 
            this.cmAddFile.Name = "cmAddFile";
            this.cmAddFile.Size = new System.Drawing.Size(132, 22);
            this.cmAddFile.Text = "Add File";
            this.cmAddFile.Click += new System.EventHandler(this.cmAddFile_Click);
            // 
            // cmFolderSep
            // 
            this.cmFolderSep.Name = "cmFolderSep";
            this.cmFolderSep.Size = new System.Drawing.Size(129, 6);
            // 
            // cmFolderRename
            // 
            this.cmFolderRename.Name = "cmFolderRename";
            this.cmFolderRename.Size = new System.Drawing.Size(132, 22);
            this.cmFolderRename.Text = "Rename";
            this.cmFolderRename.Click += new System.EventHandler(this.cmFolderRename_Click);
            // 
            // cmFolderDelete
            // 
            this.cmFolderDelete.Name = "cmFolderDelete";
            this.cmFolderDelete.Size = new System.Drawing.Size(132, 22);
            this.cmFolderDelete.Text = "Delete";
            this.cmFolderDelete.Click += new System.EventHandler(this.cmFolderDelete_Click);
            // 
            // cmFile
            // 
            this.cmFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmFileRename,
            this.cmFileDelete,
            this.toolStripSeparator2,
            this.cmFileExtract});
            this.cmFile.Name = "cmFile";
            this.cmFile.Size = new System.Drawing.Size(131, 76);
            // 
            // cmFileRename
            // 
            this.cmFileRename.Name = "cmFileRename";
            this.cmFileRename.Size = new System.Drawing.Size(130, 22);
            this.cmFileRename.Text = "Rename";
            this.cmFileRename.Click += new System.EventHandler(this.cmFileRename_Click);
            // 
            // cmFileDelete
            // 
            this.cmFileDelete.Name = "cmFileDelete";
            this.cmFileDelete.Size = new System.Drawing.Size(130, 22);
            this.cmFileDelete.Text = "Delete";
            this.cmFileDelete.Click += new System.EventHandler(this.cmFileDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // cmFileExtract
            // 
            this.cmFileExtract.Name = "cmFileExtract";
            this.cmFileExtract.Size = new System.Drawing.Size(130, 22);
            this.cmFileExtract.Text = "Extract File";
            this.cmFileExtract.Click += new System.EventHandler(this.cmFileExtract_Click);
            // 
            // UltimateU8_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(548, 470);
            this.Controls.Add(this.tvU8);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(564, 508);
            this.Name = "UltimateU8_Main";
            this.Text = "UltimateU8 - Wii.cs Tools";
            this.Load += new System.EventHandler(this.UltimateU8_Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UltimateU8_Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmFolder.ResumeLayout(false);
            this.cmFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmFolder;
        private System.Windows.Forms.ToolStripMenuItem cmAddFile;
        private System.Windows.Forms.ContextMenuStrip cmFile;
        private System.Windows.Forms.ToolStripMenuItem cmFileRename;
        private System.Windows.Forms.ToolStripMenuItem cmFileDelete;
        private System.Windows.Forms.ToolStripSeparator cmFolderSep;
        private System.Windows.Forms.ToolStripMenuItem cmFolderRename;
        private System.Windows.Forms.ToolStripMenuItem cmFolderDelete;
        private System.Windows.Forms.TreeView tvU8;
        private System.Windows.Forms.ToolStripMenuItem cmAddFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbIMET;
        private System.Windows.Forms.RadioButton rbIMD5;
        private System.Windows.Forms.RadioButton rbNoHeader;
        private System.Windows.Forms.CheckBox cbLz77;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem cmFileExtract;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label4;
    }
}

