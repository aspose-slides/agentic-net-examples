// -----------------------------------------------------------------------------
// Example: Clone slide and set background color using C#
//
// Description:
// Demonstrates how to clone the first slide of a presentation and set its
// background color to yellow using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, clones a slide, modifies the background fill,
// and saves the result as a new PPTX file. This pattern can be used in console
// applications or automated workflows that need to duplicate slides and apply
// custom background styling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Background Color,
// Solid Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a slide and applying a specific background color.
// - Build .NET tools for customizing slide appearance in bulk.
// - Generate or transform PPTX files with consistent styling.
// - Validate slide duplication and background settings in CI pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlideCollection slides = pres.Slides;
            ISlide clonedSlide = slides.AddClone(slides[0]);

            clonedSlide.Background.Type = BackgroundType.OwnBackground;
            clonedSlide.Background.FillFormat.FillType = FillType.Solid;
            clonedSlide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
