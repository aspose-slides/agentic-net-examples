// -----------------------------------------------------------------------------
// Example: Clone slide tags to another slide using C#
//
// Description:
// Demonstrates how to clone slide tags from one slide to another using C# and 
// Aspose.Slides for .NET. The example shows the required presentation-processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Tags, Another, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of slide tags to another slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideTags
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there are at least two slides; add a blank slide if necessary
                    if (presentation.Slides.Count < 2)
                    {
                        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                    }

                    // Source slide (first slide) and destination slide (second slide)
                    ISlide sourceSlide = presentation.Slides[0];
                    ISlide destSlide = presentation.Slides[1];

                    // Access tag collections of both slides
                    ITagCollection sourceTags = sourceSlide.CustomData.Tags;
                    ITagCollection destTags = destSlide.CustomData.Tags;

                    // Clear existing tags on destination slide (optional)
                    destTags.Clear();

                    // Copy each tag from source to destination
                    for (int i = 0; i < sourceTags.Count; i++)
                    {
                        string key = sourceTags.GetNameByIndex(i);
                        string value = sourceTags.GetValueByIndex(i);
                        destTags.Add(key, value);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
