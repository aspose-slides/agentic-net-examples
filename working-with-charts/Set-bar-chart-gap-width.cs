using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart (bar chart)
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Adjust the gap width of the first series to enhance visual separation
            IChartSeries series = chart.ChartData.Series[0];
            series.ParentSeriesGroup.GapWidth = 150; // Gap width as a percentage of bar width

            // Save the presentation
            try
            {
                pres.Save("BarChartGapWidth.pptx", SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }
        }
    }
}