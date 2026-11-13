// -----------------------------------------------------------------------------
// Example: Update Ellipse Dash Style by Fill Color in PPTX using C#
// 
// Description:
// Demonstrates how to create a sample PPTX if needed, locate ellipse shapes with a
// specific solid fill color, and change their line dash style to Dash using
// Aspose.Slides for .NET. The program loads the presentation, updates matching
// ellipses, and saves the modified file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update ellipse dash, Fill color
// 
// Use Cases:
// - Enforce visual style rules based on shape fill colors.
// - Batch process presentations to standardize line dash styles.
// - Integrate shape property updates into automated .NET workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace UpdateEllipseDashByFillColor
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
                    Aspose.Slides.IAutoShape ellipse = sampleSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse,
                        100f,
                        100f,
                        300f,
                        150f);
                    ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    ellipse.FillFormat.SolidFillColor.Color = Color.Red;
                    ellipse.LineFormat.Width = 2f;
                    ellipse.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Solid;
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Define the target fill color (Red)
                    Color targetFillColor = Color.Red;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an AutoShape of type Ellipse
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Ensure the shape has a solid fill
                                Aspose.Slides.IFillFormat fillFormat = autoShape.FillFormat;
                                if (fillFormat != null && fillFormat.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    // Compare the fill color
                                    if (fillFormat.SolidFillColor.Color.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        // Change the line dash style to Dash
                                        Aspose.Slides.ILineFormat lineFormat = autoShape.LineFormat;
                                        if (lineFormat != null)
                                        {
                                            lineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
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

            Environment.Exit(0);
        }
    }
}
