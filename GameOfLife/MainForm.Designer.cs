
namespace GameOfLife
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
            this.components = new System.ComponentModel.Container();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBoxAbout = new System.Windows.Forms.GroupBox();
            this.ButtonGitHub = new System.Windows.Forms.Button();
            this.GroupBoxStyle = new System.Windows.Forms.GroupBox();
            this.ButtonColorDead = new System.Windows.Forms.Button();
            this.ButtonColorLiving = new System.Windows.Forms.Button();
            this.GroupBoxSteuerung = new System.Windows.Forms.GroupBox();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.GroupBoxSpielfeld = new System.Windows.Forms.GroupBox();
            this.ButtonRandomize = new System.Windows.Forms.Button();
            this.ButtonSetGridSize = new System.Windows.Forms.Button();
            this.NumericUpDownGridX = new System.Windows.Forms.NumericUpDown();
            this.LabelGridY = new System.Windows.Forms.Label();
            this.NumericUpDownGridY = new System.Windows.Forms.NumericUpDown();
            this.LabelGridX = new System.Windows.Forms.Label();
            this.ButtonGrid1 = new GameOfLifeControls.ButtonGrid();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBoxAbout.SuspendLayout();
            this.GroupBoxStyle.SuspendLayout();
            this.GroupBoxSteuerung.SuspendLayout();
            this.GroupBoxSpielfeld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownGridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownGridY)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.AutoScroll = true;
            this.SplitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(0, 395);
            this.SplitContainer1.Panel1.Controls.Add(this.Panel1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.ButtonGrid1);
            this.SplitContainer1.Panel2.Resize += new System.EventHandler(this.SplitContainer1_Panel2_Resize);
            this.SplitContainer1.Size = new System.Drawing.Size(800, 466);
            this.SplitContainer1.SplitterDistance = 112;
            this.SplitContainer1.TabIndex = 1;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBoxAbout);
            this.Panel1.Controls.Add(this.GroupBoxStyle);
            this.Panel1.Controls.Add(this.GroupBoxSteuerung);
            this.Panel1.Controls.Add(this.GroupBoxSpielfeld);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.MinimumSize = new System.Drawing.Size(0, 395);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(112, 466);
            this.Panel1.TabIndex = 10;
            // 
            // GroupBoxAbout
            // 
            this.GroupBoxAbout.Controls.Add(this.ButtonGitHub);
            this.GroupBoxAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBoxAbout.Location = new System.Drawing.Point(0, 414);
            this.GroupBoxAbout.Name = "GroupBoxAbout";
            this.GroupBoxAbout.Size = new System.Drawing.Size(112, 52);
            this.GroupBoxAbout.TabIndex = 9;
            this.GroupBoxAbout.TabStop = false;
            // 
            // ButtonGitHub
            // 
            this.ButtonGitHub.Location = new System.Drawing.Point(3, 9);
            this.ButtonGitHub.Name = "ButtonGitHub";
            this.ButtonGitHub.Size = new System.Drawing.Size(106, 40);
            this.ButtonGitHub.TabIndex = 3;
            this.ButtonGitHub.Text = "Repository auf GitHub";
            this.ButtonGitHub.UseVisualStyleBackColor = true;
            this.ButtonGitHub.Click += new System.EventHandler(this.ButtonGitHub_Click);
            // 
            // GroupBoxStyle
            // 
            this.GroupBoxStyle.Controls.Add(this.ButtonColorDead);
            this.GroupBoxStyle.Controls.Add(this.ButtonColorLiving);
            this.GroupBoxStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxStyle.Location = new System.Drawing.Point(0, 268);
            this.GroupBoxStyle.Name = "GroupBoxStyle";
            this.GroupBoxStyle.Size = new System.Drawing.Size(112, 75);
            this.GroupBoxStyle.TabIndex = 8;
            this.GroupBoxStyle.TabStop = false;
            this.GroupBoxStyle.Text = "Style";
            // 
            // ButtonColorDead
            // 
            this.ButtonColorDead.BackColor = System.Drawing.Color.Silver;
            this.ButtonColorDead.Location = new System.Drawing.Point(3, 48);
            this.ButtonColorDead.Name = "ButtonColorDead";
            this.ButtonColorDead.Size = new System.Drawing.Size(106, 23);
            this.ButtonColorDead.TabIndex = 3;
            this.ButtonColorDead.Text = "Tote Zellen";
            this.ButtonColorDead.UseVisualStyleBackColor = false;
            this.ButtonColorDead.Click += new System.EventHandler(this.ButtonColorDead_Click);
            // 
            // ButtonColorLiving
            // 
            this.ButtonColorLiving.BackColor = System.Drawing.Color.Yellow;
            this.ButtonColorLiving.Location = new System.Drawing.Point(3, 19);
            this.ButtonColorLiving.Name = "ButtonColorLiving";
            this.ButtonColorLiving.Size = new System.Drawing.Size(106, 23);
            this.ButtonColorLiving.TabIndex = 2;
            this.ButtonColorLiving.Text = "Lebende Zellen";
            this.ButtonColorLiving.UseVisualStyleBackColor = false;
            this.ButtonColorLiving.Click += new System.EventHandler(this.ButtonColorLiving_Click);
            // 
            // GroupBoxSteuerung
            // 
            this.GroupBoxSteuerung.Controls.Add(this.ButtonPause);
            this.GroupBoxSteuerung.Controls.Add(this.ButtonCancel);
            this.GroupBoxSteuerung.Controls.Add(this.ButtonStart);
            this.GroupBoxSteuerung.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxSteuerung.Location = new System.Drawing.Point(0, 167);
            this.GroupBoxSteuerung.Name = "GroupBoxSteuerung";
            this.GroupBoxSteuerung.Size = new System.Drawing.Size(112, 101);
            this.GroupBoxSteuerung.TabIndex = 7;
            this.GroupBoxSteuerung.TabStop = false;
            this.GroupBoxSteuerung.Text = "Steuerung";
            // 
            // ButtonPause
            // 
            this.ButtonPause.Enabled = false;
            this.ButtonPause.Location = new System.Drawing.Point(3, 45);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(106, 23);
            this.ButtonPause.TabIndex = 1;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Enabled = false;
            this.ButtonCancel.Location = new System.Drawing.Point(3, 74);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(106, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Abbruch";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(3, 16);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(106, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // GroupBoxSpielfeld
            // 
            this.GroupBoxSpielfeld.Controls.Add(this.ButtonRandomize);
            this.GroupBoxSpielfeld.Controls.Add(this.ButtonSetGridSize);
            this.GroupBoxSpielfeld.Controls.Add(this.NumericUpDownGridX);
            this.GroupBoxSpielfeld.Controls.Add(this.LabelGridY);
            this.GroupBoxSpielfeld.Controls.Add(this.NumericUpDownGridY);
            this.GroupBoxSpielfeld.Controls.Add(this.LabelGridX);
            this.GroupBoxSpielfeld.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxSpielfeld.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxSpielfeld.Name = "GroupBoxSpielfeld";
            this.GroupBoxSpielfeld.Size = new System.Drawing.Size(112, 167);
            this.GroupBoxSpielfeld.TabIndex = 6;
            this.GroupBoxSpielfeld.TabStop = false;
            this.GroupBoxSpielfeld.Text = "Spielfeld";
            // 
            // ButtonRandomize
            // 
            this.ButtonRandomize.Location = new System.Drawing.Point(3, 140);
            this.ButtonRandomize.Name = "ButtonRandomize";
            this.ButtonRandomize.Size = new System.Drawing.Size(106, 23);
            this.ButtonRandomize.TabIndex = 6;
            this.ButtonRandomize.Text = "Zufall";
            this.ButtonRandomize.UseVisualStyleBackColor = true;
            this.ButtonRandomize.Click += new System.EventHandler(this.ButtonRandomize_Click);
            // 
            // ButtonSetGridSize
            // 
            this.ButtonSetGridSize.Location = new System.Drawing.Point(3, 97);
            this.ButtonSetGridSize.Name = "ButtonSetGridSize";
            this.ButtonSetGridSize.Size = new System.Drawing.Size(106, 37);
            this.ButtonSetGridSize.TabIndex = 5;
            this.ButtonSetGridSize.Text = "Spielfeld zurücksetzen";
            this.ButtonSetGridSize.UseVisualStyleBackColor = true;
            this.ButtonSetGridSize.Click += new System.EventHandler(this.ButtonSetGridSize_Click);
            // 
            // NumericUpDownGridX
            // 
            this.NumericUpDownGridX.Location = new System.Drawing.Point(9, 32);
            this.NumericUpDownGridX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownGridX.Name = "NumericUpDownGridX";
            this.NumericUpDownGridX.ReadOnly = true;
            this.NumericUpDownGridX.Size = new System.Drawing.Size(91, 20);
            this.NumericUpDownGridX.TabIndex = 0;
            this.NumericUpDownGridX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownGridX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownGridX.ValueChanged += new System.EventHandler(this.NumericUpDownGridX_ValueChanged);
            this.NumericUpDownGridX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericUpDownGridX_KeyDown);
            this.NumericUpDownGridX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumericUpDownGridX_KeyUp);
            // 
            // LabelGridY
            // 
            this.LabelGridY.AutoSize = true;
            this.LabelGridY.Location = new System.Drawing.Point(6, 55);
            this.LabelGridY.Name = "LabelGridY";
            this.LabelGridY.Size = new System.Drawing.Size(33, 13);
            this.LabelGridY.TabIndex = 4;
            this.LabelGridY.Text = "Höhe";
            // 
            // NumericUpDownGridY
            // 
            this.NumericUpDownGridY.Location = new System.Drawing.Point(9, 71);
            this.NumericUpDownGridY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownGridY.Name = "NumericUpDownGridY";
            this.NumericUpDownGridY.ReadOnly = true;
            this.NumericUpDownGridY.Size = new System.Drawing.Size(91, 20);
            this.NumericUpDownGridY.TabIndex = 1;
            this.NumericUpDownGridY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownGridY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownGridY.ValueChanged += new System.EventHandler(this.NumericUpDownGridY_ValueChanged);
            this.NumericUpDownGridY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericUpDownGridY_KeyDown);
            this.NumericUpDownGridY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumericUpDownGridY_KeyUp);
            // 
            // LabelGridX
            // 
            this.LabelGridX.AutoSize = true;
            this.LabelGridX.Location = new System.Drawing.Point(6, 16);
            this.LabelGridX.Name = "LabelGridX";
            this.LabelGridX.Size = new System.Drawing.Size(34, 13);
            this.LabelGridX.TabIndex = 3;
            this.LabelGridX.Text = "Breite";
            // 
            // ButtonGrid1
            // 
            this.ButtonGrid1.BackColor = System.Drawing.Color.Silver;
            this.ButtonGrid1.GridHeight = 8;
            this.ButtonGrid1.GridWidth = 8;
            this.ButtonGrid1.Location = new System.Drawing.Point(3, 3);
            this.ButtonGrid1.Name = "ButtonGrid1";
            this.ButtonGrid1.TabIndex = 0;
            this.ButtonGrid1.ButtonGridClick += new GameOfLifeControls.ButtonGrid.ButtonGridClickEventHandler(this.ButtonGrid1_ButtonGridClick);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.GroupBoxAbout.ResumeLayout(false);
            this.GroupBoxStyle.ResumeLayout(false);
            this.GroupBoxSteuerung.ResumeLayout(false);
            this.GroupBoxSpielfeld.ResumeLayout(false);
            this.GroupBoxSpielfeld.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownGridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownGridY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer1;
        private GameOfLifeControls.ButtonGrid ButtonGrid1;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.GroupBox GroupBoxSpielfeld;
        private System.Windows.Forms.Button ButtonSetGridSize;
        private System.Windows.Forms.NumericUpDown NumericUpDownGridX;
        private System.Windows.Forms.Label LabelGridY;
        private System.Windows.Forms.NumericUpDown NumericUpDownGridY;
        private System.Windows.Forms.Label LabelGridX;
        private System.Windows.Forms.GroupBox GroupBoxSteuerung;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonGitHub;
        private System.Windows.Forms.GroupBox GroupBoxStyle;
        private System.Windows.Forms.Button ButtonColorDead;
        private System.Windows.Forms.Button ButtonColorLiving;
        private System.Windows.Forms.GroupBox GroupBoxAbout;
        private System.Windows.Forms.ColorDialog ColorDialog1;
        private System.Windows.Forms.Button ButtonRandomize;
        private System.Windows.Forms.Panel Panel1;
    }
}