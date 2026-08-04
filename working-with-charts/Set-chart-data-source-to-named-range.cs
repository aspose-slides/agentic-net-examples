// -----------------------------------------------------------------------------
// Example: Set chart data source to named range using C#
//
// Description:
// Demonstrates how to link a chart to an external Excel workbook and set its
// data source to a named range using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a clustered column chart, connects it to a
// workbook file, assigns a named range as the chart data source, and saves the
// resulting PPTX. This pattern helps automate PowerPoint chart data binding in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data, Source, Named Range,
// External Workbook, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart data source to a named range in PowerPoint files.
// - Build C# tools for linking charts to external Excel data.
// - Generate or modify PPTX presentations with dynamic chart data in .NET.
// - Validate chart data bindings before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "SetChartDataSource.pptx";
        string workbookPath = "Data.xlsx";

        // Verify that the Excel workbook exists
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook file not found: " + workbookPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Link the chart to the external workbook and load its data
                ((ChartData)chart.ChartData).SetExternalWorkbook(workbookPath, true);

                // Set the chart's data source to a named range defined in the workbook
                ((ChartData)chart.ChartData).SetRange("Sheet1!MyData");

                // Save the presentation
                pres.Save(presentationPath, SaveFormat.Pptx);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid operation: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
