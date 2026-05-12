using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetThemeAccent
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first accent color in the master theme's color scheme
                IColorFormat accent1 = presentation.MasterTheme.ColorScheme.Accent1;
                // Assign a bright orange color to Accent1
                accent1.Color = Color.OrangeRed;

                // Save the modified presentation
                presentation.Save("Accent1_BrightOrange.pptx", SaveFormat.Pptx);
            }
        }
    }
}