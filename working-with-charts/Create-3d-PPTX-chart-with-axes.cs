using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ThreeDimensionalChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a 3D clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 50f, 50f, 500f, 400f);

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("3D Column Chart");

                    // Access the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Add first series
                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.ClusteredColumn3D);
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
                    series1.Format.Fill.FillType = FillType.Solid;
                    series1.Format.Fill.SolidFillColor.Color = Color.Red;

                    // Add second series
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), ChartType.ClusteredColumn3D);
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
                    series2.Format.Fill.FillType = FillType.Solid;
                    series2.Format.Fill.SolidFillColor.Color = Color.Green;

                    // Configure horizontal axis
                    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                    horizontalAxis.HasTitle = true;
                    horizontalAxis.Title.AddTextFrameForOverriding("Categories");

                    // Configure vertical axis
                    IAxis verticalAxis = chart.Axes.VerticalAxis;
                    verticalAxis.HasTitle = true;
                    verticalAxis.Title.AddTextFrameForOverriding("Values");

                    // Set 3D rotation and depth
                    IRotation3D rotation = chart.Rotation3D;
                    rotation.RotationX = 20;
                    rotation.RotationY = 30;
                    rotation.DepthPercents = 150;
                    rotation.HeightPercents = 100;

                    // Do NOT call ValidateChartLayout for 3D chart (avoids runtime error)

                    // Save the presentation
                    string outputPath = "ThreeDChart.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}