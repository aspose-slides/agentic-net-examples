// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect duplicate slide layouts and consolidate using C#

//

// Description:

// Demonstrates how to detect duplicate slide layouts and consolidate using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Duplicate, Slide, 

// Layouts, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate detect duplicate slide layouts and consolidate.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DetectDuplicateLayouts

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input file path

            string inputPath = "input.pptx";

            if (args.Length > 0)

            {

                inputPath = args[0];

            }



            // Verify that the file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("File does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    IGlobalLayoutSlideCollection layouts = presentation.LayoutSlides;



                    // List to keep track of duplicate layouts that can be removed

                    List<ILayoutSlide> duplicates = new List<ILayoutSlide>();



                    // Detect duplicate layout slides by comparing each pair

                    for (int i = 0; i < layouts.Count; i++)

                    {

                        ILayoutSlide layoutI = layouts[i];



                        // Skip layouts already marked as duplicate

                        if (duplicates.Contains(layoutI))

                            continue;



                        for (int j = i + 1; j < layouts.Count; j++)

                        {

                            ILayoutSlide layoutJ = layouts[j];



                            // Use Equals to compare layout content

                            if (layoutI.Equals(layoutJ))

                            {

                                Console.WriteLine($"Duplicate layout found: Index {j} is identical to Index {i}.");



                                // Mark the later layout for removal

                                duplicates.Add(layoutJ);

                            }

                        }

                    }



                    // Attempt to remove duplicate layouts that are not used by any slide

                    foreach (ILayoutSlide dup in duplicates)

                    {

                        if (!dup.HasDependingSlides)

                        {

                            dup.Remove();

                            Console.WriteLine("Removed unused duplicate layout.");

                        }

                        else

                        {

                            Console.WriteLine("Duplicate layout is in use and cannot be removed.");

                        }

                    }



                    // Remove any other unused layouts

                    presentation.LayoutSlides.RemoveUnused();



                    // Save the modified presentation

                    string outputPath = Path.Combine(

                        Path.GetDirectoryName(inputPath),

                        Path.GetFileNameWithoutExtension(inputPath) + "_dedup.pptx");



                    presentation.Save(outputPath, SaveFormat.Pptx);

                    Console.WriteLine("Presentation saved to: " + outputPath);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException ex)

            {

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

