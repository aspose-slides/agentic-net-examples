using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ManageChartWorkbooksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "ManagedChartWorkbook.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a 3‑D stacked column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.StackedColumn3D,
                0f, 0f, 500f, 500f);

            // Index of the default worksheet inside the chart's workbook
            int defaultWorksheetIndex = 0;

            // Access the chart's embedded workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add two series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                chart.Type);

            // Add three categories
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data for the first series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Populate data for the second series
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Link the chart to an external workbook (do not update data immediately)
            string externalWorkbookPath = "externalData.xlsx";
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(externalWorkbookPath, false);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}