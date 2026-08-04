// -----------------------------------------------------------------------------
// Example: Set bar chart gap width using C#
//
// Description:
// Demonstrates how to set the gap width of a bar (clustered column) chart using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, modifies the gap width of its first series, and saves
// the result as a PPTX file. This pattern can be used to automate PPTX chart
// formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Gap Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting gap width for bar charts in presentations.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart styling in .NET.
// - Validate chart appearance programmatically before publishing.
// -----------------------------------------------------------------------------
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
