using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace InvertedFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide's shape collection
            IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a clustered column chart
            IChart chart = shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Ensure the series uses a solid fill
            series.Format.Fill.FillType = FillType.Solid;

            // Set the inverted solid fill color (the color used when values are negative)
            series.InvertedSolidFillColor.Color = System.Drawing.Color.Red;

            // Save the presentation
            pres.Save("InvertedFillChart.pptx", SaveFormat.Pptx);
        }
    }
}