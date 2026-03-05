using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the master theme (read‑only property, used for reading only)
        Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;

        // Change the fill color of the first line style to Red
        masterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

        // Set the third fill style to solid and change its color to ForestGreen
        masterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;
        masterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

        // Modify the outer shadow distance of the third effect style
        masterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

        // Save the presentation before exiting
        presentation.Save("ThemeDesignOutput.pptx", SaveFormat.Pptx);
    }
}