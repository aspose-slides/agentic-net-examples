using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a scatter chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 0, 0, 500, 400);

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add new series
        IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate series1 with scatter data points
        series1.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
        series1.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);
        series1.DataPoints.AddDataPointForScatterSeries(3.0, 5.0);

        // Populate series2 with scatter data points
        series2.DataPoints.AddDataPointForScatterSeries(1.5, 1.0);
        series2.DataPoints.AddDataPointForScatterSeries(2.5, 2.5);
        series2.DataPoints.AddDataPointForScatterSeries(3.5, 4.0);

        // Set fill colors for the series
        series1.Format.Fill.FillType = FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = Color.Red;

        series2.Format.Fill.FillType = FillType.Solid;
        series2.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        pres.Save("ScatterChart_out.pptx", SaveFormat.Pptx);
    }
}