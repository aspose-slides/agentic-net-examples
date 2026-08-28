// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF/A-1b archival a1b using C#

//

// Description:

// Demonstrates how to convert a PPTX file to a PDF/A-1b compliant PDF using

// Aspose.Slides for .NET. The example loads a presentation, embeds all used

// fonts, configures PDF export options for full-font embedding and PDF/A-1b

// compliance, and saves the result as a PDF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF/A-1b, PDF, Export, Font

// Embedding, Archival, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate PDF/A-1b archival copies of PowerPoint presentations.

// - Ensure long-term preservation of slides with full font embedding.

// - Automate PPTX-to-PDF/A conversion in .NET applications.

// - Validate presentation files before distribution or archiving.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPdfA1b

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



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

                    // Embed all fonts used in the presentation

                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    foreach (IFontData font in allFonts)

                    {

                        bool alreadyEmbedded = false;

                        foreach (IFontData embedded in embeddedFonts)

                        {

                            if (embedded.Equals(font))

                            {

                                alreadyEmbedded = true;

                                break;

                            }

                        }

                        if (!alreadyEmbedded)

                        {

                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                        }

                    }



                    // Configure PDF export options for PDF/A‑1b compliance and full font embedding

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.EmbedFullFonts = true;

                    pdfOptions.Compliance = PdfCompliance.PdfA1b;



                    // Save the presentation as PDF with the specified options

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }



                Console.WriteLine("Presentation successfully exported to PDF/A‑1b: " + outputPath);

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported comment

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

