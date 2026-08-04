// -----------------------------------------------------------------------------
// Example: Set doughnut chart hole to fifty percent using C#
//
// Description:
// Demonstrates how to create a doughnut chart in a PowerPoint presentation
// and set its hole size to fifty percent using Aspose.Slides for .NET. The
// example creates a new presentation, adds a doughnut chart, configures the
// doughnut hole size, and saves the file as a PPTX. This pattern can be used
// to automate chart formatting tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Doughnut Chart, Chart Hole,
// Fifty Percent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting doughnut chart hole size to fifty percent in PPTX files.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify presentations with specific chart aesthetics.
// - Validate chart configurations programmatically before distribution.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            // Add a doughnut chart at position (50,50) with size 500x400
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 500f, 400f);
            // Set the doughnut hole size to 50%
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;
            // Save the presentation
            pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
