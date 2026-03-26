using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string workbookPath = "data.xlsx";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found: " + inputPath);
            return;
        }

        // Verify that the external workbook exists
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook not found: " + workbookPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide and assume the first shape is a chart
        ISlide slide = presentation.Slides[0];
        IChart chart = slide.Shapes[0] as IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            presentation.Dispose();
            return;
        }

        // Update chart data from the external workbook and refresh the chart
        IChartData chartData = chart.ChartData;
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

        // Optionally switch rows and columns if required
        chart.ChartData.SwitchRowColumn();

        // Save the updated presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}