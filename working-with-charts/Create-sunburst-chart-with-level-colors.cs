using System;
using Aspose.Slides.Export;

namespace SunburstChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a Sunburst chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Clear default data
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                wb.Clear(0);

                // Add categories with grouping (two hierarchical levels)
                Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(
                    wb.GetCell(0, 1, 0, "Stem1"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch1");

                leaf = chart.ChartData.Categories.Add(
                    wb.GetCell(0, 2, 0, "Stem2"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch1");

                leaf = chart.ChartData.Categories.Add(
                    wb.GetCell(0, 3, 0, "Stem3"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem3");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch2");

                leaf = chart.ChartData.Categories.Add(
                    wb.GetCell(0, 4, 0, "Stem4"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem4");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch2");

                // Add a series for the Sunburst chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    Aspose.Slides.Charts.ChartType.Sunburst);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points (size values)
                series.DataPoints.AddDataPointForSunburstSeries(
                    wb.GetCell(0, 1, 1, 10));
                series.DataPoints.AddDataPointForSunburstSeries(
                    wb.GetCell(0, 2, 1, 20));
                series.DataPoints.AddDataPointForSunburstSeries(
                    wb.GetCell(0, 3, 1, 30));
                series.DataPoints.AddDataPointForSunburstSeries(
                    wb.GetCell(0, 4, 1, 40));

                // Assign distinct colors to each hierarchical level
                Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    Aspose.Slides.Charts.IChartDataPoint point = dataPoints[i];

                    // Level 0 (Stem) - Light Blue
                    Aspose.Slides.Charts.IChartDataPointLevel level0 = point.DataPointLevels[0];
                    level0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    level0.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(173, 216, 230);

                    // Level 1 (Branch) - Light Green
                    Aspose.Slides.Charts.IChartDataPointLevel level1 = point.DataPointLevels[1];
                    level1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    level1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(144, 238, 144);
                }

                // Save the presentation
                pres.Save("SunburstColored.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}