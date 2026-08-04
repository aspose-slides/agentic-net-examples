// -----------------------------------------------------------------------------
// Example: Add custom line annotation to chart using C#
//
// Description:
// Demonstrates how to add a custom straight line annotation to a chart in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a clustered column chart, adds a red
// line shape as an annotation to the chart, and saves the result as a PPTX file.
// This pattern can be used to programmatically annotate charts in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Line, Annotation, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add line annotations to charts in PowerPoint files.
// - Automate chart labeling or highlighting in .NET applications.
// - Generate or modify PPTX presentations with custom visual cues.
// - Integrate chart annotation logic into presentation processing workflows.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Add a custom straight line annotation to the chart at (100,200)
        // The line is added to the chart's UserShapes collection
        IAutoShape lineShape = chart.UserShapes.Shapes.AddAutoShape(
            ShapeType.Line,
            100f, 200f, 200f, 0f);
        lineShape.LineFormat.FillFormat.FillType = FillType.Solid;
        lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        try
        {
            presentation.Save("CustomLineChart.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception)
        {
            // Format not supported or other save error
        }
    }
}
