using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetErrorBarLineStyle
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 0, 0, 500, 400);

            // Ensure the chart has at least one series
            if (chart.ChartData.Series.Count == 0)
            {
                // Add a sample series if none exist
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Line);
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
                chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            }

            // Get the first series
            IChartSeries series = chart.ChartData.Series[0];

            // Make error bars visible (Y direction) and set dash style to DashDot
            if (series.ErrorBarsYFormat != null)
            {
                series.ErrorBarsYFormat.IsVisible = true;
                series.ErrorBarsYFormat.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
            }

            // Save the presentation
            pres.Save("SetErrorBarLineStyle.pptx", SaveFormat.Pptx);
        }
    }
}