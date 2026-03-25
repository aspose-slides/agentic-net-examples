using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect two arguments: workbook path and output PPTX path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <workbookPath> <outputPptx>");
            return;
        }

        string workbookPath = args[0];
        string outputPath = args[1];

        // Verify that the external workbook exists
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Error: Workbook file not found - " + workbookPath);
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a pie chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
        IChartData chartData = chart.ChartData;

        // Associate the external workbook without loading chart data immediately
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}