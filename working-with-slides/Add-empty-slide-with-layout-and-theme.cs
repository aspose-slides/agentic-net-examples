// -----------------------------------------------------------------------------
// Example: Add Empty Slide with Specific Layout and Corporate Theme
//
// Description:
// Demonstrates how to add an empty slide using a chosen layout from a template
// presentation, apply a corporate background color as a theme, and save the
// modified PPTX. The program creates a sample template if none exists, making
// it self‑contained for automated branding workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Empty Slide, Layout, Theme, Background Color
//
// Use Cases:
// - Automate insertion of branded empty slides into existing presentations.
// - Build .NET tools for PowerPoint processing with custom corporate themes.
// - Ensure consistent branding across slide decks in batch operations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "template.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        try
        {
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation templatePres = new Aspose.Slides.Presentation();
                templatePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                templatePres.Dispose();
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            if (presentation.Masters.Count == 0)
            {
                Console.WriteLine("No master slides found in the template.");
                presentation.Dispose();
                Environment.Exit(1);
            }

            Aspose.Slides.ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides[0];

            presentation.Slides.InsertEmptySlide(0, layoutSlide);

            Aspose.Slides.ISlide newSlide = presentation.Slides[0];
            newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            newSlide.Background.FillFormat.SolidFillColor.Color = Color.FromArgb(0, 120, 215); // corporate blue

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
