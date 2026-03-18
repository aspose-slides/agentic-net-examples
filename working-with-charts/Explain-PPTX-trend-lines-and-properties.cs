using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TrendLineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a title slide
                    ISlide titleSlide = presentation.Slides[0];
                    IAutoShape titleShape = (IAutoShape)titleSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 100);
                    titleShape.TextFrame.Text = "Trend Lines Overview";

                    // Add a new slide for the chart
                    ISlide chartSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    // Add a line chart
                    IChart chart = chartSlide.Shapes.AddChart(ChartType.Line, 50, 150, 600, 300);
                    // Access the first series
                    IChartSeries series = chart.ChartData.Series[0];
                    // Add a linear trendline to the series
                    ITrendline trendline = series.TrendLines.Add(TrendlineType.Linear);
                    trendline.DisplayEquation = true;
                    trendline.DisplayRSquaredValue = true;
                    trendline.TrendlineName = "Linear Trendline";

                    // Add a description shape
                    IAutoShape descShape = (IAutoShape)chartSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 470, 600, 150);
                    descShape.TextFrame.Text = "This chart demonstrates a linear trendline with equation and R² value displayed.";

                    // Save the presentation
                    presentation.Save("TrendLinesOverview.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}