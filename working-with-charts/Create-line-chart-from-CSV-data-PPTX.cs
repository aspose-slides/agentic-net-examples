using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string dataDirectory = "Data";
        string excelFileName = "Data.xlsx";
        string excelFilePath = Path.Combine(dataDirectory, excelFileName);
        string outputFilePath = Path.Combine(dataDirectory, "ChartOutput.pptx");

        // Verify input Excel file exists
        if (!File.Exists(excelFilePath))
        {
            Console.WriteLine("Input Excel file not found: " + excelFilePath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart with sample data
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Enable data labels to take values from workbook cells
            IChartSeries series = chart.ChartData.Series[0];
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Access the chart's data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate workbook cells with label texts
            workbook.GetCell(0, 0, 0, "Label A");
            workbook.GetCell(0, 1, 0, "Label B");
            workbook.GetCell(0, 2, 0, "Label C");

            // Assign cells to the series data labels
            series.Labels[0].ValueFromCell = workbook.GetCell(0, 0, 0);
            series.Labels[1].ValueFromCell = workbook.GetCell(0, 1, 0);
            series.Labels[2].ValueFromCell = workbook.GetCell(0, 2, 0);

            // Save the presentation
            presentation.Save(outputFilePath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}