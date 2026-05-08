using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a clustered column chart (bar chart) to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Add a linear trend line to the first series
            ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;

            // Set the trend line color to red
            trendline.Format.Line.FillFormat.FillType = FillType.Solid;
            trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation
            pres.Save("BarChartWithTrendline.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}