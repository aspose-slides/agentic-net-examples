using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace SetErrorBarStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Access the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, 10), Aspose.Slides.Charts.ChartType.ClusteredColumn);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add data points to the series
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 30));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 40));

                // Configure error bars if the chart type supports them
                if (Aspose.Slides.Charts.ChartTypeCharacterizer.IsErrorBarsYAllowed(chart.Type))
                {
                    // Make error bars visible
                    series.ErrorBarsYFormat.IsVisible = true;

                    // Set error bar type (both positive and negative directions)
                    series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;

                    // Set error bar line thickness
                    series.ErrorBarsYFormat.Format.Line.Width = 2f;

                    // Set error bar line color
                    series.ErrorBarsYFormat.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    series.ErrorBarsYFormat.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                }

                // Save the presentation
                presentation.Save("ErrorBarStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}