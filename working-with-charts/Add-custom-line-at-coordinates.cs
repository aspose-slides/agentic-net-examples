// -----------------------------------------------------------------------------
// Example: Add custom line at coordinates using C#
//
// Description:
// Demonstrates how to add a custom straight line annotation at specific
// coordinates to a chart in a PowerPoint presentation using C# and
// Aspose.Slides for .NET. The example creates a new presentation, inserts a
// clustered column chart, adds a line shape to the chart's user shapes at the
// given position, formats the line, and saves the file. This pattern can be
// used to enhance charts with custom visual elements in automated PPTX
// generation or editing scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Custom Line, Coordinates,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Add custom annotations or markers to charts programmatically.
// - Build tools that modify chart visuals in existing presentations.
// - Generate PowerPoint reports with enhanced chart graphics.
// - Automate visual enhancements for data-driven presentations.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

            // Add a custom straight line annotation to the chart at (100, 200)
            // The line is added to the chart's UserShapes collection
            Aspose.Slides.IAutoShape lineShape = chart.UserShapes.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line, 100, 200, 300, 0);

            // Set line formatting (solid red line)
            lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation
            presentation.Save("CustomLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
