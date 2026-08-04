// -----------------------------------------------------------------------------
// Example: Set bubble chart scaling factor to 1.5 using C#
//
// Description:
// Demonstrates how to set the bubble chart scaling factor to 1.5 (150%) using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// bubble chart, modifies the scaling factor of the series, and saves the
// result as a PPTX file. This pattern can be used to automate chart formatting
// tasks in PowerPoint files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Bubble Chart, Scaling Factor, 1.5, Chart
// Automation, Presentation Processing
//
// Use Cases:
// - Programmatically adjust bubble size scaling in charts.
// - Build .NET tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart appearance.
// - Validate chart settings before publishing presentations.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

            // Get the first series (default series is created)
            IChartSeries series = chart.ChartData.Series[0];

            // Set the bubble size scaling factor to 150% (1.5)
            series.ParentSeriesGroup.BubbleSizeScale = 150;

            // Save the presentation
            try
            {
                pres.Save("BubbleChartScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
