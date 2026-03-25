using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Custom3DChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "Custom3DChart.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a 3D stacked column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.StackedColumn3D,
                    0f, 0f, 500f, 500f);

                // Configure 3D rotation
                chart.Rotation3D.RightAngleAxes = false;          // Enable perspective
                chart.Rotation3D.RotationX = -30;                // Rotate around X axis
                chart.Rotation3D.RotationY = 40;                 // Rotate around Y axis
                chart.Rotation3D.DepthPercents = 200;            // Depth of the chart
                chart.Rotation3D.Perspective = 30;               // Perspective angle

                // Access the chart data workbook
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate first series data points
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Set fill color for first series
                series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.CornflowerBlue;

                // Populate second series data points
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                // Set fill color for second series
                series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.OrangeRed;

                // Adjust series group properties for better 3D visual
                series1.ParentSeriesGroup.GapDepth = 150;   // Increase depth gap between series
                series1.ParentSeriesGroup.Overlap = 20;    // Slight overlap

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}