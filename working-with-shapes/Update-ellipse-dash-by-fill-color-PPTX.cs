// -----------------------------------------------------------------------------
// Example: Update ellipse dash by fill color PPTX using C#
//
// Description:
// Demonstrates how to locate ellipse shapes with a specific solid fill color
// in a PowerPoint presentation and change their line dash style to Dash using
// Aspose.Slides for .NET. The example loads a PPTX file, processes each slide,
// updates matching ellipses, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Ellipse, Dash, Fill Color,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate modification of ellipse line styles based on fill color.
// - Build tools for batch updating PPTX presentations.
// - Integrate shape property changes into .NET applications.
// - Validate and enforce visual standards in PowerPoint files.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace UpdateEllipseDashByFillColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define the target fill color to search for (e.g., Red)
                    Color targetFillColor = Color.Red;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an AutoShape and of type Ellipse
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                // Ensure the shape has a solid fill
                                IFillFormat fillFormat = autoShape.FillFormat;
                                if (fillFormat != null && fillFormat.FillType == FillType.Solid)
                                {
                                    // Compare the fill color
                                    if (fillFormat.SolidFillColor.Color.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        // Change the line dash style to Dash
                                        ILineFormat lineFormat = autoShape.LineFormat;
                                        if (lineFormat != null)
                                        {
                                            lineFormat.DashStyle = LineDashStyle.Dash;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
