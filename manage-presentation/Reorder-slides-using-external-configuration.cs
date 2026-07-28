// -----------------------------------------------------------------------------
// Example: Reorder slides using external configuration using C#
//
// Description:
// Demonstrates how to reorder slides in a PowerPoint presentation based on an
// external configuration file using C# and Aspose.Slides for .NET. The example
// reads a list of slide indices from a text file, applies the new ordering to
// the presentation, and saves the result as a new PPTX file. This pattern can
// be used to automate slide sequencing, integrate custom ordering logic, or
// support dynamic presentation generation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reorder, Slides, External,
// Configuration, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate reordering of slides according to a user‑defined sequence.
// - Build .NET tools that adjust PPTX slide order based on external data.
// - Integrate slide sequencing into larger presentation workflow pipelines.
// - Validate and transform presentations before distribution or publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string configPath = "order.txt";
            string outputPath = "output.pptx";

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            try
            {
                // Read custom slide order from configuration file (comma or whitespace separated indices)
                string configContent = File.ReadAllText(configPath);
                string[] tokens = configContent.Split(new char[] { ',', ';', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> newOrder = new List<int>();
                foreach (string token in tokens)
                {
                    if (int.TryParse(token, out int index))
                    {
                        newOrder.Add(index);
                    }
                }

                // Load the presentation
                Presentation pres = new Presentation(inputPath);
                ISlideCollection slides = pres.Slides;

                // Reorder slides according to the custom sequence
                for (int targetIndex = 0; targetIndex < newOrder.Count && targetIndex < slides.Count; targetIndex++)
                {
                    int originalIndex = newOrder[targetIndex];
                    if (originalIndex < 0 || originalIndex >= slides.Count)
                    {
                        // Skip invalid indices
                        continue;
                    }

                    // Move the slide from originalIndex to targetIndex
                    slides.Reorder(originalIndex, targetIndex);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
