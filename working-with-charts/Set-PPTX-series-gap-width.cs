using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartGapWidthExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Add a clustered column chart
                var chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Set the gap width for the first series (percentage of bar width)
                var firstSeries = chart.ChartData.Series[0];
                firstSeries.ParentSeriesGroup.GapWidth = 150; // 150% gap width

                // Save the presentation
                presentation.Save("ChartGapWidth.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}