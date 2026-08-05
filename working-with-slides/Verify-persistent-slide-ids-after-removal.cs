// -----------------------------------------------------------------------------
// Example: Verify persistent slide ids after removal using C#
//
// Description:
// Demonstrates how to verify that slide persistent IDs remain unchanged after
// removing a neighboring slide using C# and Aspose.Slides for .NET. The example
// loads a presentation, records the IDs of the first and third slides, removes
// the second slide, retrieves the original slides by their stored IDs, and
// confirms that the IDs are still the same. The modified presentation is then
// saved. This pattern helps developers ensure slide identity consistency during
// automated PPTX manipulation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Persistent Slide ID, 
// Slide Removal, Presentation Processing, Office Automation
//
// Use Cases:
// - Verify slide ID stability after slide removal in automated workflows.
// - Build C# utilities for reliable PowerPoint slide management.
// - Ensure data integrity when programmatically editing PPTX files.
// - Integrate slide ID verification into larger .NET presentation processing pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VerifyPersistentSlideIds
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Ensure there are at least two slides to perform removal
                    if (presentation.Slides.Count < 2)
                    {
                        Console.WriteLine("Presentation must contain at least two slides.");
                        return;
                    }

                    // Store the persistent IDs of the first and third slides (if present)
                    uint firstSlideId = presentation.Slides[0].SlideId;
                    uint thirdSlideId = presentation.Slides.Count > 2 ? presentation.Slides[2].SlideId : 0;

                    // Remove the second slide (neighboring slide)
                    presentation.Slides.RemoveAt(1);

                    // Retrieve slides by their original IDs
                    Aspose.Slides.IBaseSlide firstSlideAfterRemoval = presentation.GetSlideById(firstSlideId);
                    Aspose.Slides.IBaseSlide thirdSlideAfterRemoval = thirdSlideId != 0 ? presentation.GetSlideById(thirdSlideId) : null;

                    // Verify that the IDs are unchanged
                    if (firstSlideAfterRemoval != null && firstSlideAfterRemoval.SlideId == firstSlideId)
                    {
                        Console.WriteLine("First slide ID unchanged after removal.");
                    }
                    else
                    {
                        Console.WriteLine("First slide ID changed or slide not found.");
                    }

                    if (thirdSlideAfterRemoval != null && thirdSlideAfterRemoval.SlideId == thirdSlideId)
                    {
                        Console.WriteLine("Third slide ID unchanged after removal.");
                    }
                    else if (thirdSlideId != 0)
                    {
                        Console.WriteLine("Third slide ID changed or slide not found.");
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (System.Net.WebException)
            {
                // Handle external URL or web service errors
                Console.WriteLine("Failed to load presentation from a URL.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
