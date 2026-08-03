// -----------------------------------------------------------------------------
// Example: Resolve tag collisions when merging presentations using C#
//
// Description:
// Demonstrates how to merge multiple PowerPoint presentations while preserving
// and consolidating custom data tags, resolving any tag name collisions by
// renaming duplicate tags. The example uses Aspose.Slides for .NET to clone
// slides, copy master slides, and combine tag collections into a single output
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resolve, Tag Collisions, Merge,
// Presentation Merging, Custom Data, Tags, Automation
//
// Use Cases:
// - Combine several PPTX files into one while keeping custom metadata.
// - Ensure unique tag names when merging presentations that share tag keys.
// - Build .NET tools for batch processing of PowerPoint files with custom data.
// - Automate preparation of presentation packages for distribution or archiving.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagCollisionResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation files to merge
            string[] inputFiles = new string[] { "pres1.pptx", "pres2.pptx" };
            // Output merged presentation
            string outputFile = "merged_output.pptx";

            // Create a new destination presentation
            using (Presentation destPres = new Presentation())
            {
                // Iterate over each source presentation
                foreach (string inputPath in inputFiles)
                {
                    // Check if the file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("File not found: " + inputPath);
                        continue;
                    }

                    try
                    {
                        // Load source presentation
                        using (Presentation srcPres = new Presentation(inputPath))
                        {
                            // Clone each slide from source to destination
                            for (int i = 0; i < srcPres.Slides.Count; i++)
                            {
                                ISlide sourceSlide = srcPres.Slides[i];
                                IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                                IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                                destPres.Slides.AddClone(sourceSlide, destMaster, true);
                            }

                            // Merge tags and resolve name collisions
                            ITagCollection srcTags = srcPres.CustomData.Tags;
                            ITagCollection destTags = destPres.CustomData.Tags;

                            foreach (string tagName in srcTags.GetNamesOfTags())
                            {
                                if (destTags.Contains(tagName))
                                {
                                    // Generate a unique tag name
                                    int suffix = 1;
                                    string newTagName;
                                    do
                                    {
                                        newTagName = tagName + "_" + suffix;
                                        suffix++;
                                    } while (destTags.Contains(newTagName));

                                    destTags.Add(newTagName, srcTags[tagName]);
                                }
                                else
                                {
                                    destTags.Add(tagName, srcTags[tagName]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle loading errors (e.g., unsupported format)
                        Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
                        // Format not supported.
                    }
                }

                // Remove the initial empty slide if other slides exist
                if (destPres.Slides.Count > 1 && destPres.Slides[0].Shapes.Count == 0)
                {
                    destPres.Slides.RemoveAt(0);
                }

                // Save the merged presentation
                destPres.Save(outputFile, SaveFormat.Pptx);
            }
        }
    }
}
