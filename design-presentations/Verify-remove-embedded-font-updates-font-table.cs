// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Verify removal of embedded font updates font table using C#

//

// Description:

// Demonstrates how to embed a font in a presentation, remove the embedded

// font, and verify that the font table is updated accordingly using

// Aspose.Slides for .NET. The example loads a PPTX file, ensures a selected

// font is embedded, removes it, checks the embedded fonts collection, and

// saves the modified presentation.

//

// Keywords:

// C#, Aspose.Slides for .NET, Embedded Font, Font Removal, Font Table,

// PowerPoint, PPTX, Presentation Processing, Office Automation

//

// Use Cases:

// - Validate that removing an embedded font updates the presentation's font table.

// - Build automated tests or tools for font management in PowerPoint files.

// - Integrate font embedding and removal logic into .NET applications.

// - Ensure compliance of PPTX files with font licensing requirements.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Linq;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontRemovalTest

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the test presentation

            string presentationPath = "sample.pptx";



            // Verify the file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine($"Presentation file not found: {presentationPath}");

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Get all fonts used in the presentation

                    IFontData[] allFonts = presentation.FontsManager.GetFonts();



                    if (allFonts == null || allFonts.Length == 0)

                    {

                        Console.WriteLine("No fonts found in the presentation.");

                        return;

                    }



                    // Choose the first font for the test

                    IFontData testFont = allFonts[0];



                    // Ensure the font is embedded before removal

                    IFontData[] embeddedFontsBefore = presentation.FontsManager.GetEmbeddedFonts();

                    bool wasAlreadyEmbedded = embeddedFontsBefore.Any(f => f.FontName == testFont.FontName);



                    if (!wasAlreadyEmbedded)

                    {

                        // Embed the font

                        presentation.FontsManager.AddEmbeddedFont(testFont, EmbedFontCharacters.All);

                    }



                    // Verify the font is now embedded

                    IFontData[] embeddedFontsAfterAdd = presentation.FontsManager.GetEmbeddedFonts();

                    bool isEmbedded = embeddedFontsAfterAdd.Any(f => f.FontName == testFont.FontName);

                    if (!isEmbedded)

                    {

                        Console.WriteLine("Failed to embed the test font.");

                        return;

                    }



                    // Remove the embedded font

                    presentation.FontsManager.RemoveEmbeddedFont(testFont);



                    // Verify the font is no longer in the embedded fonts list

                    IFontData[] embeddedFontsAfterRemove = presentation.FontsManager.GetEmbeddedFonts();

                    bool stillEmbedded = embeddedFontsAfterRemove.Any(f => f.FontName == testFont.FontName);



                    if (stillEmbedded)

                    {

                        Console.WriteLine("Test Failed: Font still present after removal.");

                    }

                    else

                    {

                        Console.WriteLine("Test Passed: Font successfully removed from embedded fonts.");

                    }



                    // Save the presentation (required by lifecycle rules)

                    string outputPath = "FontRemovalTest_Output.pptx";

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external resources)

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

