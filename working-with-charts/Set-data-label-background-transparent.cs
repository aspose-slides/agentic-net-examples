// -----------------------------------------------------------------------------
// Example: Set data label background transparent using C#
//
// Description:
// Demonstrates how to set the background of data labels in a chart to transparent using C# and Aspose.Slides for .NET. The example creates a presentation, adds a pie chart, modifies the default data label format to use a transparent fill, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Label, Background, Transparent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate making chart data label backgrounds transparent.
// - Build C# tools for customizing chart appearance in PowerPoint files.
// - Generate or modify PPTX presentations with specific chart styling.
// - Validate chart formatting before publishing or integration.
// -----------------------------------------------------------------------------
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

        // Set the data label background to transparent
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Format.Fill.SolidFillColor.Color = Color.Transparent;

        // Save the presentation
        try
        {
            presentation.Save("ChartWithTransparentLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions such as unsupported format
            // Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
