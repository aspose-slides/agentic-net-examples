using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlides3DChartRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide (adjust index if needed)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first chart on the slide
                Aspose.Slides.Charts.IChart chart = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the slide.");
                    presentation.Dispose();
                    return;
                }

                // Configure 3D rotation properties
                chart.Rotation3D.RotationX = 30;          // X-axis rotation (sbyte)
                chart.Rotation3D.RotationY = 40;          // Y-axis rotation (ushort)
                chart.Rotation3D.DepthPercents = 150;    // Depth as percentage of chart width (ushort)

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}