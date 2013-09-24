using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChatPainter
{
    public partial class DrawingGrid : UserControl
    {
        public bool DrawGrid { get; set; }

        private String separator = "     ";

        public int MinWidth { get; set; }
        public int MinHeight { get; set; }

        private int[,] cellIds = new int[99, 99];

        private int lastSmileX = -1;
        private int lastSmileY = 0;

        private SmileList smileList;

        private int wishWidth;
        private int wishHeight;

        private int selectedCellX = -1;
        private int selectedCellY = -1;

        public DrawingGrid()
        {
            InitializeComponent();

            wishWidth = Math.Max(this.Width / 18, MinWidth);
            wishHeight = Math.Max(this.Height / 20, MinHeight);

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    cellIds[i, j] = -1;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs ea)
        {
            base.OnPaint(ea);

            Graphics g = ea.Graphics;
            Pen gridPen = new Pen(Color.FromArgb(60, 60, 60), 1);

            for (int i = 0; i < (Width / 18); i++)
            {
                for (int j = 0; j < (Height / 20); j++)
                {
                    if (DrawGrid && (i == 0))
                    {
                        g.DrawLine(gridPen, 0, j * 20, Width - 1, j * 20);
                        g.DrawLine(gridPen, 0, ((j + 1) * 20) - 1, Width - 1, ((j + 1) * 20) - 1);
                    }

                    if ((smileList != null) && (cellIds[i, j] != -1))
                    {
                        g.DrawImage(smileList[cellIds[i, j] - 1], i * 18, (j * 20) + 1, 18, 18);
                    }
                }

                if (DrawGrid)
                {
                    g.DrawLine(gridPen, i * 18, 0, i * 18, Height - 1);
                    g.DrawLine(gridPen, ((i + 1) * 18) - 1, 0, ((i + 1) * 18) - 1, Height - 1);
                }
            }
        }

        private void RedrawCell(int x, int y)
        {
            if ((x < (Width / 18)) && (y < (Height / 20)))
            {
                Pen gridPen = new Pen(Color.FromArgb(60, 60, 60), 1);
                SolidBrush fillBrush = new SolidBrush(this.BackColor);
                Graphics g = this.CreateGraphics();

                g.FillRectangle(fillBrush, x * 18, y * 20, 18, 20);

                if (cellIds[x, y] != -1)
                {
                    g.DrawImage(smileList[cellIds[x, y] - 1], x * 18, (y * 20) + 1, 18, 18);
                }

                if (DrawGrid || ((selectedCellX == x) && (selectedCellY == y)))
                {
                    g.DrawLine(gridPen, x * 18, y * 20, ((x + 1) * 18) - 1, y * 20);
                    g.DrawLine(gridPen, x * 18, y * 20, x * 18, ((y + 1) * 20) - 1);
                    g.DrawLine(gridPen, x * 18, ((y + 1) * 20) - 1, ((x + 1) * 18) - 1, ((y + 1) * 20) - 1);
                    g.DrawLine(gridPen, ((x + 1) * 18) - 1, y * 20, ((x + 1) * 18) - 1, ((y + 1) * 20) - 1);
                }
            }
        }

        public void ClearGrid()
        {
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    cellIds[i, j] = -1;
                }
            }

            this.Invalidate();
        }

        public void SetWidth(int width)
        {
            wishWidth = Math.Max(width, MinWidth);
            UpdateSizes();
        }

        public void SetWidth(string width)
        {
            int actualWidth;

            if (Int32.TryParse(width, out actualWidth))
            {
                this.SetWidth(actualWidth);
            }
            else
            {
                this.SetWidth(1);
            }
        }

        public void SetHeight(int height)
        {
            wishHeight = Math.Max(height, MinHeight);
            UpdateSizes();
        }

        public void SetHeight(string height)
        {
            int actualHeight;

            if (Int32.TryParse(height, out actualHeight))
            {
                this.SetHeight(actualHeight);
            }
            else
            {
                this.SetHeight(1);
            }
        }

        public void UpdateSizes()
        {
            int actualWidth = wishWidth * 18;
            int actualHeight = wishHeight * 20;

            actualWidth = Math.Min(actualWidth, this.FindForm().Width - 40);
            actualWidth -= actualWidth % 18;

            actualHeight = Math.Min(actualHeight, this.FindForm().Height - 319);
            actualHeight -= actualHeight % 20;

            this.Width = actualWidth;
            this.Height = actualHeight;
        }

        public string GetSizeString()
        {
            return (Width / 18).ToString() + " x " + (Height / 20).ToString();
        }

        public void SetSmileList(SmileList smileList)
        {
            this.smileList = smileList;
        }

        public void SetCellSmile(int x, int y, int index)
        {
            if ((x >= 0) && (x < 99) && (y >= 0) && (y < 99) && ((index > 0) || (index == -1)) && (index <= smileList.GetCount()))
            {
                if (cellIds[x, y] != index)
                {
                    cellIds[x, y] = index;

                    RedrawCell(x, y);

                    if ((y > lastSmileY) || ((y == lastSmileY) && (x > lastSmileX)))
                    {
                        lastSmileX = x;
                        lastSmileY = y;
                    }
                }
            }
        }

        public int GetCellSmile(int x, int y)
        {
            if ((x >= 0) && (x < 99) && (y >= 0) && (y < 99))
            {
                return cellIds[x, y];
            }
            else
            {
                return -1;
            }
        }

        public void AddCellSmile(int index)
        {
            if ((index > 0) && (index <= smileList.GetCount()))
            {
                if (lastSmileX == ((Width / 18) - 1))
                {
                    if (lastSmileY != ((Height / 20) - 1))
                    {
                        lastSmileY++;
                        lastSmileX = 0;

                        cellIds[lastSmileX, lastSmileY] = index;

                        RedrawCell(lastSmileX, lastSmileY);
                    }
                }
                else
                {
                    lastSmileX++;

                    cellIds[lastSmileX, lastSmileY] = index;

                    RedrawCell(lastSmileX, lastSmileY);
                }
            }
        }

        public void UpdateSelectorSize(int groupBoxWidth)
        {
            int oldWidth = (Width / 18);

            int actualWidth = groupBoxWidth - 18;
            actualWidth -= actualWidth % 18;
            this.Width = actualWidth;

            int curWidth = (Width / 18);

            if (curWidth > oldWidth)
            {
                SelectCell(-1, -1);

                if (lastSmileY > 0)
                {
                    for (int i = 1; i <= lastSmileY; i++)
                    {
                        for (int j = 0; j < oldWidth; j++)
                        {
                            cellIds[j, i] = -1;
                            RedrawCell(j, i);
                        }
                    }

                    int oldLastSmileX = lastSmileX;
                    int oldLastSmileY = lastSmileY;
                    lastSmileY = 0;
                    lastSmileX = oldWidth - 1;

                    for (int i = 0; i < ((curWidth * (oldLastSmileY - 1)) + (oldLastSmileX + 1)); i++)
                    {
                        AddCellSmile(oldWidth + i + 1);
                    }
                }
            }
            else if (curWidth < oldWidth)
            {
                SelectCell(-1, -1);

                if ((lastSmileY > 0) || (lastSmileX >= curWidth))
                {
                    for (int i = curWidth; i <= lastSmileX; i++)
                    {
                        cellIds[0, i] = -1;
                    }

                    for (int i = 1; i <= lastSmileY; i++)
                    {
                        for (int j = 0; j < oldWidth; j++)
                        {
                            cellIds[j, i] = -1;
                            RedrawCell(j, i);
                        }
                    }

                    int oldLastSmileX = lastSmileX;
                    int oldLastSmileY = lastSmileY;
                    lastSmileY = 0;
                    lastSmileX = curWidth - 1;

                    for (int i = 0; i < ((oldWidth - curWidth) + ((oldWidth * (oldLastSmileY - 1)) + (oldLastSmileX + 1))); i++)
                    {
                        AddCellSmile(curWidth + i + 1);
                    }
                }
            }
        }

        public void SelectCell(int x, int y)
        {
            if ((x >= 0) && (x < 99) && (y >= 0) && (y < 99) && (cellIds[x, y] != -1))
            {
                int oldSelectedCellX = selectedCellX;
                int oldSelectedCellY = selectedCellY;

                selectedCellX = x;
                selectedCellY = y;

                if ((oldSelectedCellX != -1) && (oldSelectedCellY != -1))
                {
                    RedrawCell(oldSelectedCellX, oldSelectedCellY);
                }

                RedrawCell(x, y);
            }
            else
            {
                int oldSelectedCellX = selectedCellX;
                int oldSelectedCellY = selectedCellY;

                selectedCellX = -1;
                selectedCellY = -1;

                if ((oldSelectedCellX != -1) && (oldSelectedCellY != -1))
                {
                    RedrawCell(oldSelectedCellX, oldSelectedCellY);
                }
            }
        }

        public String GetSteamChatText()
        {
            String result;
            result = ".\n";

            int insertSeparators = 0;
            int insertLineBreaks = 0;
            bool shouldInsertSeparators = false;
            int removeStartingSeparators = 99;

            for (int y = 0; y < (Height / 20); y++)
            {
                for (int x = 0; x < (Width / 18); x++)
                {
                    if (cellIds[x, y] == -1)
                    {
                        insertSeparators++;
                    }
                    else
                    {
                        removeStartingSeparators = Math.Min(insertSeparators, removeStartingSeparators);
                        break;
                    }
                }

                insertSeparators = 0;
            }

            insertSeparators = 0;

            for (int y = 0; y < (Height / 20); y++)
            {
                for (int x = 0; x < (Width / 18); x++)
                {
                    if (cellIds[x, y] == -1)
                    {
                        insertSeparators++;
                    }
                    else
                    {
                        result += new String('\n', insertLineBreaks);
                        insertLineBreaks = 0;

                        if (shouldInsertSeparators)
                        {
                            for (int i = 0; i < insertSeparators; i++)
                            {
                                result += separator;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < (insertSeparators - removeStartingSeparators); i++)
                            {
                                result += separator;
                            }
                        }

                        insertSeparators = 0;

                        result += smileList.GetSmileName(cellIds[x, y] - 1);

                        shouldInsertSeparators = true;
                    }
                }

                insertSeparators = 0;

                shouldInsertSeparators = false;

                if (result != ".\n")
                {
                    insertLineBreaks++;
                }
            }

            return result;
        }

        public int GetSteamChatTextSize()
        {
            return GetSteamChatText().Length;
        }

        public String GetSteamChatTextSource()
        {
            return GetSteamChatText().Replace(':', ';');
        }

        public void SetSeparator(String separator)
        {
            this.separator = separator;
        }
    }
}
