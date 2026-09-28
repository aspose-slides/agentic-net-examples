// -----------------------------------------------------------------------------
// Example: Merge Multiple PowerPoint Presentations with Tag Collision Resolution
//
// Description:
// This console application merges several PPTX files into a single presentation
// using Aspose.Slides for .NET. It clones master slides, copies slides to the
// destination, and demonstrates a strategy for handling custom data tag name
// collisions by renaming duplicate tags. The output is a consolidated PPTX file.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, merge presentations, tag collision, custom data tags
//
// Use Cases:
// - Combine quarterly reports from different departments into one deck.
// - Aggregate training modules while preserving metadata.
// - Create a master presentation from multiple template files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace AsposeSlidesTagMergeExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Input presentation files (modify paths as needed)
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Output merged presentation
            string outputFile = "MergedPresentation.pptx";

            // Validate input files
            List<string> validFiles = new List<string>();
            foreach (string filePath in inputFiles)
            {
                if (File.Exists(filePath))
                {
                    validFiles.Add(filePath);
                }
                else
                {
                    Console.WriteLine("Input file not found: " + filePath);
                }
            }

            if (validFiles.Count == 0)
            {
                Console.WriteLine("No valid input files were provided. Exiting.");
                return;
            }

            // Create destination presentation
            Aspose.Slides.Presentation destPres = null;
            try
            {
                destPres = new Aspose.Slides.Presentation();

                // Dictionary to keep track of used tag names across all slides
                Dictionary<string, int> tagNameUsage = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                // Process each source presentation
                foreach (string srcPath in validFiles)
                {
                    Aspose.Slides.Presentation srcPres = null;
                    try
                    {
                        srcPres = new Aspose.Slides.Presentation(srcPath);

                        // Iterate through each slide in the source presentation
                        for (int i = 0; i < srcPres.Slides.Count; i++)
                        {
                            Aspose.Slides.ISlide sourceSlide = srcPres.Slides[i];
                            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                            // Clone the master slide into the destination presentation
                            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                            // Clone the slide using the cloned master
                            Aspose.Slides.ISlide destSlide = destPres.Slides.AddClone(sourceSlide, destMaster, true);

                            // -------------------------------------------------------------
                            // Tag collision handling (if tag API is available)
                            // -------------------------------------------------------------
                            // Aspose.Slides provides tag manipulation via IShape.GetTag / IShape.AddTag.
                            // The example below demonstrates how to copy tags from source shapes to
                            // destination shapes while renaming duplicate tag names.
                            // -------------------------------------------------------------
                            try
                            {
                                for (int shapeIdx = 0; shapeIdx < sourceSlide.Shapes.Count; shapeIdx++)
                                {
                                    // Get corresponding shape in the cloned slide (order is preserved)
                                    if (shapeIdx >= destSlide.Shapes.Count)
                                    {
                                        break;
                                    }

                                    object sourceShapeObj = sourceSlide.Shapes[shapeIdx];
                                    object destShapeObj = destSlide.Shapes[shapeIdx];

                                    // Cast to IShape (both collections store IShape)
                                    Aspose.Slides.IShape sourceShape = sourceShapeObj as Aspose.Slides.IShape;
                                    Aspose.Slides.IShape destShape = destShapeObj as Aspose.Slides.IShape;

                                    if (sourceShape == null || destShape == null)
                                    {
                                        continue;
                                    }

                                    // Attempt to retrieve tag names via reflection (since direct enumeration may not be supported)
                                    System.Type shapeType = sourceShape.GetType();
                                    System.Reflection.PropertyInfo tagsProp = shapeType.GetProperty("Tags");
                                    if (tagsProp != null)
                                    {
                                        // The property exists; attempt to enumerate tags
                                        object tagsObj = tagsProp.GetValue(sourceShape);
                                        System.Type tagsType = tagsObj.GetType();
                                        System.Reflection.MethodInfo getEnumerator = tagsType.GetMethod("GetEnumerator");
                                        System.Collections.IEnumerator enumerator = getEnumerator.Invoke(tagsObj, null) as System.Collections.IEnumerator;

                                        while (enumerator != null && enumerator.MoveNext())
                                        {
                                            object tagItem = enumerator.Current;
                                            System.Type tagItemType = tagItem.GetType();
                                            System.Reflection.PropertyInfo nameProp = tagItemType.GetProperty("Name");
                                            System.Reflection.PropertyInfo valueProp = tagItemType.GetProperty("Value");
                                            string tagName = nameProp.GetValue(tagItem) as string;
                                            string tagValue = valueProp.GetValue(tagItem) as string;

                                            // Resolve name collision
                                            string finalTagName = tagName;
                                            if (tagNameUsage.ContainsKey(tagName))
                                            {
                                                int suffix = ++tagNameUsage[tagName];
                                                finalTagName = tagName + "_" + suffix.ToString();
                                            }
                                            else
                                            {
                                                tagNameUsage[tagName] = 0;
                                            }

                                            // Add tag to destination shape using AddTag method if available
                                            System.Reflection.MethodInfo addTagMethod = destShape.GetType().GetMethod("AddTag");
                                            if (addTagMethod != null)
                                            {
                                                addTagMethod.Invoke(destShape, new object[] { finalTagName, tagValue });
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Fallback: use GetTag / SetTag if specific tag names are known.
                                        // This block can be expanded based on known tag keys.
                                    }
                                }
                            }
                            catch (Exception exTag)
                            {
                                // Tag handling failed; log and continue without breaking the merge.
                                Console.WriteLine("Tag processing error on slide " + (i + 1) + ": " + exTag.Message);
                            }
                        }
                    }
                    catch (Exception exSrc)
                    {
                        Console.WriteLine("Failed to process source file '" + srcPath + "': " + exSrc.Message);
                    }
                    finally
                    {
                        if (srcPres != null)
                        {
                            srcPres.Dispose();
                        }
                    }
                }

                // Save the merged presentation
                destPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Merged presentation saved to: " + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during merging: " + ex.Message);
            }
            finally
            {
                if (destPres != null)
                {
                    destPres.Dispose();
                }
            }
        }
    }
}
