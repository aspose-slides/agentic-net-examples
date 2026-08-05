// -----------------------------------------------------------------------------
// Example: Detect data tables in charts log indices using C#
//
// Description:
// Demonstrates how to detect data tables in charts within a PowerPoint presentation using C# and 
// Aspose.Slides for .NET. The example iterates through slides and shapes, identifies charts that have
// visible data tables, logs their slide indices, and saves the presentation.
// This pattern helps automate PPTX analysis, validation, or transformation tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Data Tables, Charts, Presentation Processing, Office Automation
//
// Use Cases:
// - Identify charts with visible data tables in existing presentations.
// - Build tools to audit or modify PPTX files based on chart data table presence.
// - Integrate chart analysis into .NET applications for reporting or validation.
// - Automate preprocessing steps before publishing or further processing of presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DetectDataTablesInCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        foreach (IShape shape in slide.Shapes)
                        {
                            IChart chart = shape as IChart;
                            if (chart != null && chart.HasDataTable)
                            {
                                Console.WriteLine("Chart with visible data table found on slide index: " + slideIndex);
                            }
                        }
                    }

                    // Save the presentation (could be the same file or a new one)
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}
