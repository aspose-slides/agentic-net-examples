// -----------------------------------------------------------------------------
// Example: Add Data Table to Chart and Set Font Size using Aspose.Slides for .NET
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, enables its data table, customizes the data table
// font height for better readability, and saves the file as PPTX. It uses
// Aspose.Slides for .NET to automate chart formatting in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart data table, font size, clustered column chart
//
// Use Cases:
// - Automatically generate reports with charts that include data tables.
// - Standardize chart appearance across multiple presentations.
// - Enhance readability of chart data tables in automated slide decks.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesChartDataTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ChartWithDataTable.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);

                // Enable the data table for the chart
                chart.HasDataTable = true;

                // Set the font height of the data table for readability
                chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 12f;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (System.IO.IOException ioEx)
            {
                Console.WriteLine("IO error: " + ioEx.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
