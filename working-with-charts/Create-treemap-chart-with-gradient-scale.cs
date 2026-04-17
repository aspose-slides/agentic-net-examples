using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a Treemap chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 600, 400);

            // Get the chart data workbook
            IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series for the treemap
            IChartSeries series = chart.ChartData.Series.Add(wb.GetCell(0, 0, 0, "Series 1"), ChartType.Treemap);

            // Enable varied colors to create a gradient effect based on data magnitude
            series.ParentSeriesGroup.IsColorVaried = true;

            // Define categories and corresponding size values
            string[] categories = new string[] { "A", "B", "C", "D", "E" };
            double[] sizes = new double[] { 10, 30, 20, 40, 50 };

            for (int i = 0; i < categories.Length; i++)
            {
                // Add a category
                chart.ChartData.Categories.Add(wb.GetCell(0, i + 1, 0, categories[i]));

                // Add a data point with the size value
                IChartDataPoint point = series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, i + 1, 1, sizes[i]));

                // Optional: set a fill color based on the size (simple red‑to‑green gradient)
                int red = (int)(255 - (sizes[i] / 50.0) * 255);
                int green = (int)((sizes[i] / 50.0) * 255);
                Color fillColor = Color.FromArgb(red, green, 0);
                point.Format.Fill.SolidFillColor.Color = fillColor;
            }

            // Save the presentation
            try
            {
                pres.Save("TreemapGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (ArgumentException)
            {
                // Format not supported
            }
        }
    }
}