// -----------------------------------------------------------------------------
// Example: Configure trendline lengths five categories column chart using C#
//
// Description:
// Demonstrates how to add a clustered column chart to a presentation and
// configure a linear trendline with forward and backward lengths set to five
// categories using Aspose.Slides for .NET. The example creates a new PPTX,
// adds the chart, applies the trendline settings, and saves the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Trendline, Lengths,
// Five, Column Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting trendline forward/backward lengths for column charts.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific trendline configurations.
// - Validate chart trendline settings in .NET applications.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add a linear trendline to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);

        // Set forward and backward lengths to five categories
        trendline.Forward = 5;
        trendline.Backward = 5;

        // Save the presentation
        presentation.Save("TrendlineForwardBackward.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
