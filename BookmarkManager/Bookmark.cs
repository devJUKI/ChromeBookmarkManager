using System;

namespace BookmarkManager
{
    public class Bookmark {
        public bool IsWebsite { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Attributes { get; set; }
        public int IndexInFolder { get; set; }

        public Bookmark(string line, int index) {
            IndexInFolder = index;

            Name = line.Split('>')[2].Split('<')[0];
            Console.WriteLine(Name);
            Attributes = line.Split(new char[] { '\"' }, 3)[2].Split('>')[0];

            string href = line.Split('\"')[1];
            IsWebsite = href.StartsWith("http");
            URL = href;
            Console.WriteLine(URL);
        }
    }
}
