// -----------------------------------------------------------------------------
// Example: Configure bubble chart size to area using C#
//
// Description:
// Demonstrates how to configure a bubble chart's size representation to Area 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a bubble chart, sets the BubbleSizeRepresentation to Area for accurate 
// proportional scaling, and saves the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Bubble Chart, Size, 
// Area Representation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting bubble chart size representation to Area.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with correctly scaled bubble charts.
// - Validate chart rendering before publishing or integration.
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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a bubble chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Area for accurate proportionality
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Area;

        // Save the presentation
        presentation.Save("BubbleChartArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
