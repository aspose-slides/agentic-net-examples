// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF with embedded fonts using C#

//

// Description:

// Demonstrates how to convert PPTX files to PDF with all fonts embedded 

// using Aspose.Slides for .NET. The example processes a folder of PPTX files, 

// ensures each used font is embedded, and saves the resulting PDFs alongside 

// the source files. This pattern can be used for batch conversion, 

// archiving presentations, or preparing documents for distribution where 

// font fidelity is required.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Embedded Fonts, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Batch convert PPTX presentations to PDF with embedded fonts.

// - Ensure PDF outputs retain original typography across platforms.

// - Integrate font‑embedding PDF export into .NET automation pipelines.

// - Prepare presentation archives for distribution without font dependencies.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Linq;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToPdfWithEmbeddedFonts

{

    class Program

    {

        static void Main(string[] args)

        {

            // Folder containing PPTX files; can be passed as first argument

            string folderPath = args.Length > 0 ? args[0] : "InputPptx";



            if (!Directory.Exists(folderPath))

            {

                Console.WriteLine($"Folder not found: {folderPath}");

                return;

            }



            string[] pptxFiles = Directory.GetFiles(folderPath, "*.pptx");



            foreach (string pptxFile in pptxFiles)

            {

                try

                {

                    using (Presentation presentation = new Presentation(pptxFile))

                    {

                        // Embed all fonts used in the presentation

                        IFontData[] allFonts = presentation.FontsManager.GetFonts();

                        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                        foreach (IFontData font in allFonts)

                        {

                            bool isAlreadyEmbedded = embeddedFonts.Any(ef => ef.Equals(font));

                            if (!isAlreadyEmbedded)

                            {

                                presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                            }

                        }



                        // Set PDF options to embed full fonts

                        PdfOptions pdfOptions = new PdfOptions();

                        pdfOptions.EmbedFullFonts = true;



                        // Save as PDF in the same folder

                        string pdfPath = Path.ChangeExtension(pptxFile, ".pdf");

                        presentation.Save(pdfPath, SaveFormat.Pdf, pdfOptions);

                    }

                }

                catch (PptxUnsupportedFormatException)

                {

                    // Format not supported

                }

                catch (Exception ex)

                {

                    Console.WriteLine($"Error processing '{pptxFile}': {ex.Message}");

                }

            }

        }

    }

}

