// -----------------------------------------------------------------------------
// Example: Validate master slide placeholders complete using C#
//
// Description:
// Demonstrates how to validate that each master slide in a PowerPoint presentation
// contains all required placeholder types using Aspose.Slides for .NET. The example
// loads a presentation, checks for Title, Body, DateAndTime, SlideNumber, Footer,
// and Header placeholders on every master slide, reports missing placeholders,
// and saves the (unchanged) presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Master Slide, Placeholders,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of master slide placeholders completeness.
// - Build C# tools for PowerPoint presentation quality assurance.
// - Ensure consistent placeholder availability before publishing presentations.
// - Integrate placeholder validation into .NET-based PPTX workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ValidateMasterPlaceholders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define required placeholder types
                    PlaceholderType[] requiredTypes = new PlaceholderType[]
                    {
                        PlaceholderType.Title,
                        PlaceholderType.Body,
                        PlaceholderType.DateAndTime,
                        PlaceholderType.SlideNumber,
                        PlaceholderType.Footer,
                        PlaceholderType.Header
                    };

                    // Iterate through each master slide
                    for (int masterIndex = 0; masterIndex < presentation.Masters.Count; masterIndex++)
                    {
                        IMasterSlide masterSlide = presentation.Masters[masterIndex];
                        Console.WriteLine("Checking Master Slide #" + masterIndex);

                        // Check each required placeholder type
                        foreach (PlaceholderType placeholderType in requiredTypes)
                        {
                            IShape[] shapes = SlideUtil.FindShapesByPlaceholderType(masterSlide, placeholderType);
                            if (shapes == null || shapes.Length == 0)
                            {
                                Console.WriteLine($"  Missing placeholder: {placeholderType}");
                            }
                            else
                            {
                                Console.WriteLine($"  Found placeholder: {placeholderType} (Count: {shapes.Length})");
                            }
                        }
                    }

                    // Save the presentation (even if unchanged) before exiting
                    string outputPath = "validated_output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
