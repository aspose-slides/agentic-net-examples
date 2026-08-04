// -----------------------------------------------------------------------------
// Example: Set chart background solid to theme color using C#
//
// Description:
// Demonstrates how to create a presentation, add a clustered column chart,
// set the chart background to a solid fill using a theme accent color, and
// save the result as a PPTX file using Aspose.Slides for .NET. This example
// illustrates the essential steps for chart manipulation and background styling
// in PowerPoint automation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Background, Solid,
// Theme, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart background to a theme color.
// - Build C# tools for PowerPoint chart styling.
// - Generate or modify PPTX files with customized chart appearances.
// - Validate presentation workflows involving chart formatting.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Charts.IChart chart = slide.Shapes.AddChart(Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

            // Set the chart background to a solid fill using a theme accent color
            chart.FillFormat.FillType = FillType.Solid;
            chart.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;

            // Save the presentation
            presentation.Save("ChartBackgroundTheme.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions
        }
    }
}
