// -----------------------------------------------------------------------------
// Example: Set vertical axis maximum value using C#
//
// Description:
// Demonstrates how to set the vertical axis maximum value for a chart using C#
// and Aspose.Slides for .NET. The example creates a presentation, adds an Area
// chart, disables automatic maximum scaling, sets a custom maximum value, and
// saves the file. This pattern can be used to automate PPTX chart formatting
// tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Vertical Axis, Maximum Value, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically set a custom maximum value for chart vertical axes.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart scaling in .NET.
// - Ensure consistent chart appearance across generated presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 500, 400);

            // Disable automatic max value and set a custom maximum value for the vertical axis
            chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
            chart.Axes.VerticalAxis.MaxValue = 200.0;

            // Save the presentation
            string outPath = "ChartWithMaxValue.pptx";
            presentation.Save(outPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
