// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate embedded fonts after PDF conversion using C#

//

// Description:

// Demonstrates how to embed missing fonts in a PowerPoint presentation,

// convert the presentation to PDF with full font embedding, and then

// validate that the fonts remain embedded after the conversion using

// Aspose.Slides for .NET. The example includes file existence checks,

// font embedding logic, PDF export settings, and simple console output.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Validate, Embedded, Fonts,

// After, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of embedded fonts after PDF conversion.

// - Build C# tools for PowerPoint presentation processing and PDF export.

// - Ensure font compliance before publishing or distribution of PDFs.

// - Integrate font embedding checks into .NET applications handling PPTX files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPdfPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);



            // Embed all fonts that are not already embedded

            IFontData[] allFonts = presentation.FontsManager.GetFonts();

            IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (IFontData font in allFonts)

            {

                bool isEmbedded = false;

                foreach (IFontData ef in embeddedFonts)

                {

                    if (ef.Equals(font))

                    {

                        isEmbedded = true;

                        break;

                    }

                }

                if (!isEmbedded)

                {

                    presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                }

            }



            // Save to PDF with default regular font and full font embedding

            PdfOptions pdfOptions = new PdfOptions

            {

                DefaultRegularFont = "Arial",

                EmbedFullFonts = true

            };

            presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);



            // Validate that embedded fonts are still present

            IFontData[] embeddedAfter = presentation.FontsManager.GetEmbeddedFonts();

            Console.WriteLine("Number of embedded fonts after PDF conversion: " + embeddedAfter.Length);



            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

