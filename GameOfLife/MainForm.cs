using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GameOfLifeControls;
using static GameOfLifeControls.ControlHelper;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        #region Fields
        private SpielFeld _field;
        private bool _isPaused = false;
        private Color _colorLiving;
        private Color _colorDead;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private Zelle[] MakeDefaultShape()
        {
            int[] center = ButtonGrid1.GetGridCenter();
            Zelle[] zellen = {
                new Zelle(center[0], center[1] - 1),
                new Zelle(center[0] + 1, center[1]),
                new Zelle(center[0] - 1, center[1] + 1),
                new Zelle(center[0], center[1] + 1),
                new Zelle(center[0] + 1, center[1] + 1)
            };
            return zellen;
        }
        private void MakeRandomDistribution()
        {
            Random rng = new Random();
            this._field = new SpielFeld(this._field.X, this._field.Y, new Zelle[0]);
            int randomCellCount = rng.Next(this.ButtonGrid1.GetGridButtonCount());
            for(int i = 0; i < randomCellCount; i++)
            {
                int randomX = rng.Next(1, this.ButtonGrid1.GridWidth + 1);
                int randomY = rng.Next(1, this.ButtonGrid1.GridHeight + 1);
                this._field.ZelleAendern(new Zelle(randomX, randomY), out _);
            }
            this._field = new SpielFeld(this._field.X, this._field.Y, this._field.LebendeZellen);
        }

        private void NextMove()
        {
            this._field.Next();
            try
            {
                SetGridButtonColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                this.ButtonCancel.PerformClick();
            }
        }

        private void SetMaximumGridSize()
        {
            int maxWidth = this.SplitContainer1.Panel2.Width / 20;
            int maxHeight = this.SplitContainer1.Panel2.Height / 20;
            this.ButtonGrid1.MaxGridWidth = maxWidth;
            this.ButtonGrid1.MaxGridHeight = maxHeight;
            this.NumericUpDownGridX.Maximum = maxWidth;
            this.NumericUpDownGridY.Maximum = maxHeight;
        }

        private void RenameButtonSetGridSize()
        {
            string tmp;
            if (this.NumericUpDownGridX.Value == this.ButtonGrid1.GridWidth && this.NumericUpDownGridY.Value == this.ButtonGrid1.GridHeight)
                tmp = "Spielfeld zurücksetzen";
            else
                tmp = "Größe ändern";
            this.ButtonSetGridSize.Text = tmp;
        }

        private void ResetSpielfeld()
        {
            this._field.Reset();
            SetCellColors();
        }
        private void ResetSpielfeldDefault(bool randomize)
        {
            if (!randomize)
                this._field = new SpielFeld(this.ButtonGrid1.GridWidth, this.ButtonGrid1.GridHeight, MakeDefaultShape());
            else
                MakeRandomDistribution();
            SetCellColors();
        }

        private void SetCellColors()
        {
            this._colorLiving = this.ButtonColorLiving.BackColor;
            this._colorDead = this.ButtonColorDead.BackColor;
            SetGridButtonColor();
        }

        private void SetGridButtonColor()
        {
            ButtonGrid1.SetButtonColorAll(_colorDead);
            foreach (Zelle zelle in this._field.LebendeZellen)
            {
                ButtonGrid1.SetButtonColor(zelle.X, zelle.Y, _colorLiving);
            }
        }

        #region Controlling the Game
        private void StartGame()
        {
            this._field = new SpielFeld(this._field.X, this._field.Y, this._field.LebendeZellen);
            this.Timer1.Start();
            EnableControlsAtStartStop(true);
            EnableSizeability(false);
        }
        private void PauseResumeGame()
        {
            if (!_isPaused)
            {
                this.Timer1.Stop();
                this.ButtonPause.Text = "Fortsetzen";
            }
            else
            {
                this.Timer1.Start();
                this.ButtonPause.Text = "Pause";
            }
            _isPaused = !_isPaused;
        }
        private void StopGame()
        {
            this.Timer1.Stop();
            ResetSpielfeld();
            EnableControlsAtStartStop(false);
            EnableSizeability(true);
            if (_isPaused)
            {
                _isPaused = false;
                this.ButtonPause.Text = "Pause";
            }
        }

        private void EnableControlsAtStartStop(bool enableAtStart)
        {
            ControlEnabler(new Control[] { this.GroupBoxSpielfeld, this.GroupBoxStyle, this.ButtonStart, this.ButtonGrid1 }, !enableAtStart);
            ControlEnabler(new Control[] { this.ButtonPause, this.ButtonCancel }, enableAtStart);
        }
        private void EnableSizeability(bool enabled)
        {
            this.MaximizeBox = enabled;
            this.FormBorderStyle = enabled ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
        }
        #endregion
        #endregion

        #region Form Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetMaximumGridSize();
            this.NumericUpDownGridX.Value = this.ButtonGrid1.GridWidth;
            this.NumericUpDownGridY.Value = this.ButtonGrid1.GridHeight;
            ResetSpielfeldDefault(false);
        }

        #region Resizing
        private bool maximize = false;
        private Size sizeTemp;
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            this.maximize = false;
            sizeTemp = new Size(this.SplitContainer1.Panel2.Width, this.SplitContainer1.Panel2.Height);
        }
        private void SplitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            if (this.maximize)
                SetMaximumGridSize();
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            this.maximize = true;
            if (new Size(this.SplitContainer1.Panel2.Width, this.SplitContainer1.Panel2.Height) != sizeTemp)
            {
                if (this.SplitContainer1.Panel1.Height < 395)
                    this.SplitContainer1.SplitterDistance = 129;
                else
                    this.SplitContainer1.SplitterDistance = 112;
                SetMaximumGridSize();
            }
        }
        #endregion

        private void ButtonGrid1_ButtonGridClick(object sender, ButtonGridClickEventArgs e)
        {
            this._field.ZelleAendern(new Zelle(e.GridButton.X, e.GridButton.Y), out bool zelleLebt);
            e.GridButton.BackColor = zelleLebt == true ? this._colorDead : this._colorLiving;
        }

        private void NumericUpDownGridX_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void NumericUpDownGridX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ButtonSetGridSize.PerformClick();
        }

        private void NumericUpDownGridY_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void NumericUpDownGridY_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ButtonSetGridSize.PerformClick();
        }

        private void NumericUpDownGridX_ValueChanged(object sender, EventArgs e)
        {
            RenameButtonSetGridSize();
        }
        private void NumericUpDownGridY_ValueChanged(object sender, EventArgs e)
        {
            RenameButtonSetGridSize();
        }

        private void ButtonSetGridSize_Click(object sender, EventArgs e)
        {
            this.ButtonGrid1.GridWidth = (int)this.NumericUpDownGridX.Value;
            this.ButtonGrid1.GridHeight = (int)this.NumericUpDownGridY.Value;
            ResetSpielfeldDefault(false);
            RenameButtonSetGridSize();
        }

        private void ButtonRandomize_Click(object sender, EventArgs e)
        {
            this.NumericUpDownGridX.Value = this.ButtonGrid1.GridWidth;
            this.NumericUpDownGridY.Value = this.ButtonGrid1.GridHeight;
            ResetSpielfeldDefault(true);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            PauseResumeGame();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void ButtonColorLiving_Click(object sender, EventArgs e)
        {
            this.ColorDialog1.Color = ((Button)sender).BackColor;
            if (this.ColorDialog1.ShowDialog() == DialogResult.OK)
                ((Button)sender).BackColor = this.ColorDialog1.Color;
            SetCellColors();
        }
        private void ButtonColorDead_Click(object sender, EventArgs e)
        {
            this.ColorDialog1.Color = ((Button)sender).BackColor;
            if (this.ColorDialog1.ShowDialog() == DialogResult.OK)
                ((Button)sender).BackColor = this.ColorDialog1.Color;
            SetCellColors();
        }

        private void ButtonGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/PhuongAnhNhu/GameOfLife-Nhu-Matthiolius");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            NextMove();
        }
        #endregion
    }
}
