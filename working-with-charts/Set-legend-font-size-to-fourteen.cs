// -----------------------------------------------------------------------------
// Example: Set legend font size to fourteen using C#
//
// Description:
// Demonstrates how to set the legend font size of a chart to fourteen points 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a clustered column chart, modifies the legend font size, and saves the 
// result as a PPTX file. This pattern can be used to automate PowerPoint 
// presentation processing tasks involving chart legends.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Legend, Font, Size, Fourteen, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend font size to fourteen points.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify PPTX files with specific legend styling in .NET 
//   applications.
// - Validate presentation formatting before publishing or integration.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Set the overall legend font size to 14 points
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Save the presentation
        presentation.Save("LegendFontSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
