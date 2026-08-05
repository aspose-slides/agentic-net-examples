// -----------------------------------------------------------------------------
// Example: Set data label number format precision using C#
//
// Description:
// Demonstrates how to set a custom numeric format with precision for data
// labels in a line chart using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a line chart, enables data labels for the
// first series, applies a number format (two decimal places as a percentage),
// and saves the result as a PPTX file. This pattern can be used to automate
// chart formatting tasks in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Label, Number Format,
// Precision, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting precise number formats for chart data labels.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart label formatting.
// - Validate chart presentation workflows before deployment.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a line chart to the slide
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

            // Enable data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Define the numeric format for data labels (e.g., two decimal places as percentage)
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

            // Save the presentation
            presentation.Save("PrecisionDataLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
