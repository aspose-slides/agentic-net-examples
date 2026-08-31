// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed remote fonts into presentation for PDF using C#

//

// Description:

// Demonstrates how to embed remote fonts into a PowerPoint presentation and

// then save the presentation as a PDF using Aspose.Slides for .NET. The example

// loads a PPTX file, ensures all used fonts are embedded, and produces a PDF

// with those fonts embedded, preserving the visual fidelity of the original

// slides.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Embed, Remote, Fonts,

// Presentation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate embedding of remote fonts before converting presentations to PDF.

// - Build C# tools for reliable PowerPoint to PDF conversion with font

//   preservation.

// - Generate PDFs from PPTX files in .NET applications while ensuring fonts are

//   embedded.

// - Validate presentation workflows that require font embedding prior to

//   publishing or distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output_embedded.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                foreach (IFontData font in allFonts)

                {

                    bool alreadyEmbedded = false;

                    foreach (IFontData embedded in embeddedFonts)

                    {

                        if (embedded.FontName == font.FontName)

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



                presentation.Save(outputPath, SaveFormat.Pdf);

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

