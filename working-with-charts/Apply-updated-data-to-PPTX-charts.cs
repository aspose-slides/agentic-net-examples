using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateChartData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = "input.pptx";
            string outputFilePath = "output.pptx";
            // Define the new data range for the chart
            string newDataRange = "Sheet1!$A$1:$B$5";

            // Verify that the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Error: Input file not found - " + inputFilePath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

                // Iterate through slides to find charts
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        // Attempt to cast the shape to IChart
                        Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Update the chart data range
                            chart.ChartData.SetRange(newDataRange);
                        }
                    }
                }

                // Save the updated presentation
                presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}