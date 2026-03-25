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
            // Define input and output file paths
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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Access the first shape on the slide (assumed to be a chart)
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Cast the shape to a chart
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                // If a chart is found and it contains at least one series, clear the data points of the first series
                if (chart != null && chart.ChartData.Series.Count > 0)
                {
                    chart.ChartData.Series[0].DataPoints.Clear();
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}