// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create handout PDF three slides per page using C#

//

// Description:

// Demonstrates how to create a handout PDF with three slides per page using C#

// and Aspose.Slides for .NET. The example loads a PPTX file, configures PDF

// export options for a three‑slide handout layout, and saves the result as a PDF.

// This pattern can be used to automate handout generation, integrate

// presentation processing into .NET applications, or validate PPTX content.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Handout, Three Slides per Page,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Generate handout PDFs with three slides per page from PowerPoint files.

// - Build C# utilities for batch conversion of presentations to handout PDFs.

// - Integrate handout creation into document management or e‑learning platforms.

// - Automate PDF handout production as part of a CI/CD pipeline.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace HandoutPdfExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "handout.pdf";



            // Verify input file existence

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

                    // Set a header with the presentation title (placeholder - actual implementation may vary)

                    // Example: using the master handout slide's header/footer manager

                    // IMasterHandoutSlide masterHandout = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

                    // if (masterHandout != null && masterHandout.HeaderFooterManager != null)

                    // {

                    //     masterHandout.HeaderFooterManager.SetHeaderFooterText(presentation.DocumentProperties.Title, null);

                    // }



                    // Configure PDF export options for three slides per page handout

                    PdfOptions pdfOptions = new PdfOptions

                    {

                        SlidesLayoutOptions = new HandoutLayoutingOptions

                        {

                            Handout = HandoutType.Handouts3

                        }

                    };



                    // Save the handout PDF

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Handout PDF created successfully: " + outputPath);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported

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

