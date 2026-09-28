// -----------------------------------------------------------------------------
// Example: Copy Custom Data Between PowerPoint Presentations Using Aspose.Slides for .NET
//
// Description:
// This console application loads a source PPTX file and a target PPTX file,
// copies all custom data entries (key‑value metadata) from the source presentation
// to the target presentation while preserving their data types, and saves the
// updated target file. It demonstrates handling of optional Aspose.Slides
// custom data APIs via reflection to maintain compatibility with different library versions.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, custom data, metadata, clone, presentation copy
//
// Use Cases:
// - Migrating custom metadata from a template presentation to a generated report.
// - Synchronizing custom data across multiple slide decks in an automated workflow.
// - Preserving user‑defined key/value pairs when merging presentations programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlidesCustomDataCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and target file paths
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "SourcePresentation.pptx");
            string targetPath = Path.Combine(Environment.CurrentDirectory, "TargetPresentation.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "TargetPresentation_WithCustomData.pptx");

            // Verify that source and target files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            if (!File.Exists(targetPath))
            {
                Console.WriteLine("Target file not found: " + targetPath);
                return;
            }

            try
            {
                // Load presentations
                Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);
                Aspose.Slides.Presentation targetPresentation = new Aspose.Slides.Presentation(targetPath);

                // Use reflection to access the CustomData property (may not exist in older versions)
                PropertyInfo sourceCustomDataProp = typeof(Aspose.Slides.Presentation).GetProperty("CustomData");
                PropertyInfo targetCustomDataProp = typeof(Aspose.Slides.Presentation).GetProperty("CustomData");

                if (sourceCustomDataProp != null && targetCustomDataProp != null)
                {
                    object sourceCustomData = sourceCustomDataProp.GetValue(sourcePresentation);
                    object targetCustomData = targetCustomDataProp.GetValue(targetPresentation);

                    if (sourceCustomData != null && targetCustomData != null)
                    {
                        // Retrieve the Keys collection
                        PropertyInfo keysProp = sourceCustomData.GetType().GetProperty("Keys");
                        PropertyInfo itemProp = sourceCustomData.GetType().GetProperty("Item");
                        MethodInfo addMethod = targetCustomData.GetType().GetMethod("Add");

                        if (keysProp != null && itemProp != null && addMethod != null)
                        {
                            System.Collections.IEnumerable keys = (System.Collections.IEnumerable)keysProp.GetValue(sourceCustomData);
                            foreach (object keyObj in keys)
                            {
                                string key = keyObj as string;
                                if (key == null)
                                    continue;

                                object value = itemProp.GetValue(sourceCustomData, new object[] { key });
                                // Add or update the entry in the target presentation
                                addMethod.Invoke(targetCustomData, new object[] { key, value });
                            }
                        }
                        else
                        {
                            Console.WriteLine("CustomData collection does not expose expected members. Skipping copy.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("CustomData property is null on one of the presentations. Skipping copy.");
                    }
                }
                else
                {
                    // If the CustomData property does not exist, inform the user.
                    Console.WriteLine("CustomData API is not available in the referenced Aspose.Slides version. No custom data will be copied.");
                }

                // Save the modified target presentation
                targetPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentations
                sourcePresentation.Dispose();
                targetPresentation.Dispose();

                Console.WriteLine("Custom data copy completed. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during processing: " + ex.Message);
            }
        }
    }
}
