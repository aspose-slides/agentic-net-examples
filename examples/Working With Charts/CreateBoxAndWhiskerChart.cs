using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a BoxAndWhisker chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BoxAndWhisker, 50f, 50f, 500f, 400f);

        // Clear default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

        // Add a series for the BoxAndWhisker chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.BoxAndWhisker);
        series.QuartileMethod = Aspose.Slides.Charts.QuartileMethodType.Inclusive;
        series.ShowMeanLine = true;
        series.ShowMeanMarkers = true;
        series.ShowInnerPoints = true;
        series.ShowOutlierPoints = true;

        // Add data points for the series
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 10));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 20));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 30));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 40));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 50));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 30));

        // Save the presentation
        presentation.Save("BoxAndWhiskerChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}