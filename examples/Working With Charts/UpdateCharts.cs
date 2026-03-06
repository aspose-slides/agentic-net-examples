using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the input presentation, external workbook and output presentation
        string inputPresentationPath = "input.pptx";
        string externalWorkbookPath = "data.xlsx";
        string outputPresentationPath = "output.pptx";

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);

        // Add a Pie chart to the first slide and initialize it with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f, 50f, 400f, 600f, true);

        // Get the chart data object
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Set an external workbook as the data source for the chart (do not update chart data immediately)
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(externalWorkbookPath, false);

        // Save the updated presentation
        presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}