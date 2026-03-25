using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a Box-and-Whisker chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.BoxAndWhisker, 50f, 50f, 500f, 400f);

            // Remove default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear the default worksheet
            workbook.Clear(0);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

            // Add a series for the Box-and-Whisker chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.BoxAndWhisker);

            // Configure series appearance
            series.QuartileMethod = Aspose.Slides.Charts.QuartileMethodType.Inclusive;
            series.ShowMeanLine = true;
            series.ShowMeanMarkers = true;
            series.ShowInnerPoints = true;
            series.ShowOutlierPoints = true;

            // Add data points (values) for each category
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 5));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 7));
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 6));

            // Save the presentation
            pres.Save("BoxWhiskerChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}