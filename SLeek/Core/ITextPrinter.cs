using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SLeek
{
    public interface ITextPrinter
    {
        void PrintText(string text);
        void PrintTextLine(string text);
        void ClearText();

        string Content { get; set; }
        Color ForeColor { get; set; }
        Color BackColor { get; set; }
        Font Font { get; set; }
    }
}
