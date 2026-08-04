// -----------------------------------------------------------------------------
// Example: Hide gridlines on both axes using C#
//
// Description:
// Demonstrates how to create a new presentation, add a clustered column chart,
// hide major gridlines on both the horizontal and vertical axes, and save the
// result as a PPTX file using Aspose.Slides for .NET. This example illustrates
// the necessary steps for manipulating chart axis gridlines in PowerPoint files
// within a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Gridlines, Both, Axes,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding gridlines on both axes in generated charts.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with customized chart appearances.
// - Validate presentation workflows before publishing or integration.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
        // Hide major gridlines on the horizontal axis
        chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        // Hide major gridlines on the vertical axis
        chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        // Save the presentation
        try
        {
            presentation.Save("HideGridlines.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle exceptions such as unsupported format
        }
    }
}
