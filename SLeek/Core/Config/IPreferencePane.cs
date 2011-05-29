using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SLeek
{
    public interface IPreferencePane
    {
        string Name { get; }
        Image Icon { get; }
        void SetPreferences();
    }
}
