## Changelog of ShowMiiWads: ##

### Version 1.3b ###

  * Fixed reading and writing of japanese characters (this time really!)
  * Added Portable Mode (for varying driveletters)

### Version 1.3 ###

  * Note: License upgraded to GNU GPL v3!
  * Added extracing of BootMii NAND Dumps (Code from Ben Wilson, thanks!)
  * Batch extracting of VCPic's (VC Titles only, Png's will be resized to 192 x 112)
  * Fixed reading and writing of japanese characters
  * Fixed displaying of titles of DLC WADs

### Version 1.2 ###
  * Fixed a bug that caused ShowMiiNand not to load the List with the saved entries
  * You can replace Banner and Icon images (the resultant U8's can be Lz77 compressed!)
  * Added Dol Insertion (uses Waninkokos Nandloader)
  * Installation to Nand does now update uid.sys, if required
  * Improved Virtual Console detection to display System (NES, SNES, ...)
  * Fixed U8 Unpacking (Now works with every proper U8 archive)
  * Added batch renaming including variables, e.g. {titleid} (use 'Rename' button)
  * Added ability to Backup and Restore save data
  * Added some Tools (U8 Packing, Lz77 Compression, ...)
  * Deleted 'Pack Wad Without Trailer', just delete the trailer file if you don't want it :P
  * Bugfixes and Improvements

  * Added editing of IOS Slot		 (Note: Both these features are untested and dangerous!)
  * Added editing of Title Version (Use them at your own risk and only with BootMii/boot2!)


### Version 1.1b ###
  * Fixed a bug with slang files, so external translations can be loaded again
  * Fixed crashes caused by old ShowMiiWads.cfg Files

### Version 1.1 ###
  * 64 bit Version is now available
  * Improved speed. Now, information is loaded at application startup and saved in a file. Whenever it reloads, the information is read out of the file, only new files are added. If you need to completely refresh the whole list, use 'File -> Refresh' (F5).
  * When the language is changed, only the Channel Titles column will be reloaded
  * Multiple selections are now possible. If you want to select a whole folder, just left click the header once.
  * Added Splash Screen with ProgressBar to show the loading status (can be disabled)
  * Added Option to remove all folders
  * Added Option to refresh single folders
  * New Icon (Thanks to NeoRame!)
  * Bugfixes and tiny improvements
  * Application will now ask you to download a new version, if available
  * Italian translation added (Thanks to Tetsuo Shima)
  * Spanish translation added (Thanks to putifruti) (Incomplete, 2 sentences still Eng)
  * Norwegian translation added (Thanks to pesaroso)

### Version 1.0b ###
  * Fixed a bug where every entry was added multiple times in ShowMiiNand
  * Fixed VC / WiiWare detection (Thanks to giantpune for the hint!)
  * Added auto updatecheck at startup

### Version 1.0 ###
  * Finally got independant of external tools (saves about 3 MB)
    * All reading, editing and writing of wad and related files is now done by my own classes!
  * (common-)key.bin must now be in the application directory
  * Added ShowMiiNand (will show all installed titles on your NAND Backup)
  * Installed Titles can be packed to a Wad (ShowMiiNand)
  * Installation Queue for ShowMiiNand (drag wad files or folders onto the list and they will be queued, click install to extract them to the NAND Backup)
  * Better type detection (IOS, SysMenu, Hidden Channel, ... Unfortunately, VC / WiiWare detection returns official channel to be VC / WiiWare, so it's turned off)
  * Channel Title will be displayed depending on your language (only for embedded languages)
  * Option to add all subfolders (e.g. add C:\Wads and C:\Wads\Channel + C:\Wads\IOS + ... will be added)
  * Shared contents will now be copied (if not exist) to Nand Backup (Extract To Nand)
  * Preview of Banner and Icon (only pics, no animation of course)
    * (Some Images will be like empty, could be unsupported format (few) or they are just empty (most))
  * Added Tools Menu (Pack Wads, Unpack U8, Convert TPL, Create Common-Key)
  * French translation added (Thanks to carbonyle)
  * Added Update Check (yet only checks, but doesn't download)
  * Little bugfixes

### Version 0.3 ###
  * From-to sizes / blocks for big Wads (it was minimum size before)
  * System Titles will be shown (IOS / System Menu)
  * New columns for Type (Channel / System), Channel Title and Version
  * Extract Wads to NAND Backup (Only important files, for use with TriiForce / NAND Emulation)
  * Extract Wads to Folder (All files)
  * Added some shortcuts
  * External language files can be loaded (see example.slang)
  * Fixed a bug with the filecount label (raised with every refresh)
  * Batch changing to Region Free (all Wads in a folder)
  * Option to show either foldername or full path in groupheader
  * Export list to file (txt and csv, same file with different extension)
  * Added 'Recently Opened' folders menu
  * Changing of Channel Title (Displayed when holding cursor over a channel on wii)
    * You can also see the title for other languages by clicking
    * 'Change Channel Title'. Only the english title is displayed in the column.

### Version 0.2 ###
  * Rewrote some code, so .NET Framework 3.5 isn't needed anymore
  * Better errorhandling, invalid Wads won't be shown anymore
  * Possibility to change Title IDs
  * Possibility to change Region Flags (using freethewads.exe)
  * WadDataInfo.exe isn't needed separately anymore, it's embedded
  * Multiple folder support
  * Drag & Drop support (single or multiple files/folders)
  * Copy / Move files between folders
  * Windowsize and -location is saved
  * Some little things

### Version 0.1b ###
  * Little bugfix

### Verion 0.1: ###
  * List all Wad files of a specified folder
  * Rename Wad files
  * Delete Wad files
  * Multilanguage (English + German)
  * .NET Framework 3.5 needed for full functionality