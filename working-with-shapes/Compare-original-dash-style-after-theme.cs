using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompareDashStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get first slide
                    ISlide slide = pres.Slides[0];

                    // Get first shape that has a line format (e.g., AutoShape)
                    IShape shape = slide.Shapes[0];

                    // Original dash style set on the shape
                    ILineFormat lineFormat = shape.LineFormat;
                    LineDashStyle originalDash = lineFormat.DashStyle;

                    // Effective dash style after theme inheritance
                    ILineFormatEffectiveData effectiveLine = lineFormat.GetEffective();
                    LineDashStyle effectiveDash = effectiveLine.DashStyle;

                    // Output comparison
                    Console.WriteLine("Original Dash Style: " + originalDash);
                    Console.WriteLine("Effective Dash Style after Theme: " + effectiveDash);

                    // Save presentation before exit
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file read errors, Aspose.Slides exceptions)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}