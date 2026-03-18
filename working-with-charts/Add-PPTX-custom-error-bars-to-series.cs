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
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add two series
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Add three categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Populate data points for series 1
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Populate data points for series 2
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

                // Configure custom error bars for the first series (Y direction)
                Aspose.Slides.Charts.IErrorBarsFormat errorBars = series1.ErrorBarsYFormat;
                if (errorBars != null)
                {
                    errorBars.IsVisible = true;
                    errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;
                    errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
                    errorBars.Value = 5f; // Fixed error bar length
                }

                // Save the presentation
                pres.Save("CustomErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}