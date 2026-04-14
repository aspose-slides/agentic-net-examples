using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Add an exponential trendline to the first series
        ITrendline exponentialTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
        exponentialTrendline.DisplayEquation = false;
        exponentialTrendline.DisplayRSquaredValue = false;

        // Add a linear trendline to the same series and set its line color to red
        ITrendline linearTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
        linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
        linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // Add a logarithmic trendline with custom text
        ITrendline logarithmicTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Logarithmic);
        logarithmicTrendline.AddTextFrameForOverriding("Logarithmic Trend");

        // Add a moving average trendline with period and name
        ITrendline movingAverageTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.MovingAverage);
        movingAverageTrendline.Period = 3;
        movingAverageTrendline.TrendlineName = "MA3";

        // Add a polynomial trendline with order and forward offset
        ITrendline polynomialTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Polynomial);
        polynomialTrendline.Order = 2;
        polynomialTrendline.Forward = 1;

        // Add a power trendline with backward offset
        ITrendline powerTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Power);
        powerTrendline.Backward = 1;

        // Save the presentation (ensure format is supported)
        string pptxPath = "TrendLinesPresentation.pptx";
        try
        {
            presentation.Save(pptxPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Export the first slide as an SVG file
        string svgPath = "Slide1.svg";
        using (FileStream svgStream = File.Create(svgPath))
        {
            presentation.Slides[0].WriteAsSvg(svgStream);
        }

        // The SVG file can now be inspected for trend line elements
    }
}