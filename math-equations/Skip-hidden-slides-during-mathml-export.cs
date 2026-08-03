// -----------------------------------------------------------------------------
// Example: Skip hidden slides during PPTX export using C#
//
// Description:
// Demonstrates how to skip hidden slides when exporting a presentation to PPTX
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, filters
// out hidden slides, and saves only the visible slides to a new PPTX file.
// This pattern can be used to automate PowerPoint workflows that require
// excluding hidden content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Skip, Hidden, Slides, Export,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Export only visible slides from a presentation.
// - Build C# tools for PowerPoint slide management.
// - Automate PPTX generation while omitting hidden slides.
// - Integrate slide filtering into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<int> visibleSlideIndices = new List<int>();

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        if (!slide.Hidden)
                        {
                            // Slides are 1-based for the Save method
                            visibleSlideIndices.Add(i + 1);
                        }
                    }

                    if (visibleSlideIndices.Count == 0)
                    {
                        Console.WriteLine("No visible slides to export.");
                    }
                    else
                    {
                        int[] slidesArray = visibleSlideIndices.ToArray();
                        presentation.Save(outputPath, slidesArray, SaveFormat.Pptx);
                        Console.WriteLine("Exported visible slides to: " + outputPath);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for export.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
