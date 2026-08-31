// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Merge multiple pptx files into single deck using C#

//

// Description:

// Demonstrates how to merge multiple pptx files into a single deck using C# and 

// Aspose.Slides for .NET. The example loads each source presentation, clones its 

// slides into a destination presentation, and saves the combined result. It 

// includes basic file existence checks and error handling for unsupported formats 

// or loading issues.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Merge, Multiple, Pptx, Files, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate merging multiple pptx files into a single deck.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MergePresentations

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input presentation files

            string[] inputFiles = new string[]

            {

                "Presentation1.pptx",

                "Presentation2.pptx",

                "Presentation3.pptx"

            };



            // Define output file

            string outputFile = "MergedPresentation.pptx";



            // Create destination presentation

            Presentation destPres = new Presentation();



            try

            {

                foreach (string inputFile in inputFiles)

                {

                    // Check if the source file exists

                    if (!File.Exists(inputFile))

                    {

                        // Skip missing files

                        continue;

                    }



                    try

                    {

                        // Load source presentation

                        Presentation srcPres = new Presentation(inputFile);



                        // Clone each slide from source to destination

                        for (int i = 0; i < srcPres.Slides.Count; i++)

                        {

                            // AddClone adds a copy of the specified slide to the end of the collection

                            destPres.Slides.AddClone(srcPres.Slides[i]);

                        }



                        // Dispose source presentation

                        srcPres.Dispose();

                    }

                    catch (Exception ex)

                    {

                        // Handle unsupported format or other loading errors

                        // Comment: format not supported or loading failed

                        Console.WriteLine($"Error processing file '{inputFile}': {ex.Message}");

                    }

                }



                // Save the merged presentation

                destPres.Save(outputFile, SaveFormat.Pptx);

            }

            finally

            {

                // Ensure the destination presentation is disposed

                destPres.Dispose();

            }

        }

    }

}

