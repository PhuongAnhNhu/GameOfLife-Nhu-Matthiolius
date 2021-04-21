using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLifeControls
{
    [DefaultEvent("ButtonGridClick")]
    [Designer(typeof(GameOfLifeControlDesigner))]
    public class ButtonGrid : UserControl
    {
        #region Fields
        private GridButton[,] _gridButtons;
        private int _maxGridHeight = 100, _maxGridWidth = 100, _minGridHeight = 1, _minGridWidth = 1;
        private IContainer components = null;
        #endregion

        #region Properties
        [Description("The vertical amount of buttons.")]
        [DefaultValue(3)]
        public int GridHeight
        {
            get { return this._gridButtons.GetUpperBound(1) + 1; }
            set
            {
                if (value < this._minGridHeight || value > this._maxGridHeight)
                    return;
                this._gridButtons = new GridButton[this._gridButtons.GetUpperBound(0) + 1, value];
                PopulateGridButtons();
                InitGridButtons();
            }
        }
        [Description("The horizontal amount of buttons.")]
        [DefaultValue(3)]
        public int GridWidth
        {
            get { return this._gridButtons.GetUpperBound(0) + 1; }
            set
            {
                if (value < this._minGridWidth || value > this._maxGridWidth)
                    return;
                this._gridButtons = new GridButton[value, this._gridButtons.GetUpperBound(1) + 1];
                PopulateGridButtons();
                InitGridButtons();
            }
        }

        [Description("The maximum value for the GridHeight property.")]
        [DefaultValue(100)]
        public int MaxGridHeight
        {
            get { return this._maxGridHeight; }
            set
            {
                if (value < this._minGridHeight)
                    throw new ArgumentException("MaxGridHeight cannot be less than MinGridHeight.");
                this._maxGridHeight = value;
                if (value < this.GridHeight)
                    this.GridHeight = value;
            }
        }
        [Description("The maximum value for the GridWidth property.")]
        [DefaultValue(100)]
        public int MaxGridWidth
        {
            get { return this._maxGridWidth; }
            set
            {
                if (value < this._minGridWidth)
                    throw new ArgumentException("MaxGridWidth cannot be less than MinGridWidth.");
                this._maxGridWidth = value;
                if (value < this.GridWidth)
                    this.GridWidth = value;
            }
        }
        [Description("The minimum value for the GridHeight property.")]
        [DefaultValue(1)]
        public int MinGridHeight
        {
            get { return this._minGridHeight; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("MinGridHeight has to be a positive integer that is not zero.");
                else if (value > this._maxGridHeight)
                    throw new ArgumentException("MinGridHeight cannot be more than MaxGridHeight.");
                this._minGridHeight = value;
                if (value > this.GridHeight)
                    this.GridHeight = value;
            }
        }
        [Description("The minimum value for the GridWidth property.")]
        [DefaultValue(1)]
        public int MinGridWidth
        {
            get { return this._minGridWidth; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("MinGridWidth has to be a positive integer that is not zero.");
                else if (value > this._maxGridWidth)
                    throw new ArgumentException("MinGridWidth cannot be more than MaxGridWidth.");
                this._minGridWidth = value;
                if (value > this.GridWidth)
                    this.GridWidth = value;
            }
        }

        #region overridden Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
        }
        #endregion
        #endregion

        #region Constructor
        public ButtonGrid()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public void SetButtonColor(int x, int y, Color color)
        {
            if (x < 1 || y < 1)
                throw new ArgumentOutOfRangeException("The given coordinates have to positive integers that are not zero.");
            if (x > this.GridWidth || y > this.GridHeight)
                throw new ArgumentOutOfRangeException("There is no GridButton at X" + x + "Y" + y + ".");
            _gridButtons[x - 1, y - 1].BackColor = color;
        }
        public void SetButtonColorAll(Color color)
        {
            foreach (GridButton btn in this._gridButtons)
            {
                btn.BackColor = color;
            }
        }

        public int[] GetGridCenter()
        {
            int[] result = new int[2];
            result[0] = (this.GridWidth / 2) + (this.GridWidth % 2 == 1 ? 1 : 0);
            result[1] = (this.GridHeight / 2) + (this.GridHeight % 2 == 1 ? 1 : 0);
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._gridButtons = new GridButton[3, 3];
            PopulateGridButtons();
            this.SuspendLayout();
            //
            // _gridButtons
            //
            InitGridButtons();
            // 
            // ButtonGrid
            //
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Silver;
            this.Name = "ButtonGrid";
            this.ResumeLayout(false);
        }

        private void PopulateGridButtons()
        {
            for (int i = 0; i <= this._gridButtons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= this._gridButtons.GetUpperBound(1); j++)
                {
                    this._gridButtons[i, j] = new GridButton(i + 1, j + 1);
                }
            }
        }
        private void InitGridButtons()
        {
            foreach (GridButton btn in this._gridButtons)
            {
                btn.Location = new Point((btn.X - 1) * 20, (btn.Y - 1) * 20);
                btn.Margin = new Padding(0);
                btn.Name = "gridButtonX" + btn.X + "Y" + btn.Y;
                btn.Size = new Size(20, 20);
                btn.TabIndex = 0;
                btn.TabStop = false;
                btn.UseVisualStyleBackColor = true;
                btn.Click += new EventHandler(GridButton_Click);
            }
            this.SuspendLayout();
            if (this.Controls.Count != 0)
                this.Controls.Clear();
            foreach (GridButton btn in this._gridButtons)
            {
                this.Controls.Add(btn);
            }
            base.Size = new Size((this._gridButtons.GetUpperBound(0) + 1) * 20, (this._gridButtons.GetUpperBound(1) + 1) * 20);
            this.ResumeLayout(false);
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            onButtonGridClick?.Invoke(this, new ButtonGridClickEventArgs((GridButton)sender));
        }
        #endregion

        #region Events
        private ButtonGridClickEventHandler onButtonGridClick;

        #region Delegates
        public delegate void ButtonGridClickEventHandler(object sender, ButtonGridClickEventArgs e);
        #endregion

        #region Handlers
        [Description("Occurs when a Button in the grid is clicked.")]
        public event ButtonGridClickEventHandler ButtonGridClick
        {
            add { this.onButtonGridClick += value; }
            remove { this.onButtonGridClick -= value; }
        }
        #endregion
        #endregion
    }

    public class ButtonGridClickEventArgs : EventArgs
    {
        #region Fields
        private GridButton _gridButton;
        #endregion

        #region Properties
        public GridButton GridButton
        {
            get { return this._gridButton; }
        }
        #endregion

        #region Constructor
        public ButtonGridClickEventArgs(GridButton btn) : base()
        {
            this._gridButton = btn;
        }
        #endregion
    }
}
