using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartPerformance.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart without initializing sample data (faster)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f, false);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Ensure the worksheet is empty
        workbook.Clear(0);

        // Add a category
        Aspose.Slides.Charts.IChartDataCell categoryCell = workbook.GetCell(0, 0, 0, "Category A");
        chart.ChartData.Categories.Add(categoryCell);

        // Add a series
        Aspose.Slides.Charts.IChartDataCell seriesCell = workbook.GetCell(0, 0, 1, "Series 1");
        chart.ChartData.Series.Add(seriesCell, chart.Type);

        // Populate data cells
        workbook.GetCell(0, 1, 1, 10); // B2 = 10
        workbook.GetCell(0, 2, 1, 20); // B3 = 20

        // Set a formula cell (B4 = B2 + B3)
        Aspose.Slides.Charts.IChartDataCell formulaCell = workbook.GetCell(0, 3, 1);
        formulaCell.Formula = "B2+B3";

        // Link the formula cell to the data point
        chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(formulaCell);

        // Calculate all formulas once (improves performance)
        workbook.CalculateFormulas();

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}