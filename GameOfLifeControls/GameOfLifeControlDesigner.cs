using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace GameOfLifeControls
{
    class GameOfLifeControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            if (properties.Contains("Size"))
            {
                PropertyDescriptor original = properties["Size"] as PropertyDescriptor;
                SerializeReadOnlyPropertyDescriptor readOnlyDescriptor = new SerializeReadOnlyPropertyDescriptor(original);
                properties["Size"] = readOnlyDescriptor;
            }
            base.PostFilterProperties(properties);
        }
    }
}
