using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file names
        string dataDir = "Data";
        string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
        string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Retrieve the first shape as a chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Determine the data source type of the chart
            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;

            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                // Get the external workbook path
                string externalWorkbookPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("External workbook path: " + externalWorkbookPath);
            }
            else
            {
                Console.WriteLine("The chart does not use an external workbook as its data source.");
            }
        }
        else
        {
            Console.WriteLine("No chart found on the first slide.");
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}