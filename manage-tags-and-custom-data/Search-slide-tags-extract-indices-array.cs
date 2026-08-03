// -----------------------------------------------------------------------------
// Example: Search slide tags extract indices array using C#
//
// Description:
// Demonstrates how to search slide tags for a specific key/value pair and
// extract the zero‑based slide indices into an array using C# and Aspose.Slides
// for .NET. The example loads a presentation, iterates through its slides,
// checks each slide's custom data tags, collects matching slide indices, and
// outputs them. It also shows optional saving of the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Search, Slide, Tags, Extract,
// Indices, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate searching of slide tags and extracting matching slide indices.
// - Build C# utilities for PowerPoint presentation analysis.
// - Integrate tag‑based slide selection into .NET applications.
// - Validate or transform PPTX files based on custom tag data.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTagSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string presentationPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            // Tag key and value to search for
            string tagKey = "MyTag";
            string tagValue = "TargetValue";

            // Verify file existence
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    List<int> matchingIndices = new List<int>();

                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];

                        // Access slide tags via CustomData.Tags
                        ITagCollection tags = slide.CustomData.Tags;

                        if (tags.Contains(tagKey))
                        {
                            string value = tags[tagKey];
                            if (value == tagValue)
                            {
                                // Slide indices are zero‑based; store as needed
                                matchingIndices.Add(i);
                            }
                        }
                    }

                    // Convert to array
                    int[] resultIndices = matchingIndices.ToArray();

                    // Output result
                    Console.WriteLine("Slides containing the tag value:");
                    foreach (int index in resultIndices)
                    {
                        Console.WriteLine("Slide index: " + index);
                    }

                    // Save presentation before exit (optional – here we save a copy)
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
