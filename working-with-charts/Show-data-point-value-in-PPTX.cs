using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Check command line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program.exe <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape is a chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                // Get first data point of first series
                Aspose.Slides.Charts.IChartDataPoint dataPoint = chart.ChartData.Series[0].DataPoints[0];

                // Enable display of the data point value
                dataPoint.Label.DataLabelFormat.ShowValue = true;

                // Optional: set number format for the displayed value
                dataPoint.Label.DataLabelFormat.NumberFormat = "0.00%";

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
            }

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}