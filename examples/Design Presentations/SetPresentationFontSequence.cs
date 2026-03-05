using System;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the major font collection from the master theme
        Aspose.Slides.IFonts majorFonts = presentation.MasterTheme.FontScheme.Major;

        // Set the Latin font
        Aspose.Slides.IFontData latinFont = new Aspose.Slides.FontData("Calibri");
        majorFonts.LatinFont = latinFont;

        // Set the East Asian font
        Aspose.Slides.IFontData eastAsianFont = new Aspose.Slides.FontData("Yu Gothic");
        majorFonts.EastAsianFont = eastAsianFont;

        // Set the Complex Script font
        Aspose.Slides.IFontData complexFont = new Aspose.Slides.FontData("Arial Unicode MS");
        majorFonts.ComplexScriptFont = complexFont;

        // Assign a script-specific font (e.g., Arabic script)
        presentation.MasterTheme.FontScheme.Major.SetScriptFont("Arab", "Segoe UI");

        // Save the presentation
        presentation.Save("FontSelectionSequence_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}