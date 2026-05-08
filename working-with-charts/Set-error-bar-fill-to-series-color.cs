using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetErrorBarFillToSeriesColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn);

            // Add three categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Populate series data
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

            // Set line colors for each series
            series1.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

            series2.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Line.FillFormat.SolidFillColor.Color = Color.Green;

            // Configure error bars for each series and match fill color to the series line color
            Aspose.Slides.Charts.IChartSeries[] seriesArray = new Aspose.Slides.Charts.IChartSeries[] { series1, series2 };
            foreach (Aspose.Slides.Charts.IChartSeries series in seriesArray)
            {
                // Ensure Y error bars are allowed for the chart type
                if (Aspose.Slides.Charts.ChartTypeCharacterizer.IsErrorBarsYAllowed(series.Type))
                {
                    Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                    if (errorBars != null)
                    {
                        // Make error bars visible and set type
                        errorBars.IsVisible = true;
                        errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;

                        // Set error bar fill to match the series line color
                        Color lineColor = series.Format.Line.FillFormat.SolidFillColor.Color;
                        errorBars.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                        errorBars.Format.Fill.SolidFillColor.Color = lineColor;
                    }
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("ErrorBarFillMatchSeriesColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}