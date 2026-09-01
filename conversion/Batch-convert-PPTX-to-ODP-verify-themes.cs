// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to ODP verify themes using C#

//

// Description:

// Demonstrates how to batch convert PPTX to ODP while preserving and verifying

// master theme consistency using C# and Aspose.Slides for .NET. The example

// processes all PPTX files in the current directory, saves them as ODP files,

// and checks that the number of master slides remains unchanged after conversion.

// This pattern can be used to automate presentation format migrations and

// ensure visual fidelity in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, Batch, Convert, Verify Themes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX files to ODP format.

// - Validate that master themes are retained after conversion.

// - Build C# utilities for PowerPoint presentation migration.

// - Integrate presentation format checks into .NET workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace BatchConvert

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input directory (current directory)

            string inputDir = Directory.GetCurrentDirectory();



            // Output directory for ODP files

            string outputDir = Path.Combine(inputDir, "ConvertedODP");

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            // Get all PPTX files in the input directory

            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");

            foreach (string pptxPath in pptxFiles)

            {

                try

                {

                    // Verify the file exists

                    if (!File.Exists(pptxPath))

                    {

                        Console.WriteLine("File not found: " + pptxPath);

                        continue;

                    }



                    // Load the source PPTX presentation

                    Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(pptxPath);



                    // Determine output ODP file path

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);

                    string odpPath = Path.Combine(outputDir, fileNameWithoutExt + ".odp");



                    // Save as ODP (preserves master themes)

                    sourcePres.Save(odpPath, Aspose.Slides.Export.SaveFormat.Odp);



                    // Load the converted ODP to verify theme consistency

                    Aspose.Slides.Presentation convertedPres = new Aspose.Slides.Presentation(odpPath);



                    // Simple verification: compare number of master slides

                    bool themeConsistent = sourcePres.Masters.Count == convertedPres.Masters.Count;

                    Console.WriteLine("Converted " + pptxPath + " to " + odpPath + ". Theme consistency: " + themeConsistent);



                    // Dispose presentations

                    convertedPres.Dispose();

                    sourcePres.Dispose();

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("The format of file " + pptxPath + " is not supported for conversion.");

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);

                }

            }

        }

    }

}

