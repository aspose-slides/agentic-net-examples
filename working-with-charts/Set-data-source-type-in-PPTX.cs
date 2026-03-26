using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the first shape as a chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Get the data source type of the chart
            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;

            // Check if the chart uses an external workbook
            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                string externalPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("Chart uses external workbook: " + externalPath);
            }
            else
            {
                Console.WriteLine("Chart uses internal workbook.");
            }
        }
        else
        {
            Console.WriteLine("No chart found on the specified slide.");
        }

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}