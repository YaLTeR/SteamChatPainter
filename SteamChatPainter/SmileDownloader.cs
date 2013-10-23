using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChatPainter
{
    public static class SmileDownloader
    {
        private const String smileDirName = "smiles";
        public static String SmileDirName
        {
            get
            {
                return smileDirName;
            }
        }

        public static bool GetSmileStream(String smileUrl, out Stream smileStream)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(smileUrl);
            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                smileStream = null;
                return false;
            }

            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                smileStream = response.GetResponseStream();
                return true;
            }
            
            smileStream = null;
            return false;
        }

        public static bool DownloadSmile(String smileUrl, out Image smileImage)
        {
            Stream smileStream;

            if (GetSmileStream(smileUrl, out smileStream))
            {
                smileImage = Image.FromStream(smileStream);
                return true;
            }

            smileImage = null;
            return false;
        }

        public static bool GetOrDownloadSmile(String smileName, out Image smile)
        {
            smileName = smileName.Trim(':');

            if (IsSmileDownloaded(smileName))
            {
                smile = Image.FromFile(smileDirName + Path.DirectorySeparatorChar + smileName + ".png");
                return true;
            }
            else
            {
//                MessageBox.Show("Smile image does not exist, downloading...");

                if (DownloadSmile("http://cdn.steamcommunity.com/economy/emoticon/" + smileName, out smile))
                {
                    smile.Save(smileDirName + Path.DirectorySeparatorChar + smileName + ".png");
                    return true;
                }
                else
                {
                    MessageBox.Show("Could not download the :{0}: smile!", smileName);
                }
            }

            smile = null;
            return false;
        }

        public static bool IsSmileDownloaded(String smileName)
        {
            return File.Exists(smileDirName + Path.DirectorySeparatorChar + smileName + ".png");
        }
    }
}
