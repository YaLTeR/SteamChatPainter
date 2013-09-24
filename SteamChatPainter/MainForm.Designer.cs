namespace SteamChatPainter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.cbDrawGrid = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.smileBox = new System.Windows.Forms.GroupBox();
            this.smileSelectorGrid = new SteamChatPainter.DrawingGrid();
            this.btnAddSmile = new System.Windows.Forms.Button();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lbCurrentSize = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainGrid = new SteamChatPainter.DrawingGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.smileBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWidth
            // 
            this.tbWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbWidth.Location = new System.Drawing.Point(13, 259);
            this.tbWidth.MaxLength = 2;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(29, 20);
            this.tbWidth.TabIndex = 1;
            this.tbWidth.Text = "12";
            this.tbWidth.TextChanged += new System.EventHandler(this.tbWidth_TextChanged);
            // 
            // tbHeight
            // 
            this.tbHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHeight.Location = new System.Drawing.Point(66, 259);
            this.tbHeight.MaxLength = 2;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(28, 20);
            this.tbHeight.TabIndex = 2;
            this.tbHeight.Text = "12";
            this.tbHeight.TextChanged += new System.EventHandler(this.tbHeight_TextChanged);
            // 
            // cbDrawGrid
            // 
            this.cbDrawGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDrawGrid.AutoSize = true;
            this.cbDrawGrid.Checked = true;
            this.cbDrawGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawGrid.Location = new System.Drawing.Point(100, 261);
            this.cbDrawGrid.Name = "cbDrawGrid";
            this.cbDrawGrid.Size = new System.Drawing.Size(71, 17);
            this.cbDrawGrid.TabIndex = 3;
            this.cbDrawGrid.Text = "Draw grid";
            this.cbDrawGrid.UseVisualStyleBackColor = true;
            this.cbDrawGrid.CheckedChanged += new System.EventHandler(this.cbDrawGrid_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "x";
            // 
            // lbSize
            // 
            this.lbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(187, 266);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(42, 13);
            this.lbSize.TabIndex = 6;
            this.lbSize.Text = "12 x 12";
            this.lbSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // smileBox
            // 
            this.smileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smileBox.Controls.Add(this.smileSelectorGrid);
            this.smileBox.Location = new System.Drawing.Point(12, 302);
            this.smileBox.Name = "smileBox";
            this.smileBox.Size = new System.Drawing.Size(216, 133);
            this.smileBox.TabIndex = 8;
            this.smileBox.TabStop = false;
            this.smileBox.Text = "Smiles";
            // 
            // smileSelectorGrid
            // 
            this.smileSelectorGrid.BackColor = System.Drawing.SystemColors.Control;
            this.smileSelectorGrid.DrawGrid = false;
            this.smileSelectorGrid.Location = new System.Drawing.Point(10, 19);
            this.smileSelectorGrid.MinHeight = 11;
            this.smileSelectorGrid.MinimumSize = new System.Drawing.Size(18, 20);
            this.smileSelectorGrid.MinWidth = 5;
            this.smileSelectorGrid.Name = "smileSelectorGrid";
            this.smileSelectorGrid.Size = new System.Drawing.Size(198, 100);
            this.smileSelectorGrid.TabIndex = 0;
            this.smileSelectorGrid.Load += new System.EventHandler(this.smileSelectorGrid_Load);
            this.smileSelectorGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.smileSelectorGrid_MouseClick);
            // 
            // btnAddSmile
            // 
            this.btnAddSmile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSmile.Location = new System.Drawing.Point(12, 441);
            this.btnAddSmile.Name = "btnAddSmile";
            this.btnAddSmile.Size = new System.Drawing.Size(75, 39);
            this.btnAddSmile.TabIndex = 9;
            this.btnAddSmile.Text = "Add smile";
            this.btnAddSmile.UseVisualStyleBackColor = true;
            this.btnAddSmile.Click += new System.EventHandler(this.btnAddSmile_Click);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearGrid.Location = new System.Drawing.Point(93, 441);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(75, 39);
            this.btnClearGrid.TabIndex = 10;
            this.btnClearGrid.Text = "Clear grid";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(174, 441);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(54, 39);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lbCurrentSize
            // 
            this.lbCurrentSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCurrentSize.AutoSize = true;
            this.lbCurrentSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbCurrentSize.Location = new System.Drawing.Point(13, 286);
            this.lbCurrentSize.Name = "lbCurrentSize";
            this.lbCurrentSize.Size = new System.Drawing.Size(81, 13);
            this.lbCurrentSize.TabIndex = 12;
            this.lbCurrentSize.Text = "Chars: 2 / 2048";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(174, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSeparator
            // 
            this.tbSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSeparator.Location = new System.Drawing.Point(190, 283);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(38, 20);
            this.tbSeparator.TabIndex = 13;
            this.tbSeparator.Text = "     ";
            this.tbSeparator.TextChanged += new System.EventHandler(this.tbSeparator_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Separator:";
            // 
            // mainGrid
            // 
            this.mainGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.mainGrid.DrawGrid = true;
            this.mainGrid.Location = new System.Drawing.Point(13, 13);
            this.mainGrid.MinHeight = 12;
            this.mainGrid.MinimumSize = new System.Drawing.Size(18, 20);
            this.mainGrid.MinWidth = 12;
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.Size = new System.Drawing.Size(216, 240);
            this.mainGrid.TabIndex = 7;
            this.mainGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseDown);
            this.mainGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseMove);
            this.mainGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseUp);
            this.mainGrid.Resize += new System.EventHandler(this.mainGrid_Resize);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Download default smile pack";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 521);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSeparator);
            this.Controls.Add(this.lbCurrentSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.btnAddSmile);
            this.Controls.Add(this.smileBox);
            this.Controls.Add(this.mainGrid);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDrawGrid);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.MinimumSize = new System.Drawing.Size(256, 559);
            this.Name = "MainForm";
            this.Text = "Steam Chat Painter v1";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.smileBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.CheckBox cbDrawGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSize;
        private DrawingGrid mainGrid;
        private System.Windows.Forms.GroupBox smileBox;
        private DrawingGrid smileSelectorGrid;
        private System.Windows.Forms.Button btnAddSmile;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lbCurrentSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

