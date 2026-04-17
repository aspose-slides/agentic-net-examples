using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentationTags
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation files
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Output presentation file
            string outputFile = "MergedTagsPresentation.pptx";

            // Dictionary to hold the unified tag set
            Dictionary<string, string> masterTagSet = new Dictionary<string, string>();

            // Process each input presentation
            foreach (string inputPath in inputFiles)
            {
                try
                {
                    // Verify that the file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the presentation
                    using (Presentation sourcePres = new Presentation(inputPath))
                    {
                        // Access the tag collection of the source presentation
                        TagCollection sourceTags = (TagCollection)sourcePres.CustomData.Tags;

                        // Iterate through all tags and add them to the master set
                        for (int i = 0; i < sourceTags.Count; i++)
                        {
                            string tagName = sourceTags.GetNameByIndex(i);
                            string tagValue = sourceTags.GetValueByIndex(i);

                            // Preserve the first occurrence of each tag name
                            if (!masterTagSet.ContainsKey(tagName))
                            {
                                masterTagSet.Add(tagName, tagValue);
                            }
                        }
                    }
                }
                catch (NotSupportedException)
                {
                    // The file format is not supported by Aspose.Slides
                    Console.WriteLine($"Unsupported format: {inputPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., corrupted file)
                    Console.WriteLine($"Error processing {inputPath}: {ex.Message}");
                }
            }

            // Create a new presentation to hold the merged tags
            using (Presentation masterPres = new Presentation())
            {
                // Add the collected tags to the master presentation
                TagCollection masterTags = (TagCollection)masterPres.CustomData.Tags;
                foreach (KeyValuePair<string, string> kvp in masterTagSet)
                {
                    masterTags.Add(kvp.Key, kvp.Value);
                }

                try
                {
                    // Save the master presentation
                    masterPres.Save(outputFile, SaveFormat.Pptx);
                    Console.WriteLine($"Merged presentation saved to {outputFile}");
                }
                catch (NotSupportedException)
                {
                    // The requested save format is not supported
                    Console.WriteLine("The selected save format is not supported.");
                }
            }
        }
    }
}