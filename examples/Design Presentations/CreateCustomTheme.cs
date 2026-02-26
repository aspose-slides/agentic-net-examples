using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Theme;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first master slide
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Get the master theme manager for the master slide
        Aspose.Slides.Theme.IMasterThemeManager masterThemeManager = masterSlide.ThemeManager;

        // Enable overriding the existing theme
        masterThemeManager.IsOverrideThemeEnabled = true;

        // Get the overriding theme object
        Aspose.Slides.Theme.IMasterTheme overridingTheme = masterThemeManager.OverrideTheme;

        // Set a name for the custom theme
        overridingTheme.Name = "MyCustomTheme";

        // Modify the first fill style in the format scheme, if available
        if (overridingTheme.FormatScheme.FillStyles.Count > 0)
        {
            overridingTheme.FormatScheme.FillStyles[0].FillType = Aspose.Slides.FillType.Solid;
            overridingTheme.FormatScheme.FillStyles[0].SolidFillColor.Color = Color.Orange;
        }

        // Save the presentation
        presentation.Save("CustomThemePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}