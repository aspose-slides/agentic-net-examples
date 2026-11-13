// -----------------------------------------------------------------------------
// Example: Set ellipse line width to 2pt using Aspose.Slides for .NET
//
// Description:
// Demonstrates how to set the line width of ellipse shapes to 2 points in a
// PowerPoint PPTX file using C# and Aspose.Slides for .NET. The program creates
// a sample presentation if none exists, updates each ellipse's line width, and
// saves the modified file. This automates shape formatting across slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line Width
//
// Use Cases:
// - Enforce consistent ellipse border thickness in corporate slide decks.
// - Batch‑process presentations to apply design standards automatically.
// - Integrate shape styling into .NET PowerPoint generation workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace SetEllipseLineWidth
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure a sample input file exists
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                    // Add an ellipse shape to the slide
                    Aspose.Slides.IAutoShape ellipseShape = sampleSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
                    // Set an initial line width (optional)
                    if (ellipseShape.LineFormat != null)
                    {
                        ellipseShape.LineFormat.Width = 1f;
                    }
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    return 1;
                }
            }

            // Verify that the input file now exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return 1;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                if (autoShape.LineFormat != null)
                                {
                                    autoShape.LineFormat.Width = 2f;
                                }
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }

            Console.WriteLine("Ellipse line widths updated successfully. Output saved to " + outputPath);
            return 0;
        }
    }
}
