// -----------------------------------------------------------------------------
// Example: Set axis position using enumeration using C#
//
// Description:
// Demonstrates how to set the positions of the horizontal and vertical axes
// of a chart using enumeration values in C# with Aspose.Slides for .NET.
// The example creates a presentation, adds a clustered column chart, sets the
// axis positions, and saves the result as a PPTX file. This pattern can be
// used to automate chart formatting in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Axis, Position, Enumeration,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart axis positions using enumeration values.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or modify PPTX files with specific chart layouts in .NET applications.
// - Validate chart formatting before publishing or integration.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Set the position of the horizontal axis to the bottom of the plot area
        chart.Axes.HorizontalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;

        // Set the position of the vertical axis to the left of the plot area
        chart.Axes.VerticalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;

        // Save the presentation
        presentation.Save("ChartAxisPosition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
