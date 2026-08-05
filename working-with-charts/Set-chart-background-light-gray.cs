// -----------------------------------------------------------------------------
// Example: Set chart background light gray using C#
//
// Description:
// Demonstrates how to set chart background light gray using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Background, Light Gray, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart background light gray.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set chart background to light gray
                chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                chart.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

                // Preserve automatic callout colors (no changes needed)

                // Save the presentation
                presentation.Save("ChartBackgroundLightGray.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                // Handle any errors (e.g., unsupported format)
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
