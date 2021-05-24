using System.Collections.Generic;
using System.Windows.Forms;

namespace GameOfLifeControls
{
    public static class ControlHelper
    {
        #region Methods
        public static void ControlEnabler(Control ctrl, bool isEnabled)
        {
            ctrl.Enabled = isEnabled;
        }
        public static void ControlEnabler(IEnumerable<Control> controls, bool isEnabled)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Enabled = isEnabled;
            }
        }
        #endregion
    }
}
