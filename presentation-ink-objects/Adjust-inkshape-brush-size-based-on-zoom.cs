using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace InkZoomAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Verify input file existence
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file does not exist.");
                    return;
                }

                // Load presentation (uses provided creation/loading pattern)
                Presentation presentation = new Presentation(inputPath);

                // Retrieve current slide view zoom percentage
                int zoomPercent = presentation.ViewProperties.SlideViewProperties.Scale;

                // Assume the first shape on the first slide is an Ink shape
                IShape shape = presentation.Slides[0].Shapes[0];
                IInk ink = shape as IInk;
                if (ink != null && ink.Traces.Length > 0)
                {
                    // Access the brush of the first ink trace
                    IInkBrush brush = ink.Traces[0].Brush;

                    // Define a base brush size (in points)
                    System.Drawing.SizeF baseSize = new System.Drawing.SizeF(5f, 5f);

                    // Adjust brush size inversely proportional to the zoom level
                    float factor = zoomPercent / 100f;
                    System.Drawing.SizeF adjustedSize = new System.Drawing.SizeF(baseSize.Width / factor, baseSize.Height / factor);
                    brush.Size = adjustedSize;
                }

                // Save the modified presentation (must save before exit)
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}