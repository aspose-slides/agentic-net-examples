using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 600f, 400f);

            // Get the workbook to populate data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A");
            workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B");
            workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C");
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0));

            // Add first series and its data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add second series and its data points
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                chart.Type);
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

            // Output series properties and data bindings
            Console.WriteLine("Chart Series Overview:");
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
                string seriesName = series.Name.AsLiteralString;
                Console.WriteLine($"Series {i}:");
                Console.WriteLine($"  Name: {seriesName}");
                Console.WriteLine($"  Type: {series.Type}");
                Console.WriteLine($"  Order: {series.Order}");
                Console.WriteLine($"  PlotOnSecondAxis: {series.PlotOnSecondAxis}");
                Console.WriteLine($"  NumberFormatOfValues: {series.NumberFormatOfValues}");
                Console.WriteLine($"  Data Points:");
                for (int j = 0; j < series.DataPoints.Count; j++)
                {
                    Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[j];
                    double value = point.Value.AsLiteralDouble;
                    Console.WriteLine($"    Point {j}: Value = {value}");
                }
            }

            // Save the presentation
            string outputPath = System.IO.Path.Combine(
                System.IO.Directory.GetCurrentDirectory(),
                "ChartSeriesOverview.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}