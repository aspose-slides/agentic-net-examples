using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file names
            string dataDir = @"C:\Data\";
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";

            // Build full paths
            string inputPath = Path.Combine(dataDir, inputFile);
            string outputPath = Path.Combine(dataDir, outputFile);

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Retrieve the first slide (or change index as needed)
                ISlide slide = pres.Slides[0];

                // Access the first shape assuming it is a chart
                IChart chart = (IChart)slide.Shapes[0];

                // Example operation: get chart data range (optional)
                // string range = (chart.ChartData as ChartData).GetRange();
                // Console.WriteLine("Chart data range: " + range);

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (InvalidOperationException ex)
            {
                // Handle unsupported format or other invalid operations
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (including external URL/web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}