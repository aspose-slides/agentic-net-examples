// -----------------------------------------------------------------------------
// Example: Check data table visibility on chart using C#
//
// Description:
// Demonstrates how to determine whether a chart's data table is visible in a
// PowerPoint presentation using Aspose.Slides for .NET. The example loads a
// PPTX file, accesses the first chart on the first slide, checks the
// HasDataTable property, outputs the result, and saves the presentation.
// This pattern can be used to automate validation of chart data tables in
// PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Table, Visibility,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Verify chart data table visibility before publishing a presentation.
// - Build tools that audit or modify chart settings in PPTX files.
// - Integrate chart validation into .NET automation workflows.
// - Ensure consistency of chart data tables across multiple presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Access first slide and first shape (assumed to be a chart)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
        }
        else
        {
            bool isVisible = IsChartDataTableVisible(chart);
            Console.WriteLine("Chart data table visible: " + isVisible);
        }

        try
        {
            // Save presentation before exit
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }

    // Returns true if the chart's data table is visible
    static bool IsChartDataTableVisible(Aspose.Slides.Charts.IChart chart)
    {
        // The HasDataTable property indicates visibility of the data table
        return chart.HasDataTable;
    }
}
