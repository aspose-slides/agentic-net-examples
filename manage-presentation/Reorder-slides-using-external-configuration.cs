// -----------------------------------------------------------------------------
// Example: Reorder PowerPoint Slides Using External Configuration with Aspose.Slides
//
// Description:
// This console application reads a list of slide indices from a text file and
// reorders the slides of an existing PPTX presentation accordingly. It uses
// Aspose.Slides for .NET to load, clone, and save the presentation, producing a
// new PPTX file with the desired slide sequence.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide reordering, external configuration, presentation automation
//
// Use Cases:
// - Automate custom slide sequencing based on user‑defined order files.
// - Integrate slide ordering into build pipelines for dynamic presentations.
// - Support localization or version‑specific slide arrangements without manual editing.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace SlideReorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string configPath = Path.Combine(Environment.CurrentDirectory, "order.txt");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output_reordered.pptx");

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            // Verify configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            // Load source presentation
            Aspose.Slides.Presentation sourcePresentation = null;
            try
            {
                sourcePresentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Read ordering from configuration file
            List<int> newOrder = new List<int>();
            try
            {
                string[] lines = File.ReadAllLines(configPath);
                foreach (string line in lines)
                {
                    if (int.TryParse(line.Trim(), out int index))
                    {
                        newOrder.Add(index);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read configuration: " + ex.Message);
                sourcePresentation.Dispose();
                return;
            }

            // Validate indices
            int slideCount = sourcePresentation.Slides.Count;
            foreach (int idx in newOrder)
            {
                if (idx < 0 || idx >= slideCount)
                {
                    Console.WriteLine("Invalid slide index in configuration: " + idx);
                    sourcePresentation.Dispose();
                    return;
                }
            }

            // Create new presentation for reordered slides
            Aspose.Slides.Presentation reorderedPresentation = new Aspose.Slides.Presentation();
            // Remove default empty slide if present
            if (reorderedPresentation.Slides.Count > 0)
            {
                reorderedPresentation.Slides.RemoveAt(0);
            }

            // Clone slides in the new order
            foreach (int idx in newOrder)
            {
                Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[idx];
                reorderedPresentation.Slides.AddClone(sourceSlide);
            }

            // Save reordered presentation
            try
            {
                reorderedPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Reordered presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save reordered presentation: " + ex.Message);
            }
            finally
            {
                sourcePresentation.Dispose();
                reorderedPresentation.Dispose();
            }
        }
    }
}
