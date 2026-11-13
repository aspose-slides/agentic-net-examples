// -----------------------------------------------------------------------------
// Example: Replace ellipse fills with red in PPTX using C#
// 
// Description:
// Demonstrates how to load a PowerPoint PPTX file, create a sample file if missing,
// iterate through all slides and shapes, change the fill color of every ellipse
// shape to solid red, and save the modified presentation as a new PPTX file.
// This uses Aspose.Slides for .NET to manipulate shape formatting programmatically.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace ellipse fill red
// 
// Use Cases:
// - Automate standardizing ellipse colors across corporate presentations.
// - Build a command‑line utility for batch processing of PPTX files.
// - Integrate shape color adjustments into a larger .NET reporting workflow.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace ReplaceEllipseFills
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                    Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
                    Aspose.Slides.AutoShape sampleAutoShape = sampleShape as Aspose.Slides.AutoShape;
                    if (sampleAutoShape != null)
                    {
                        sampleAutoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        sampleAutoShape.FillFormat.SolidFillColor.Color = Color.Blue;
                    }
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShape objects that are ellipses
                        Aspose.Slides.AutoShape autoShape = shape as Aspose.Slides.AutoShape;
                        if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                        {
                            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            autoShape.FillFormat.SolidFillColor.Color = Color.Red;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
                Environment.Exit(1);
            }
        }
    }
}
