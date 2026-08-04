// -----------------------------------------------------------------------------
// Example: Hide gridlines on secondary axis using C#
//
// Description:
// Demonstrates how to hide major and minor gridlines on the secondary vertical
// axis of a chart using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, plots the first series on the
// secondary axis, disables gridlines, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Gridlines, Secondary,
// Axis, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding gridlines on secondary axes in PowerPoint charts.
// - Build C# utilities for chart formatting in presentations.
// - Generate or modify PPTX files with customized axis settings.
// - Validate chart appearance before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Plot the first series on the secondary vertical axis
        chart.ChartData.Series[0].PlotOnSecondAxis = true;

        // Hide major gridlines on the secondary vertical axis
        chart.Axes.SecondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Hide minor gridlines on the secondary vertical axis
        chart.Axes.SecondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Save the presentation
        pres.Save("HideSecondaryAxisGridlines.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}
