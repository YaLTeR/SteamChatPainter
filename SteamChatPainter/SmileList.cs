using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamChatPainter
{
    public class SmileList
    {
        private ArrayList smiles = new ArrayList();
        private ArrayList smileNames = new ArrayList();

        public SmileList()
        {
            if (!Directory.Exists(SmileDownloader.SmileDirName))
            {
                Directory.CreateDirectory(SmileDownloader.SmileDirName);
            }

            string[] images = Directory.GetFiles(SmileDownloader.SmileDirName + Path.DirectorySeparatorChar, "*.png");

            foreach (string imageName in images)
            {
                Image image = Image.FromFile(imageName);
                if ((image.Width == 18) && (image.Height == 18))
                {
                    smiles.Add(image);
                    smileNames.Add(Path.GetFileNameWithoutExtension(imageName));
                }
            }
        }

        public Image this[int index]
        {
            get
            {
                return (Image) smiles[index];
            }
        }

        public int StoreImage(Image image, String name)
        {
            if (image != null)
            {
                smileNames.Add(name);
                return smiles.Add(image);
            }

            return -1;
        }

        public int GetCount()
        {
            return smiles.Count;
        }

        public String GetSmileName(int index)
        {
            if ((index >= 0) && (index < smileNames.Count))
            {
                return ":" + smileNames[index] + ":";
            }
            else
            {
                return "";
            }
        }
    }
}
