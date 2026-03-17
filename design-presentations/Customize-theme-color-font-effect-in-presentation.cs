using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Adjust the theme color scheme
            Aspose.Slides.Theme.IColorScheme colorScheme = presentation.MasterTheme.ColorScheme;
            colorScheme.Accent1.Color = Color.FromArgb(255, 0, 0); // Red
            colorScheme.Accent2.Color = Color.FromArgb(0, 255, 0); // Green

            // Adjust the theme font scheme
            Aspose.Slides.Theme.IFontScheme fontScheme = presentation.MasterTheme.FontScheme;
            fontScheme.Major.LatinFont = new Aspose.Slides.FontData("Arial");
            fontScheme.Minor.LatinFont = new Aspose.Slides.FontData("Calibri");

            // Adjust the theme effect scheme
            Aspose.Slides.Theme.IFormatScheme formatScheme = presentation.MasterTheme.FormatScheme;
            // Set outer shadow distance for the first effect style
            formatScheme.EffectStyles[0].EffectFormat.OuterShadowEffect.Distance = 10f;
            // Change fill style of the second fill style to solid and set its color
            formatScheme.FillStyles[1].FillType = Aspose.Slides.FillType.Solid;
            formatScheme.FillStyles[1].SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("CustomizedTheme.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}