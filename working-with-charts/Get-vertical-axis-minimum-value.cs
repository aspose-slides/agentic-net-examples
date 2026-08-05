// -----------------------------------------------------------------------------
// Example: Get vertical axis minimum value using C#
//
// Description:
// Demonstrates how to retrieve the minimum value of the vertical axis from an
// Area chart using Aspose.Slides for .NET. The example creates a presentation,
// adds an Area chart, validates its layout, reads the vertical axis MinValue,
// outputs it to the console, and saves the presentation. This pattern can be
// used to programmatically inspect chart axis settings in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Axis, Vertical, Minimum,
// Value, Presentation Processing, Office Automation
//
// Use Cases:
// - Extract vertical axis minimum values from charts in PPTX files.
// - Automate validation of chart axis settings.
// - Build tools that analyze or modify PowerPoint chart data.
// - Integrate chart property retrieval into .NET applications.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Output file path
        string outPath = "AxisMinValue_out.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 500, 400);

        // Validate chart layout to ensure axis values are calculated
        chart.ValidateChartLayout();

        // Retrieve the minimum value of the vertical axis using MinValue property
        double minValue = chart.Axes.VerticalAxis.MinValue;

        // Output the retrieved value
        Console.WriteLine("Vertical Axis MinValue: " + minValue);

        // Save the presentation
        pres.Save(outPath, SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}
