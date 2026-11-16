// -----------------------------------------------------------------------------
// Example: Set master slide dashdot pattern using C#
// 
// Description:
// Demonstrates how to set the line dash style to DashDot for all shapes on each
// master slide in a PowerPoint presentation using Aspose.Slides for .NET. The
// program creates a sample PPTX file if none exists, updates the line formatting
// of shapes on master slides, and saves the result as a new PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Master Slide, LineDashStyle, DashDot
// 
// Use Cases:
// - Apply a uniform DashDot line style to all shapes on master slides.
// - Prepare presentations with consistent styling before distribution.
// - Automate styling updates in batch processing of PPTX files.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace SetMasterSlideDashDot
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
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.IMasterSlide masterSlide = samplePresentation.Masters[0];
                    Aspose.Slides.IShape rectangle = masterSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                    rectangle.LineFormat.Width = 2;
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                foreach (Aspose.Slides.IMasterSlide master in presentation.Masters)
                {
                    foreach (Aspose.Slides.IShape shape in master.Shapes)
                    {
                        if (shape.LineFormat != null)
                        {
                            shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
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
