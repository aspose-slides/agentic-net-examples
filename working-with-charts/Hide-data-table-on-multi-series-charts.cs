using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            // Add a chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);
            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;
            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();
            // Add categories
            for (int i = 0; i < 3; i++)
            {
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, i + 1, 0, "Category " + (i + 1)));
            }
            // Add 12 series (more than ten)
            for (int s = 0; s < 12; s++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(wb.GetCell(defaultWorksheetIndex, 0, s + 1, "Series " + (s + 1)), chart.Type);
                // Add data points for each category
                for (int c = 0; c < 3; c++)
                {
                    series.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, c + 1, s + 1, (c + 1) * (s + 1) * 10));
                }
            }
            // Hide data table if the chart has more than ten series
            if (chart.ChartData.Series.Count > 10)
            {
                chart.HasDataTable = false;
            }
            // Save the presentation
            pres.Save("HideDataTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}