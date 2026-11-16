// -----------------------------------------------------------------------------
// Example: Update ellipse line color based on fill color in PPTX using C#
//
// Description:
// Demonstrates locating ellipse shapes with a specific solid fill color in a PowerPoint PPTX file and changing their line color using Aspose.Slides for .NET. The program creates a sample presentation if none exists, modifies matching ellipses, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ellipse, line color, fill color, shape modification
//
// Use Cases:
// - Bulk update of shape line colors based on fill for branding.
// - Automated style normalization in presentation pipelines.
// - Custom C# utilities for PPTX visual adjustments.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace UpdateEllipseLineColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlide slide = samplePres.Slides[0];
                        // Add an ellipse shape with a blue solid fill
                        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Ellipse,
                            100, 100, 200, 150);
                        ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        ellipse.FillFormat.SolidFillColor.Color = Color.Blue;
                        // Set an initial black line color
                        ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                        samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify the input file exists before processing
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                Environment.Exit(1);
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Color targetFillColor = Color.Blue;
                    Color newLineColor = Color.Red;

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                if (autoShape.FillFormat != null && autoShape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    Color shapeFillColor = autoShape.FillFormat.SolidFillColor.Color;
                                    if (shapeFillColor.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        if (autoShape.LineFormat != null && autoShape.LineFormat.FillFormat != null)
                                        {
                                            autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                            autoShape.LineFormat.FillFormat.SolidFillColor.Color = newLineColor;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The provided file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
