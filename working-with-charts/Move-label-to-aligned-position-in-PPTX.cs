using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ModifyLabelPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Find the first chart on the slide
            IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                presentation.Dispose();
                return;
            }

            // Modify the position of the data label for the first series
            if (chart.ChartData.Series.Count > 0)
            {
                // Set default data label position
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Center;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}