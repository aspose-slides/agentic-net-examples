// -----------------------------------------------------------------------------
// Example: Set ellipse fill opacity to 50% in PPTX using C#
// 
// Description:
// This program creates a sample PPTX file with an ellipse if none exists,
// then loads the presentation, finds all ellipse shapes, and sets their solid
// fill opacity to 50% (alpha 128). The modified presentation is saved as a new
// file. It demonstrates using Aspose.Slides for .NET to manipulate shape fill
// transparency in PowerPoint files.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Fill Opacity, 50%
// 
// Use Cases:
// - Automate adjusting ellipse fill transparency in batch PPTX processing.
// - Build .NET tools that modify presentation graphics programmatically.
// - Validate and enforce design guidelines for corporate slide decks.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;

namespace SetEllipseFillOpacity
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            try
            {
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                // Create a sample presentation with an ellipse if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IAutoShape sampleEllipse = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
                    sampleEllipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    sampleEllipse.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 0, 0); // Opaque red
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through slides and shapes
                    foreach (Aspose.Slides.ISlide slide in pres.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                Aspose.Slides.IFillFormat fill = autoShape.FillFormat;
                                if (fill != null && fill.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    Color currentColor = fill.SolidFillColor.Color;
                                    // Set opacity to 50% (alpha = 128)
                                    Color newColor = Color.FromArgb(128, currentColor.R, currentColor.G, currentColor.B);
                                    fill.SolidFillColor.Color = newColor;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The specified file format is not supported.");
                exitCode = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                exitCode = 1;
            }

            return exitCode;
        }
    }
}
