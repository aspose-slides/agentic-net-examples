// -----------------------------------------------------------------------------
// Example: Enable display unit label on value axis using C#
//
// Description:
// Demonstrates how to enable a display unit label (e.g., Millions) on the
// vertical value axis of a clustered column chart using Aspose.Slides for .NET.
// The example creates a new presentation, adds a chart, sets the display unit,
// and saves the result as a PPTX file. This pattern can be used to automate
// chart formatting in PowerPoint presentations.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Display Unit, Value Axis, 
// Presentation Automation, .NET
//
// Use Cases:
// - Programmatically set display units for chart axes in PPTX files.
// - Build tools that standardize chart formatting across presentations.
// - Generate PowerPoint reports with correctly labeled value axes.
// - Integrate chart customization into .NET applications.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Enable display unit label on the vertical (value) axis
        chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

        // Save the presentation
        try
        {
            presentation.Save("DisplayUnitLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
