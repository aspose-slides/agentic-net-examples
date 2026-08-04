// -----------------------------------------------------------------------------
// Example: Set chart data label background semi transparent using C#
//
// Description:
// Demonstrates how to set a chart data label's background to a semi‑transparent
// color using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a pie chart, modifies the first data point's label background, and saves
// the result as a PPTX file. This pattern can be used to automate PowerPoint
// presentation processing, validate visual styling, or integrate chart
// customization into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Label, Background,
// Semi-Transparent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart data label background to semi‑transparent colors.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with customized chart appearances.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Access the first data point's label
        Aspose.Slides.Charts.IDataLabel label = chart.ChartData.Series[0].DataPoints[0].Label;

        // Set the label background to a semi‑transparent yellow
        label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 255, 0);

        // Save the presentation
        presentation.Save("ChartWithSemiTransparentLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
