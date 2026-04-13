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