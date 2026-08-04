// -----------------------------------------------------------------------------
// Example: Add 3d bar chart with rotation using C#
//
// Description:
// Demonstrates how to add a 3D bar chart (implemented as a stacked column 3D chart)
// with custom rotation and depth settings using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts a chart, configures its 3D
// properties, adds a title, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D Chart, Bar Chart, Rotation,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of 3D bar charts with specific rotation in PowerPoint.
// - Build C# utilities for generating or modifying PPTX files with advanced chart
//   visualizations.
// - Integrate 3D chart generation into .NET applications or reporting tools.
// - Validate chart rendering and layout before publishing presentations.
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

        // Add a new empty slide based on the layout of the first slide
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a 3D stacked column chart (used as a 3D bar chart)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn3D, 50f, 50f, 500f, 400f);

        // Set 3D rotation and depth properties
        chart.Rotation3D.RightAngleAxes = false;
        chart.Rotation3D.RotationX = 20; // SByte value between -90 and 90
        chart.Rotation3D.RotationY = 30; // UInt16 value between 0 and 360
        chart.Rotation3D.DepthPercents = 200; // UInt16 value between 20 and 2000

        // Add a title to the chart
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("3D Bar Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Save the presentation
        try
        {
            presentation.Save("3DBarChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other save errors
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
