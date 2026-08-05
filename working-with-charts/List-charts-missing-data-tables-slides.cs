// -----------------------------------------------------------------------------
// Example: List charts missing data tables slides using C#
//
// Description:
// Demonstrates how to list charts missing data tables slides using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Charts, Missing, Data, 
// Table, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate list charts missing data tables slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
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
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through shapes on each slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Cast shape to chart
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Check if chart lacks a data table
                            if (chart.HasDataTable == false)
                            {
                                Console.WriteLine("Slide " + slide.SlideNumber + " contains a chart without a data table.");
                            }
                        }
                    }
                }

                // Save the presentation (required before exit)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
            // format not supported
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
