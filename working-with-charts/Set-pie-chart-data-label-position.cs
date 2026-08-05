// -----------------------------------------------------------------------------
// Example: Set pie chart data label position using C#
//
// Description:
// Demonstrates how to set the data label position for a pie chart using C# 
// and Aspose.Slides for .NET. The example creates a presentation, adds a pie 
// chart, configures the default data label position to appear outside the 
// slices, optionally shows the values, and saves the result as a PPTX file. 
// This pattern can be used to automate PowerPoint chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Data Label, 
// Position, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting pie chart data label positions in presentations.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart label configurations.
// - Validate chart formatting workflows before publishing or integration.
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
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);

        // Set the default data label position for the series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

        // Optionally show the value in data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        pres.Save("PieChartDataLabelPosition.pptx", SaveFormat.Pptx);
    }
}
