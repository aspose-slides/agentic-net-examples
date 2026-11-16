// -----------------------------------------------------------------------------
// Example: Clone first slide and set background color to yellow
//
// Description:
// Demonstrates cloning the first slide of a PPTX file and changing its background
// to solid yellow using Aspose.Slides for .NET. The program creates a sample
// input file if none exists, performs the clone and styling, and saves the
// result as a new PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Background Color, Solid Fill
//
// Use Cases:
// - Automate duplication of slides with custom background styling.
// - Build tools that apply consistent slide appearance across presentations.
// - Generate PPTX files programmatically for reporting or marketing assets.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a simple presentation with a single blank slide as sample input
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlideCollection slides = pres.Slides;
            Aspose.Slides.ISlide clonedSlide = slides.AddClone(slides[0]);

            clonedSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            clonedSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            clonedSlide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
