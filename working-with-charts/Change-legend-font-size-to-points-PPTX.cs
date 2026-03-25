using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChangeLegendFontSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths (can be overridden by command‑line arguments)
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (args.Length > 0)
                inputPath = args[0];
            if (args.Length > 1)
                outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Find the first chart on the first slide
                IChart chart = null;
                ISlide slide = presentation.Slides[0];
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    presentation.Dispose();
                    return;
                }

                // Ensure the chart has a legend
                chart.HasLegend = true;

                // Set the legend font size to 14 points
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}