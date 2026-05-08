using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory and file names
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input PPTX file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the specified file
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Retrieve the target slide (first slide in this example)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Access the chart object on the slide (assumes the first shape is a chart)
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the selected slide.");
                }
                else
                {
                    // Example operation: get the chart data range
                    string range = (chart.ChartData as Aspose.Slides.Charts.ChartData).GetRange();
                    Console.WriteLine("Chart data range: " + range);
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported file format or loading issues
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, it can be noted here
            }
        }
    }
}