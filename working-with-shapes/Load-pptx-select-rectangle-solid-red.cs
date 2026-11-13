// -----------------------------------------------------------------------------
// Example: Apply solid red fill to first rectangle shape in PPTX
//
// Description:
// Demonstrates loading a PPTX file, creating a sample file if missing, selecting
// the first rectangle shape on the first slide, applying a solid red fill using
// Aspose.Slides for .NET, and saving the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle shape, solid red fill
//
// Use Cases:
// - Automate styling of specific shapes in presentations.
// - Generate test PPTX files with predefined formatting.
// - Integrate shape formatting into .NET batch processing utilities.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    // Create a sample presentation with a rectangle shape
                    using (Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                        Aspose.Slides.IAutoShape rectangle = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                        samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];
                    Aspose.Slides.IAutoShape targetShape = null;

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                            {
                                targetShape = autoShape;
                                break;
                            }
                        }
                    }

                    if (targetShape == null)
                    {
                        Console.WriteLine("No rectangle shape found on the first slide.");
                        Environment.Exit(1);
                    }

                    targetShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    targetShape.FillFormat.SolidFillColor.Color = Color.Red;

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation processed successfully. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // The provided file format may not be supported by Aspose.Slides.
                Environment.Exit(1);
            }
        }
    }
}
