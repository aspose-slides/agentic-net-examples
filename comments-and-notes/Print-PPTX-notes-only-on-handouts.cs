// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Print PPTX notes only on handouts using C#

//

// Description:

// Demonstrates how to print PPTX notes only on handouts using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Print, Pptx, Notes, Only, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate print PPTX notes only on handouts.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

                {

                    // Configure PDF options to include notes on handouts

                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                    pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions

                    {

                        NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull

                    };



                    // Save the presentation as PDF with the specified options

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                }

            }

            // Handle unsupported format exceptions

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                Console.WriteLine("The file format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                Console.WriteLine("The file format is not supported (PPT).");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

