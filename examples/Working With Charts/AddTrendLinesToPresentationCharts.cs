using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add a linear trend line to the series
        Aspose.Slides.Charts.ITrendline trendline = series.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
        trendline.DisplayEquation = true;
        trendline.DisplayRSquaredValue = true;
        trendline.TrendlineName = "Linear Trend";

        // Save the presentation
        pres.Save("ChartWithTrendline.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}