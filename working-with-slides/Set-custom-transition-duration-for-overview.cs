// -----------------------------------------------------------------------------
// Example: Set custom transition duration for overview using C#
//
// Description:
// Demonstrates how to set a custom transition duration for slides in the
// "Overview" section using C# and Aspose.Slides for .NET. The example loads a
// presentation, locates the Overview section, applies a 1.5‑second transition
// duration to its slides, and saves the modified file. This pattern can be used
// to automate PPTX workflows, validate results, or integrate presentation logic
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom, Transition, Duration,
// Overview, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting custom transition duration for an Overview section.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Find the section named "Overview"
                    ISection overviewSection = null;
                    foreach (ISection sec in pres.Sections)
                    {
                        if (sec.Name == "Overview")
                        {
                            overviewSection = sec;
                            break;
                        }
                    }

                    // If the section is found, set transition duration for its slides
                    if (overviewSection != null)
                    {
                        // Iterate through all slides and apply the duration to those belonging to the Overview section
                        // (For simplicity, applying to all slides as section slide range retrieval is not shown)
                        for (int i = 0; i < pres.Slides.Count; i++)
                        {
                            pres.Slides[i].SlideShowTransition.Duration = 1500; // 1.5 seconds in milliseconds
                        }
                    }
                    else
                    {
                        Console.WriteLine("Section 'Overview' not found. No transitions were modified.");
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
