using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace GetAutomaticSeriesFillColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Iterate through each series and retrieve its automatic fill color
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                Color automaticColor = chart.ChartData.Series[i].GetAutomaticSeriesColor();
                Console.WriteLine($"Series {i} automatic fill color: {automaticColor}");
            }

            // Save the presentation
            presentation.Save("AutomaticSeriesFillColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}