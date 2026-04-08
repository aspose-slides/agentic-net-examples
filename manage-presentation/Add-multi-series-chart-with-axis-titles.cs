using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AddMultiSeriesChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outPath = "MultiSeriesChart_out.pptx";

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart without sample data
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400, false);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Multi-Series Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Set chart style
                chart.Style = StyleType.Style1;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get reference to the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.ClusteredColumn);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

                // Add three categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate first series data points
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
                series1.Format.Fill.FillType = FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Red;

                // Populate second series data points
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
                series2.Format.Fill.FillType = FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.Green;

                // Set axis titles
                chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("Categories");
                chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Values");

                // Save the presentation
                try
                {
                    pres.Save(outPath, SaveFormat.Pptx);
                }
                catch (System.Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }

            // Verify that the file was created
            if (File.Exists(outPath))
            {
                Console.WriteLine("Presentation saved successfully: " + outPath);
            }
            else
            {
                Console.WriteLine("Failed to create the presentation file.");
            }
        }
    }
}