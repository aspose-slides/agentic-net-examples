// -----------------------------------------------------------------------------
// Example: Set chart data source to dynamic range using C#
//
// Description:
// Demonstrates how to link a chart to an external Excel workbook and set a
// dynamic data range for the chart using Aspose.Slides for .NET. The example
// creates a new presentation, adds a chart without sample data, connects it to
// a specified workbook, applies a range that can be expanded, and saves the
// resulting PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, External Workbook, Dynamic
// Range, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate linking chart data to external Excel sources.
// - Build tools that set or update chart data ranges dynamically.
// - Generate PowerPoint presentations with charts driven by external data.
// - Validate chart data bindings in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the external Excel workbook and output presentation
        string excelPath = "data.xlsx";
        string outputPath = "output.pptx";

        // Verify that the Excel file exists
        if (!File.Exists(excelPath))
        {
            Console.WriteLine("Excel file not found: " + excelPath);
            return;
        }

        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a chart without sample data (initWithSample = false)
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f, false);

        try
        {
            // Link the chart to the external workbook and load its data
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(excelPath, true);

            // Set a dynamic range (e.g., a named range or a range that can expand)
            chart.ChartData.SetRange("Sheet1!$A$1:$B$100");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Range formula is null: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Invalid range format: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            // format not supported
            Console.WriteLine("Operation not supported: " + ex.Message);
        }

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
