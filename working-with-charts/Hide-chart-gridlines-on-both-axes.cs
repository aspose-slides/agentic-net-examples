// -----------------------------------------------------------------------------
// Example: Hide chart gridlines on both axes using C#
//
// Description:
// Demonstrates how to hide major gridlines on both the horizontal and vertical
// axes of a chart using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, disables the major gridlines on
// each axis, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Chart, Gridlines, Horizontal Axis, Vertical Axis, Presentation Processing
//
// Use Cases:
// - Programmatically remove chart gridlines from both axes.
// - Build C# utilities for PowerPoint chart styling.
// - Integrate chart formatting into automated PPTX generation workflows.
// - Ensure consistent visual appearance of charts in generated presentations.
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
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Hide major gridlines on the horizontal axis
        chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Hide major gridlines on the vertical axis
        chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Save the presentation
        string outputPath = "HideGridlines.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
