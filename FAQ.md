# ShowMiiWads - Frequently Asked Questions #
<br>
<hr />
<h4>Question:</h4>
How do I add folders?<br>
<h4>Answer:</h4>
Either use the menu ('File -> Open') or drag one or multiple folders and or wad files onto the application.<br>
You can choose to add all subfolders that contain wad files through 'Options -> Add Subfolders'<br>
<hr />
<h4>Question:</h4>
What exactly do the columns mean?<br>
<h4>Answer:</h4>
Filename - The name of the wad file<br>
Type - The type of the channel, can be either a System Title (IOS, Menu, ...) or a Channel (System Channel, 'Normal' Channel, ...)<br>
Channel Title - The title displayed when holding the Wiimote cursor over a channel icon, stored in 7 different languages in each wad<br>
Title ID - The unique ID with which the channel will be installed, for IOS wads it's the IOS nr.<br>
Blocks - The approx. Blocks the wad will use on NAND<br>
Version - The version of the wad file<br>
Filesize - The approx. size the wad will use on NAND<br>
IOS Flag - The IOS that is required by the channel to run - If you don't have this, chances are good your channel won't work<br>
Region Flag - The region of the wad file<br>
Content - The amount of content files inside the wad<br>
Path - The path where the wad will be installed to on NAND - This is the Title ID in bytes<br>
<hr />
<h4>Question:</h4>
Some wads in my folder won't be displayed?<br>
<h4>Answer:</h4>
If a wad file is corrupted or damaged, so that it can't be read properly,<br>
it just won't be displayed.<br>
This doesn't mean that every wad file which is not displayed is corrupt.<br>
It could be an error with the application or something.<br>
<hr />
<h4>Question:</h4>
No Channel Title is displayed at all?<br>
<h4>Answer:</h4>
It might be that you don't have the (common-)key.bin in the application directory.<br>
Use 'Tools -> Create Common-Key' to create it and refresh.<br>
Also consider that System Wads and Hidden Channel don't have Channel Titles.<br>
<hr />
<h4>Question:</h4>
Why is the size a range for some wads?<br>
<h4>Answer:</h4>
The Wii uses shared contents, meaning that some wads use exactly the same content files.<br>
Having that files multiple times on NAND would be a waste of space, thus these contents are stored in /shared1/.<br>
Now, the smaller size suggests you already got all shared contents required by the wad file in your /shared1/ folder (so only non-shared contents will be installed,<br>
while the bigger size suggests that you got none of them (so all contents will be installed).<br>
<hr />
<h4>Question:</h4>
What's the Common-Key and where can I get it?<br>
<h4>Answer:</h4>
The Common-Key is needed to decrypt the Title Key of a wad file, which is used to decrypt the content.<br>
You can simply create it using 'Tools -> Create Common-Key.bin'.<br>
The Common-Key itself is NOT stored in the application. It's built using your input and some bytes that are stored encrypted.<br>
<hr />
<h4>Question:</h4>
How can I see what a Banner or Icon of a wad looks like?<br>
<h4>Answer:</h4>
Right-click the wad and 'Preview' to see the Banner and Icon images.<br>
<hr />
<h4>Question:</h4>
How can I see the installed titles of my NAND Backup?<br>
<h4>Answer:</h4>
First, set the Path to your NAND Backup ('Options -> Change NAND Backup Path'), it will be saved in the config, so you only need to do this once.<br>
Then just click 'View -> ShowMiiNand'.<br>
<hr />
<h4>Question:</h4>
How can I install titles to my NAND Backup?<br>
<h4>Answer:</h4>
In ShowMiiWads: Right-click a wad an choose 'Extract -> To NAND'.<br>
In ShowMiiNand: Either use the menu or the installation queue by dragging wads or folders onto the ShowMiiNand window.<br>
'Install' and 'Discard' will appear at the bottom of the window.<br>
<hr />
<h4>Question:</h4>
How can I delete titles from my NAND Backup?<br>
<h4>Answer:</h4>
Just right-click any installed title and use 'Delete'.<br>
<hr />
<h4>Question:</h4>
How can I pack a wad from a title on my NAND Backup?<br>
<h4>Answer:</h4>
Right-click the title and use 'Pack To Wad'. Of course, all required shared contents must be in the /shared1/ folder.<br>
<hr />
<h4>Question:</h4>
What's the difference between 'Pack Wad' and 'Pack Wad (without Trailer)'?<br>
<h4>Answer:</h4>
Most custom channels distributed on the internet have a footer inserted in the wad file.<br>
This is the so called 'trailer'. Mostly the 00.app is stored in it's decrypted form there.<br>
It's just a waste of space, so you can use the 'Pack Wad (without Trailer)' function to save some discspace.<br>
<hr />
<h4>Question:</h4>
What's the 'Unpack U8 Archive' function for?<br>
<h4>Answer:</h4>
The Wii uses so called 'U8 Archives' (Not an official name).<br>
The common U8 Archives we have to deal with are the '00000000.app', 'banner.bin' and 'icon.bin' and 'opening.bnr' (discs).<br>
Visit the WiiBrew Article for further information: <a href='http://wiibrew.org/wiki/U8_archive'>http://wiibrew.org/wiki/U8_archive</a><br>
<hr />
<h4>Question:</h4>
What's the 'Convert Tpl To Png' function good for?<br>
<h4>Answer:</h4>
If you have a Tpl somewhere and want to know what it looks like, just convert it to a Png.<br>
<hr />
<h4>Question:</h4>
I changed a wads region, but only get a blackscreen when running it<br>
<h4>Answer:</h4>
Region changing of wads won't always work - Better get a wad of your region.<br>
<hr />
<h4>Question:</h4>
I think I discovered a bug, what now?<br>
<h4>Answer:</h4>
Please be sure that it's not a corrupted wad file.<br>
If it really seems to be a bug with ShowMiiWads, report it here: <a href='http://code.google.com/p/showmiiwads/issues/list'>http://code.google.com/p/showmiiwads/issues/list</a>