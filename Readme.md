**ShowMiiWads is a 'WAD File Manager' for Windows.**<br>

It is licensed under GNU GPL v2, for further information scroll down to "License"<br>
The .NET-Framework 2.0 is required to run this application!<br>
The (Common-)Key.bin is required for most features (Can be created using Tools -> Create Common-Key)<br>
<br>
For further information, if you've suggestions, found bugs or anything else,<br>
visit: <a href='http://showmiiwads.googlecode.com/'>http://showmiiwads.googlecode.com/</a><br>
You can simply translate the application by editing the example.slang, if you<br>
want to have your translation included into the application, contact me..<br>
<br>
<hr />
<h2>Changelog:</h2>

<h3>Version 1.3b</h3>

<ul><li>Fixed reading and writing of japanese characters (this time really!)<br>
</li><li>Added Portable Mode (for varying driveletters)</li></ul>

<h3>Version 1.3</h3>

<ul><li>Note: License upgraded to GNU GPL v3!<br>
</li><li>Added extracing of BootMii NAND Dumps (Code from Ben Wilson, thanks!)<br>
</li><li>Batch extracting of VCPic's (VC Titles only, Png's will be resized to 192 x 112)<br>
</li><li>Fixed reading and writing of japanese characters<br>
</li><li>Fixed displaying of titles of DLC WADs</li></ul>

<h3>Version 1.2</h3>
<ul><li>Fixed a bug that caused ShowMiiNand not to load the List with the saved entries<br>
</li><li>You can replace Banner and Icon images (the resultant U8's can be Lz77 compressed!)<br>
</li><li>Added Dol Insertion (uses Waninkokos Nandloader)<br>
</li><li>Installation to Nand does now update uid.sys, if required<br>
</li><li>Improved Virtual Console detection to display System (NES, SNES, ...)<br>
</li><li>Fixed U8 Unpacking (Now works with every proper U8 archive)<br>
</li><li>Added batch renaming including variables, e.g. {titleid} (use 'Rename' button)<br>
</li><li>Added ability to Backup and Restore save data<br>
</li><li>Added some Tools (U8 Packing, Lz77 Compression, ...)<br>
</li><li>Deleted 'Pack Wad Without Trailer', just delete the trailer file if you don't want it :P<br>
</li><li>Bugfixes and Improvements</li></ul>

<ul><li>Added editing of IOS Slot		 (Note: Both these features are untested and dangerous!)<br>
</li><li>Added editing of Title Version (Use them at your own risk and only with BootMii/boot2!)</li></ul>

<h3>Version 1.1b</h3>
<ul><li>Fixed a bug with slang files, so external translations can be loaded again<br>
</li><li>Fixed crashes caused by old ShowMiiWads.cfg Files</li></ul>

<h3>Version 1.1</h3>
<ul><li>64 bit Version is now available<br>
</li><li>Improved speed. Now, information is loaded at application startup and saved in a file. Whenever it reloads, the information is read out of the file, only new files are added. If you need to completely refresh the whole list, use 'File -> Refresh' (F5).<br>
</li><li>When the language is changed, only the Channel Titles column will be reloaded<br>
</li><li>Multiple selections are now possible. If you want to select a whole folder, just left click the header once.<br>
</li><li>Added Splash Screen with ProgressBar to show the loading status (can be disabled)<br>
</li><li>Added Option to remove all folders<br>
</li><li>Added Option to refresh single folders<br>
</li><li>New Icon (Thanks to NeoRame!)<br>
</li><li>Bugfixes and tiny improvements<br>
</li><li>Application will now ask you to download a new version, if available<br>
</li><li>Italian translation added (Thanks to Tetsuo Shima)<br>
</li><li>Spanish translation added (Thanks to putifruti) (Incomplete, 2 sentences still Eng)<br>
</li><li>Norwegian translation added (Thanks to pesaroso)</li></ul>

<h3>Version 1.0b</h3>
<ul><li>Fixed a bug where every entry was added multiple times in ShowMiiNand<br>
</li><li>Fixed VC / WiiWare detection (Thanks to giantpune for the hint!)<br>
</li><li>Added auto updatecheck at startup</li></ul>

<h3>Version 1.0</h3>
<ul><li>Finally got independant of external tools (saves about 3 MB)<br>
<ul><li>All reading, editing and writing of wad and related files is now done by my own classes!<br>
</li></ul></li><li>(common-)key.bin must now be in the application directory<br>
</li><li>Added ShowMiiNand (will show all installed titles on your NAND Backup)<br>
</li><li>Installed Titles can be packed to a Wad (ShowMiiNand)<br>
</li><li>Installation Queue for ShowMiiNand (drag wad files or folders onto the list and they will be queued, click install to extract them to the NAND Backup)<br>
</li><li>Better type detection (IOS, SysMenu, Hidden Channel, ... Unfortunately, VC / WiiWare detection returns official channel to be VC / WiiWare, so it's turned off)<br>
</li><li>Channel Title will be displayed depending on your language (only for embedded languages)<br>
</li><li>Option to add all subfolders (e.g. add C:\Wads and C:\Wads\Channel + C:\Wads\IOS + ... will be added)<br>
</li><li>Shared contents will now be copied (if not exist) to Nand Backup (Extract To Nand)<br>
</li><li>Preview of Banner and Icon (only pics, no animation of course)<br>
<ul><li>(Some Images will be like empty, could be unsupported format (few) or they are just empty (most))<br>
</li></ul></li><li>Added Tools Menu (Pack Wads, Unpack U8, Convert TPL, Create Common-Key)<br>
</li><li>French translation added (Thanks to carbonyle)<br>
</li><li>Added Update Check (yet only checks, but doesn't download)<br>
</li><li>Little bugfixes</li></ul>

<h3>Version 0.3</h3>
<ul><li>From-to sizes / blocks for big Wads (it was minimum size before)<br>
</li><li>System Titles will be shown (IOS / System Menu)<br>
</li><li>New columns for Type (Channel / System), Channel Title and Version<br>
</li><li>Extract Wads to NAND Backup (Only important files, for use with TriiForce / NAND Emulation)<br>
</li><li>Extract Wads to Folder (All files)<br>
</li><li>Added some shortcuts<br>
</li><li>External language files can be loaded (see example.slang)<br>
</li><li>Fixed a bug with the filecount label (raised with every refresh)<br>
</li><li>Batch changing to Region Free (all Wads in a folder)<br>
</li><li>Option to show either foldername or full path in groupheader<br>
</li><li>Export list to file (txt and csv, same file with different extension)<br>
</li><li>Added 'Recently Opened' folders menu<br>
</li><li>Changing of Channel Title (Displayed when holding cursor over a channel on wii)<br>
<ul><li>You can also see the title for other languages by clicking<br>
</li><li>'Change Channel Title'. Only the english title is displayed in the column.</li></ul></li></ul>

<h3>Version 0.2</h3>
<ul><li>Rewrote some code, so .NET Framework 3.5 isn't needed anymore<br>
</li><li>Better errorhandling, invalid Wads won't be shown anymore<br>
</li><li>Possibility to change Title IDs<br>
</li><li>Possibility to change Region Flags (using freethewads.exe)<br>
</li><li>WadDataInfo.exe isn't needed separately anymore, it's embedded<br>
</li><li>Multiple folder support<br>
</li><li>Drag & Drop support (single or multiple files/folders)<br>
</li><li>Copy / Move files between folders<br>
</li><li>Windowsize and -location is saved<br>
</li><li>Some little things</li></ul>

<h3>Version 0.1b</h3>
<ul><li>Little bugfix</li></ul>

<h3>Verion 0.1:</h3>
<ul><li>List all Wad files of a specified folder<br>
</li><li>Rename Wad files<br>
</li><li>Delete Wad files<br>
</li><li>Multilanguage (English + German)<br>
</li><li>.NET Framework 3.5 needed for full functionality<br>
<hr />
<br>
<hr />
<h2>Disclaimer:</h2></li></ul>

Editing WAD files can result in a brick of your Wii.<br>
Only use these features if you have a bricksafe Wii, meaning either Preloader or<br>
BootMii/boot2 is installed, and if you know what you're doing.<br>
Also, your Wad files could be destroyed, so be sure to have a backup.<br>
<br>
This application comes without any express or implied warranty.<br>
The author can't be held responsible for any damages arising from the use of it.<br>
<hr />
<br>
<hr />
<h2>Thanks:</h2>

Xuzz, SquidMan, megazig, Matt_P, Omega and The Lemon Man for Wii.py (which was the base for TPL conversion)<br>
SquidMan for Zetsubou (which was a reference for TPL conversion)<br>
Andre Perrot for gbalzss (which was the base for LZ77 decompression)<br>
NeoRame for the Logo + Icon<br>
Blitzur, kedest, nutta_nic, Dteyn and acesniper for Betatesting<br>
carbonyle and Cyan for French translation<br>
Tetsuo Shima for Italian translation<br>
putifruti for Spanish translation<br>
pesaroso for Norwegian translation<br>
Everyone for using this application<br>
<hr />
<br>
<hr />
<h2>License:</h2>

Copyright (C) 2009 Leathl<br>
<br>
ShowMiiWads is free software; you can redistribute it and/or<br>
modify it under the terms of the GNU General Public License<br>
as published by the Free Software Foundation; either version 2<br>
of the License, or (at your option) any later version.<br>
<br>
ShowMiiWads is distributed in the hope that it will be useful,<br>
but WITHOUT ANY WARRANTY; without even the implied warranty of<br>
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the<br>
GNU General Public License for more details.<br>
<br>
You should have received a copy of the GNU General Public License<br>
along with this program; if not, write to the Free Software<br>
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.<br>
<hr />