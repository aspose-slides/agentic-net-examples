// -----------------------------------------------------------------------------
// Example: Delete series from line chart by name using C#
//
// Description:
// Demonstrates how to delete a specific series from a line chart by its
// name using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// finds the first line chart on the first slide, removes the series whose
// name matches the target, and saves the updated presentation. This pattern
// can be used to automate chart data manipulation in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Delete Series, Line Chart,
// Chart Manipulation, Presentation Processing, Office Automation
//
// Use Cases:
// - Remove unwanted data series from line charts in existing presentations.
// - Build tools that programmatically clean or modify chart data.
// - Integrate chart series management into .NET applications.
// - Prepare PPTX files for publishing by eliminating specific series.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide (adjust index if needed)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Locate a line chart on the slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null && chart.Type == Aspose.Slides.Charts.ChartType.Line)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No line chart found on the first slide.");
                // Save the presentation unchanged
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Name of the series to be removed
            string targetSeriesName = "Series To Delete";

            // Find the series with the specified name
            Aspose.Slides.Charts.IChartSeries seriesToRemove = null;
            foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
            {
                // Compare the literal string value of the series name
                if (series.Name != null && series.Name.AsLiteralString == targetSeriesName)
                {
                    seriesToRemove = series;
                    break;
                }
            }

            if (seriesToRemove != null)
            {
                // Remove the identified series from the chart
                chart.ChartData.Series.Remove(seriesToRemove);
                Console.WriteLine("Series removed: " + targetSeriesName);
            }
            else
            {
                Console.WriteLine("Series not found: " + targetSeriesName);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
