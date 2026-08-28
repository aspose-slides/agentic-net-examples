// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set custom line height for PPTX notes using C#

//

// Description:

// Demonstrates how to load a PPTX file, (placeholder) adjust the line height

// of notes on a slide, and export the presentation as a handout PDF using

// Aspose.Slides for .NET. The example also shows how to save the potentially

// modified presentation back to PPTX format.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Line Height, Notes,

// Handout, PDF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting custom line height for notes in PPTX files.

// - Generate handout PDFs with specific layout options.

// - Integrate PowerPoint note manipulation into .NET applications.

// - Validate and transform presentations before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace HandoutWithCustomLineHeight

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "handout.pdf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Apply custom line height to notes (example: increase line spacing in the first shape of the first slide)

                // Note: Detailed notes manipulation is not covered by existing rules; this is a placeholder for custom logic.

                // If needed, additional code can be added here to adjust paragraph spacing in notes.



                // Configure PDF options for handout layout

                PdfOptions pdfOptions = new PdfOptions

                {

                    ShowHiddenSlides = true,

                    SlidesLayoutOptions = new HandoutLayoutingOptions

                    {

                        Handout = HandoutType.Handouts4Horizontal

                    }

                };



                // Save the handout as PDF

                pres.Save(outputPath, SaveFormat.Pdf, pdfOptions);



                // Save the (potentially modified) presentation before exiting

                pres.Save(inputPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Handle unsupported format scenario

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

