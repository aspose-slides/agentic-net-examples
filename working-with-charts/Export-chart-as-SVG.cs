// -----------------------------------------------------------------------------
// Example: Export chart as SVG using C#
//
// Description:
// Demonstrates how to export a chart as an SVG file using C# and Aspose.Slides for .NET. 
// The example creates a presentation, adds a line chart, configures its data table 
// and number format, writes the chart to an SVG file, and finally saves the presentation.
// Developers can use this pattern to automate PPTX workflows, extract chart graphics, 
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Chart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts as SVG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable data table and set number format for values
        chart.HasDataTable = true;
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Export the chart as an SVG file
        string svgFilePath = "chart.svg";
        try
        {
            using (FileStream svgStream = File.Create(svgFilePath))
            {
                chart.WriteAsSvg(svgStream);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
