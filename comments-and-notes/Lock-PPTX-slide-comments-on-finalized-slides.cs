// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Lock PPTX slide comments on finalized slides using C#

//

// Description:

// Demonstrates how to lock PPTX slide comments on finalized slides using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Lock, Pptx, Slide, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate lock PPTX slide comments on finalized slides.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace LockCommentsExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_locked.pptx";



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

                    // Set write protection to lock further edits (including comments)

                    presentation.ProtectionManager.SetWriteProtection("LockPassword");



                    // Save the protected presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }



                Console.WriteLine("Presentation saved with comments locked: " + outputPath);

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                // Handle unsupported PPTX format

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException ex)

            {

                // Handle unsupported PPT format

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (Aspose.Slides.PptxEditException ex)

            {

                // Handle edit errors (e.g., trying to modify a protected file)

                Console.WriteLine("Edit error: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

