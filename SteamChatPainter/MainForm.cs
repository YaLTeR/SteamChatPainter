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
    public partial class MainForm : Form
    {
        private SmileList smileList;
        public SmileList SmileList
        {
            get
            {
                return smileList;
            }
        }

        private int selectedSmile = -1;

        public static bool[] IsMouseDown { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            smileList = new SmileList();
            this.mainGrid.SetSmileList(smileList);
            this.smileSelectorGrid.SetSmileList(smileList);

            IsMouseDown = new bool[2];
            IsMouseDown[0] = false;
            IsMouseDown[1] = false;
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            this.mainGrid.SetWidth(this.tbWidth.Text);
        }

        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            this.mainGrid.SetHeight(this.tbHeight.Text);
        }

        private void cbDrawGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.mainGrid.DrawGrid = this.cbDrawGrid.Checked;
            this.mainGrid.Invalidate();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.mainGrid.UpdateSizes();
            this.smileSelectorGrid.UpdateSelectorSize(smileBox.Width);
        }

        private void mainGrid_Resize(object sender, EventArgs e)
        {
            lbSize.Text = this.mainGrid.GetSizeString();
        }

        private void smileSelectorGrid_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < smileList.GetCount(); i++)
            {
                this.smileSelectorGrid.AddCellSmile(i + 1);
            }
        }

        private void btnAddSmile_Click(object sender, EventArgs e)
        {
            NewSmileDialog dialog = new NewSmileDialog();
            dialog.SetMainForm(this);
            dialog.Show();
        }

        public void AddSmileToSelector(int index)
        {
            this.smileSelectorGrid.AddCellSmile(index);
        }

        private void mainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown[Convert.ToInt32(e.Button == MouseButtons.Right)] = true;

            if (IsMouseDown[0] && selectedSmile != -1)
            {
                this.mainGrid.SetCellSmile(e.X / 18, e.Y / 20, selectedSmile);
            }
            else if (IsMouseDown[1])
            {
                this.mainGrid.SetCellSmile(e.X / 18, e.Y / 20, -1);
            }
        }

        private void mainGrid_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown[Convert.ToInt32(e.Button == MouseButtons.Right)] = false;

            int currentSize = this.mainGrid.GetSteamChatTextSize();

            lbCurrentSize.Text = String.Format("Chars: {0} / 2048", currentSize);

            if (currentSize > 2048)
            {
                lbCurrentSize.ForeColor = Color.Red;
            }
            else
            {
                lbCurrentSize.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
        }

        private void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown[0] && selectedSmile != -1)
            {
                this.mainGrid.SetCellSmile(e.X / 18, e.Y / 20, selectedSmile);
            }
            else if (IsMouseDown[1])
            {
                this.mainGrid.SetCellSmile(e.X / 18, e.Y / 20, -1);
            }
        }

        private void smileSelectorGrid_MouseClick(object sender, MouseEventArgs e)
        {
            selectedSmile = this.smileSelectorGrid.GetCellSmile(e.X / 18, e.Y / 20);
            this.smileSelectorGrid.SelectCell(e.X / 18, e.Y / 20);
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            this.mainGrid.ClearGrid();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.mainGrid.GetSteamChatText());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.mainGrid.GetSteamChatTextSource());
        }

        private void tbSeparator_TextChanged(object sender, EventArgs e)
        {
            this.mainGrid.SetSeparator(tbSeparator.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image smile;

            String[] defSmiles = { "B1", "box", "csgoa", "csgob", "csgox", "D", "p2aperture", "p2blue", "p2chell", "p2cube", "p2orange", "p2turret", "p2wheatley", "plane", "tradingcard", "tradingcardfoil" };

            foreach (String name in defSmiles)
            {
                if (!SmileDownloader.IsSmileDownloaded(name))
                {
                    if (SmileDownloader.GetOrDownloadSmile(name, out smile))
                    {
                        int index = SmileList.StoreImage(smile, name);

                        if (index != -1)
                        {
                            AddSmileToSelector(index + 1);
                        }
                    }
                }
            }
        }
    }
}
