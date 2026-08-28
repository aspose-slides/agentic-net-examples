// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract selected PPTX slides to PPTX using C#

//

// Description:

// Demonstrates how to extract specific slides from a PPTX presentation and

// save them as a new PPTX file using C# and Aspose.Slides for .NET. The example

// loads an existing PPTX, selects slides by their 1‑based indices, and saves the

// subset to a separate PPTX file. This pattern can be used to automate slide

// extraction, create custom presentations, or preprocess content for further

// processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Selected Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Extract specific slides from a large PPTX to create a focused presentation.

// - Build tools that generate custom slide decks based on user selection.

// - Automate content reuse across multiple PowerPoint files.

// - Validate and preprocess presentations before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace SlideSelector

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "selected_slides.pptx";



            // Define the slide numbers to extract (1‑based indexing)

            int[] slideIndices = new int[] { 1, 3, 5 };



            // Verify that the source file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the source presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Save only the selected slides to a new PPTX file

                    presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Pptx);

                }



                Console.WriteLine("Selected slides saved to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The requested file format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

