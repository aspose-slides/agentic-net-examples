// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export presentation to XPS with embedded fonts using C#

//

// Description:

// Demonstrates how to export a PowerPoint presentation (PPTX) to an XPS file

// with all used fonts embedded, using C# and Aspose.Slides for .NET. The example

// loads a presentation, ensures every font is embedded, configures XPS export

// options, and saves the result as an XPS document.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Export, Embedded Fonts,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to XPS with font embedding.

// - Build .NET tools for reliable PowerPoint to XPS transformation.

// - Ensure visual fidelity of exported documents across platforms.

// - Integrate presentation export functionality into larger applications.

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

        string outputPath = "output.xps";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Embed all fonts used in the presentation

            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData font in allFonts)

            {

                bool isEmbedded = false;

                foreach (Aspose.Slides.IFontData ef in embeddedFonts)

                {

                    if (ef.Equals(font))

                    {

                        isEmbedded = true;

                        break;

                    }

                }

                if (!isEmbedded)

                {

                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);

                }

            }



            Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();

            // Set default font to use if a source font is missing

            options.DefaultRegularFont = "Arial";



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

