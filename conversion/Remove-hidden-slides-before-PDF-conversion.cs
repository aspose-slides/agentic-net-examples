// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove hidden slides before PDF conversion using C#

//

// Description:

// Demonstrates how to remove hidden slides before PDF conversion using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Remove, Hidden, Slides, 

// Before, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate remove hidden slides before PDF conversion.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RemoveHiddenSlidesToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Remove hidden slides (iterate backwards to avoid index issues)

                for (int i = presentation.Slides.Count - 1; i >= 0; i--)

                {

                    if (presentation.Slides[i].Hidden)

                    {

                        presentation.Slides.RemoveAt(i);

                    }

                }



                // Optionally save the modified presentation (required by authoring rule)

                string tempPptxPath = Path.Combine(Environment.CurrentDirectory, "temp_modified.pptx");

                presentation.Save(tempPptxPath, SaveFormat.Pptx);



                // Set PDF options (do not include hidden slides)

                PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.ShowHiddenSlides = false; // default, but set explicitly for clarity



                // Save the presentation as PDF

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);



                // Clean up temporary file

                if (File.Exists(tempPptxPath))

                {

                    File.Delete(tempPptxPath);

                }



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("PDF created successfully at: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

