using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Add an exponential trend line to the first series
        Aspose.Slides.Charts.ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Exponential);
        exponentialTrend.DisplayEquation = false;
        exponentialTrend.DisplayRSquaredValue = false;

        // Add a linear trend line to the second series and set its line color to red
        Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[1].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // If a third series exists, add a logarithmic trend line and set a custom text
        if (chart.ChartData.Series.Count > 2)
        {
            Aspose.Slides.Charts.ITrendline logarithmicTrend = chart.ChartData.Series[2].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            logarithmicTrend.AddTextFrameForOverriding("Logarithmic Trend");
        }

        // Save the presentation
        presentation.Save("AddTrendLines_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}