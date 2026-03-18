using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlides3DChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a 3D clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 50, 50, 500, 400);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("3D Column Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                // Set chart style (use existing enum member)
                chart.Style = StyleType.Style3;

                // Configure 3D rotation
                IRotation3D rotation = chart.Rotation3D;
                rotation.RotationX = 20; // tilt around X axis
                rotation.RotationY = 30; // tilt around Y axis
                rotation.DepthPercents = 150;
                rotation.HeightPercents = 100;
                rotation.Perspective = 30;
                rotation.RightAngleAxes = false;

                // Access chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add first series
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
                series1.Format.Fill.FillType = FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Red;

                // Add second series
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
                series2.Format.Fill.FillType = FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.Green;

                // Configure axes visibility
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                horizontalAxis.IsVisible = true;
                verticalAxis.IsVisible = true;

                // Set axis titles
                horizontalAxis.Title.AddTextFrameForOverriding("Categories");
                verticalAxis.Title.AddTextFrameForOverriding("Values");

                // Validate layout
                chart.ValidateChartLayout();

                // Save the presentation
                pres.Save("3DChartOutput.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}