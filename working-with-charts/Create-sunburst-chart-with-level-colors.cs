using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

namespace SunburstChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a Sunburst chart to the first slide
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default generated series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a single series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Sunburst);

                // Add hierarchical categories (levels)
                // Level 0 (root)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Root"));
                // Level 1
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Child A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Child B"));
                // Level 2
                chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Grandchild A1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 5, 0, "Grandchild A2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 6, 0, "Grandchild B1"));

                // Populate data points for the Sunburst series
                // Size values determine the slice size
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 1, 1, 30)); // Root
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 2, 1, 20)); // Child A
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 3, 1, 10)); // Child B
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 4, 1, 15)); // Grandchild A1
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 5, 1, 5));  // Grandchild A2
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, 6, 1, 8));  // Grandchild B1

                // Enable varied colors for each data point (including hierarchical levels)
                series.ParentSeriesGroup.IsColorVaried = true;

                // Optionally set explicit colors for specific hierarchy levels
                // Level 0 (root)
                IChartDataPointLevel level0 = series.DataPoints[0].DataPointLevels[0];
                level0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level0.Format.Fill.SolidFillColor.Color = Color.LightBlue;

                // Level 1 (children)
                IChartDataPointLevel level1a = series.DataPoints[1].DataPointLevels[0];
                level1a.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level1a.Format.Fill.SolidFillColor.Color = Color.LightGreen;

                IChartDataPointLevel level1b = series.DataPoints[2].DataPointLevels[0];
                level1b.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level1b.Format.Fill.SolidFillColor.Color = Color.LightCoral;

                // Level 2 (grandchildren)
                IChartDataPointLevel level2a1 = series.DataPoints[3].DataPointLevels[0];
                level2a1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level2a1.Format.Fill.SolidFillColor.Color = Color.LightYellow;

                IChartDataPointLevel level2a2 = series.DataPoints[4].DataPointLevels[0];
                level2a2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level2a2.Format.Fill.SolidFillColor.Color = Color.LightPink;

                IChartDataPointLevel level2b1 = series.DataPoints[5].DataPointLevels[0];
                level2b1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                level2b1.Format.Fill.SolidFillColor.Color = Color.LightGray;

                // Save the presentation
                try
                {
                    pres.Save("SunburstChart.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle exceptions such as unsupported format
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}