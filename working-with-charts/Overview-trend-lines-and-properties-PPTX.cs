using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;

namespace TrendlineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart with sample data
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f);

            // Get the first series of the chart
            IChartSeries firstSeries = chart.ChartData.Series[0];

            // Add a linear trendline to the first series
            ITrendline linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
            linearTrendline.DisplayEquation = true;
            linearTrendline.DisplayRSquaredValue = true;
            linearTrendline.Forward = 2.0;
            linearTrendline.Backward = 1.0;
            linearTrendline.TrendlineName = "Linear Trendline";

            // Add a polynomial trendline to the first series
            ITrendline polyTrendline = firstSeries.TrendLines.Add(TrendlineType.Polynomial);
            polyTrendline.Order = 3; // Cubic polynomial
            polyTrendline.DisplayEquation = true;
            polyTrendline.DisplayRSquaredValue = true;
            polyTrendline.TrendlineName = "Cubic Polynomial Trendline";

            // Add a text box describing trendline properties
            IAutoShape descriptionShape = (IAutoShape)slide.Shapes.AddAutoShape(
                ShapeType.Rectangle, 50f, 470f, 500f, 100f);
            descriptionShape.AddTextFrame(
                "Trendline Overview:\n" +
                "- Linear Trendline: shows equation and R², extends 2 points forward, 1 point backward.\n" +
                "- Cubic Polynomial Trendline: shows equation and R², order = 3.");

            // Save the presentation
            presentation.Save("TrendlinesOverview.pptx", SaveFormat.Pptx);
        }
    }
}