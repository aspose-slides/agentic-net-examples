// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Check custom font embeddings and report missing using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, enumerate all fonts used,

// identify which custom fonts are not embedded, and report the missing fonts.

// The example uses Aspose.Slides for .NET and runs as a standalone console

// application, suitable for automating PPTX validation workflows.

//

// Keywords:

// C#, .NET, PowerPoint, PPTX, Aspose.Slides, Font Embedding, Missing Fonts,

// Presentation Validation, Office Automation

//

// Use Cases:

// - Detect and list custom fonts that are used but not embedded in a PPTX.

// - Build validation tools for PowerPoint files in .NET environments.

// - Ensure presentations meet embedding requirements before distribution.

// - Integrate font‑embedding checks into automated CI/CD pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Linq;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CheckCustomFontEmbeddings

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the presentation file

            var presentationPath = "input.pptx";



            // Verify that the file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine($"File not found: {presentationPath}");

                return;

            }



            try

            {

                // Load the presentation

                using (var presentation = new Presentation(presentationPath))

                {

                    // Retrieve all fonts used in the presentation

                    var allFonts = presentation.FontsManager.GetFonts();



                    // Retrieve fonts that are already embedded

                    var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                    // Find fonts that are not embedded

                    var missingFonts = allFonts

                        .Where(font => !embeddedFonts.Any(emb => string.Equals(emb.FontName, font.FontName, StringComparison.OrdinalIgnoreCase)))

                        .Select(font => font.FontName)

                        .Distinct()

                        .ToList();



                    if (missingFonts.Any())

                    {

                        Console.WriteLine("The following fonts are used but not embedded:");

                        foreach (var fontName in missingFonts)

                        {

                            Console.WriteLine($"- {fontName}");

                        }

                    }

                    else

                    {

                        Console.WriteLine("All custom fonts are embedded.");

                    }



                    // Save the presentation before exiting

                    presentation.Save(presentationPath, SaveFormat.Pptx);

                }

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors)

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

