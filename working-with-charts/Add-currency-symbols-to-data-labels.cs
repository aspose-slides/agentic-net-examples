// -----------------------------------------------------------------------------
// Example: Add currency symbols to data labels using C#
//
// Description:
// Demonstrates how to add currency symbols to data labels in a chart using C#
// and Aspose.Slides for .NET. The example creates a new presentation, inserts a
// pie chart, enables value display for the first series, applies a custom
// number format with a currency symbol, and saves the presentation as a PPTX
// file. This pattern can be used to automate chart formatting tasks in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Currency, Symbols, Data Labels,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding currency symbols to chart data labels.
// - Build C# tools for PowerPoint chart formatting.
// - Generate or modify PPTX files with customized chart labels in .NET
//   applications.
// - Validate chart presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomDataLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var pres = new Aspose.Slides.Presentation();

                // Get the first slide
                var slide = pres.Slides[0];

                // Add a Pie chart to the slide
                var chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    50f, 50f, 500f, 400f);

                // Enable value display for data labels
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set custom number format with currency symbol
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "$#,##0.00";

                // Save the presentation
                pres.Save("CustomDataLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
