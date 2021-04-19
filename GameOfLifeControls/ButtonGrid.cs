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
        private IContainer components = null;
        #endregion

        #region Properties
        [Description("The horizontal amount of buttons.")]
        [DefaultValue(3)]
        public int GridWidth
        {
            get { return this._gridButtons.GetUpperBound(0) + 1; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Value has to be a positive integer that is not zero.");
                this._gridButtons = new GridButton[value, this._gridButtons.GetUpperBound(1) + 1];
                PopulateGridButtons();
                InitGridButtons();
            }
        }
        [Description("The vertical amount of buttons.")]
        [DefaultValue(3)]
        public int GridHeight
        {
            get { return this._gridButtons.GetUpperBound(1) + 1; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Value has to be a positive integer that is not zero.");
                this._gridButtons = new GridButton[this._gridButtons.GetUpperBound(0) + 1, value];
                PopulateGridButtons();
                InitGridButtons();
            }
        }

        #region overridden Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
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
            this.Size = new Size((this._gridButtons.GetUpperBound(0) + 1) * 20, (this._gridButtons.GetUpperBound(1) + 1) * 20);
            this.ResumeLayout(false);
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            onButtonGridClick(this, new ButtonGridClickEventArgs((GridButton)sender));
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
