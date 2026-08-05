// -----------------------------------------------------------------------------
// Example: Hide vertical axis on line chart using C#
//
// Description:
// Demonstrates how to hide the vertical axis on a line chart using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a line chart,
// hides its vertical axis, and saves the result as a PPTX file. This pattern can be
// used to automate PowerPoint chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Vertical, Axis, Line Chart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding the vertical axis on line charts in presentations.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files programmatically in .NET.
// - Validate chart appearance before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

namespace HideVerticalAxisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

            // Hide the vertical axis
            chart.Axes.VerticalAxis.IsVisible = false;

            // Save the presentation
            pres.Save("HideVerticalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
