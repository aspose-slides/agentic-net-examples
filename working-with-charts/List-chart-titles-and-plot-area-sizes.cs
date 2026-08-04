// -----------------------------------------------------------------------------
// Example: List chart titles and plot area sizes using C#
//
// Description:
// Demonstrates how to enumerate charts in a PowerPoint presentation, retrieve
// each chart's title (if present) and the actual plot area dimensions using
// Aspose.Slides for .NET. The example loads a PPTX file, processes all slides,
// outputs the information to the console, and saves the presentation unchanged.
// This pattern can be used to audit or report chart metadata in automated
// workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Chart, Titles, Plot,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate reports of chart titles and plot area sizes across a presentation.
// - Validate chart layout information in automated quality checks.
// - Build tools that extract chart metadata for further processing or migration.
// - Integrate chart inspection into .NET applications handling PPTX files.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (first argument or default)
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Verify file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                        if (chart != null)
                        {
                            // Ensure layout values are up‑to‑date
                            chart.ValidateChartLayout();

                            // Retrieve chart title text if present
                            string titleText = "";
                            if (chart.HasTitle)
                            {
                                Aspose.Slides.Charts.IChartTitle chartTitle = chart.ChartTitle;
                                if (chartTitle.TextFrameForOverriding != null)
                                {
                                    titleText = chartTitle.TextFrameForOverriding.Text;
                                }
                            }

                            // Get actual plot area size (in points)
                            float plotWidth = chart.PlotArea.ActualWidth;
                            float plotHeight = chart.PlotArea.ActualHeight;

                            Console.WriteLine("Slide " + (slideIndex + 1) + " Chart Title: " + titleText);
                            Console.WriteLine("Plot Area Size - Width: " + plotWidth + " pt, Height: " + plotHeight + " pt");
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
