using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace BookmarkManager
{
    public class Folder
    {
        public string Name { get; set; }
        public string Attributes { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<Folder> Folders { get; set; }
        public int IndexInFolder { get; set; }

        private int index;

        public Folder Parse(string[] lines) {
            int lineIdx = lines.ToList().FindIndex(x => x.Contains("<DT><H3"));
            index = 0;
            int i = 0;
            return Parse(lines, lineIdx, ref i);
        }

        private Folder Parse(string[] lines, int lineIdx, ref int endLine) {
            Bookmarks = new List<Bookmark>();
            Folders = new List<Folder>();

            Name = lines[lineIdx].Split('>')[2].Split('<')[0];
            Attributes = lines[lineIdx].Trim().Remove(0, 7).Split('>')[0];
            Console.WriteLine(Name);

            for (int i = lineIdx + 2; i < lines.Count(); i++) {
                string line = lines[i];

                // Parse another folder
                if (line.Contains("<DT><H3")) {
                    Folder folder = new Folder().Parse(lines, i, ref i);
                    folder.IndexInFolder = index;
                    Folders.Add(folder);
                }

                // Bookmark found
                if (line.Contains("HREF")) {
                    Bookmarks.Add(new Bookmark(line, index));
                }

                // End of folder
                if (line.Contains("</DL>")) {
                    endLine = i;
                    return this;
                }

                index++;
            }

            return this;
        }

        public string GetExportString() {
            int indentation = 1;

            string exportString = "<!DOCTYPE NETSCAPE-Bookmark-file-1>\r\n<!-- This is an automatically generated file.\r\n     It will be read and overwritten.\r\n     DO NOT EDIT! -->\r\n<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=UTF-8\">\r\n<TITLE>Bookmarks</TITLE>\r\n<H1>Bookmarks</H1>\r\n<DL><p>\r\n";
            exportString += GetExportString(ref indentation);
            exportString += "</DL><p>";

            return exportString;
        }

        // Isaugoti ir folderio indeksa ir tikrinti kuris arciau dabartinio.
        // Jei exactly dabartinio nera - deti artimiausia, nes praeitas buvo istrintas
        public string GetExportString(ref int indentation) {
            string exportString = "";
            int spaceWidth = 4;

            // Print folder info
            exportString += new string(' ', spaceWidth * indentation);
            exportString += "<DT><H3" + Attributes + ">" + Name + "</H3>\n";
            exportString += new string(' ', spaceWidth * indentation);
            exportString += "<DL><p>\n";
            indentation++;

            int index = 0;
            int exportedBookmarks = 0;
            int exportedFolders = 0;

            // Print folder content
            while (exportedFolders < Folders.Count || exportedBookmarks < Bookmarks.Count) {
                int bookmarkIdxInFolder = -1;
                int folderIdxInFolder = -1;

                if (exportedBookmarks < Bookmarks.Count)
                    bookmarkIdxInFolder = Bookmarks[exportedBookmarks].IndexInFolder;

                if (exportedFolders < Folders.Count)
                    folderIdxInFolder = Folders[exportedFolders].IndexInFolder;

                if (folderIdxInFolder < 0) {
                    exportString += new string(' ', spaceWidth * indentation);
                    // Check if attributes already have space at the start
                    exportString += "<DT><A HREF=\"" + Bookmarks[exportedBookmarks].URL + "\"" +
                        Bookmarks[exportedBookmarks].Attributes + ">" + Bookmarks[exportedBookmarks].Name + "</A>\n";
                    exportedBookmarks++;

                    continue;
                }

                if (bookmarkIdxInFolder < 0) {
                    exportString += Folders[exportedFolders].GetExportString(ref indentation);
                    exportedFolders++;

                    continue;
                }

                if (bookmarkIdxInFolder < folderIdxInFolder) {
                    exportString += new string(' ', spaceWidth * indentation);
                    // Check if attributes already have space at the start
                    exportString += "<DT><A HREF=\"" + Bookmarks[exportedBookmarks].URL + "\"" +
                        Bookmarks[exportedBookmarks].Attributes + ">" + Bookmarks[exportedBookmarks].Name + "</A>\n";
                    exportedBookmarks++;
                }
                else {
                    exportString += Folders[exportedFolders].GetExportString(ref indentation);
                    exportedFolders++;
                }

                index++;
            }

            indentation--;
            exportString += new string(' ', spaceWidth * indentation);
            exportString += "</DL><p>\n";

            return exportString;
        }
    }
}
