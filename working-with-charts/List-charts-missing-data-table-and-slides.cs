// -----------------------------------------------------------------------------
// Example: List charts missing data table and slides using C#
//
// Description:
// Demonstrates how to enumerate slides in a PowerPoint presentation and list
// charts that do not have an associated data table using Aspose.Slides for .NET.
// The example loads a PPTX file, checks each chart on every slide, writes the
// slide numbers of charts without data tables to the console, and saves the
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Charts, Missing, Data,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Identify charts lacking data tables in existing presentations.
// - Automate validation of chart completeness before publishing.
// - Build tools that report or fix missing chart data tables in bulk.
// - Integrate chart analysis into .NET PowerPoint processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ListChartsMissingDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect the presentation file path as the first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: ListChartsMissingDataTable <presentation-path>");
                return;
            }

            string presentationPath = args[0];

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Error: File does not exist - " + presentationPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Presentation pres = null;
            try
            {
                pres = new Presentation(presentationPath);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through slides and list charts without data tables
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                foreach (IShape shape in slide.Shapes)
                {
                    IChart chart = shape as IChart;
                    if (chart != null && chart.HasDataTable == false)
                    {
                        // Output slide number (1‑based)
                        Console.WriteLine("Slide " + (slideIndex + 1) + " contains a chart without a data table.");
                    }
                }
            }

            // Save the presentation before exiting (optional: overwrite or new file)
            string outputPath = Path.Combine(Path.GetDirectoryName(presentationPath), "output.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}
