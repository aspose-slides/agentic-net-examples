using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BoxWhiskerChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Add a BoxAndWhisker chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BoxAndWhisker, 0, 0, 500, 400);
            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();
            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            // Clear the default worksheet
            workbook.Clear(0);
            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 4"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 5"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A7", "Category 6"));
            // Add a series for BoxAndWhisker
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.BoxAndWhisker);
            series.QuartileMethod = Aspose.Slides.Charts.QuartileMethodType.Inclusive;
            series.ShowMeanLine = true;
            series.ShowMeanMarkers = true;
            series.ShowInnerPoints = true;
            series.ShowOutlierPoints = true;
            // Add data points
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 10));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 20));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 30));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 40));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 50));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B7", 30));
            // Save the presentation
            presentation.Save("BoxWhiskerChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}