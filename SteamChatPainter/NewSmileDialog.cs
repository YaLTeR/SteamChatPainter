using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChatPainter
{
    public partial class NewSmileDialog : Form
    {
        private MainForm mainForm;

        public NewSmileDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                MessageBox.Show("Error: mainForm is null!");
                return;
            }

            String smileName = tbSmileName.Text;
            smileName = smileName.Trim(':');

            if (smileName.Length > 0)
            {
                if (!SmileDownloader.IsSmileDownloaded(smileName))
                {
                    Image smile = null;
                    if (!SmileDownloader.GetOrDownloadSmile(smileName, out smile))
                    {
                        return;
                    }

                    int index = mainForm.SmileList.StoreImage(smile, smileName);

                    if (index != -1)
                    {
                        mainForm.AddSmileToSelector(index + 1);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("This smile is already downloaded!");
                }
            }
        }

        public void SetMainForm(MainForm form)
        {
            mainForm = form;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
