using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CloneChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Assume the first slide contains the chart to be cloned
                ISlide sourceSlide = pres.Slides[0];
                IChart sourceChart = sourceSlide.Shapes[0] as IChart;
                if (sourceChart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    pres.Save(outputPath, SaveFormat.Pptx);
                    return;
                }

                // Clone the source slide and insert it after the original slide
                ISlide clonedSlide = pres.Slides.InsertClone(1, sourceSlide);

                // Retrieve the cloned chart from the new slide
                IChart clonedChart = clonedSlide.Shapes[0] as IChart;
                if (clonedChart != null)
                {
                    // Enable the data table for the cloned chart
                    clonedChart.HasDataTable = true;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}