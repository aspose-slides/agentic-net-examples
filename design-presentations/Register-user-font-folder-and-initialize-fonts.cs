// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Register user font folder and initialize fonts using C#

//

// Description:

// Demonstrates how to register a user font folder, load external fonts, embed

// missing fonts into a PowerPoint presentation, and save the result using

// Aspose.Slides for .NET. The example includes validation of input files,

// font folder existence checks, and cleanup of the font cache.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Register, User, Font, Folder,

// Load External Fonts, Embed Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate registration of a custom font directory for PowerPoint processing.

// - Build C# tools that ensure all used fonts are embedded in PPTX files.

// - Generate or transform PPTX files with guaranteed font consistency.

// - Validate and prepare presentations for distribution or publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RegisterUserFonts

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths for the presentation and the user font folder

            string presentationPath = "input.pptx";

            string outputPath = "output.pptx";

            string fontsFolder = "UserFonts";



            // Verify that the presentation file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            // Verify that the font folder exists

            if (!Directory.Exists(fontsFolder))

            {

                Console.WriteLine("Fonts folder not found: " + fontsFolder);

                return;

            }



            try

            {

                // Register external fonts before loading the presentation

                string[] fontFolders = new string[] { fontsFolder };

                Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);



                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))

                {

                    // Embed any fonts that are used but not yet embedded

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



                    // Save the presentation before exiting

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }



                // Clear the font cache after processing

                Aspose.Slides.FontsLoader.ClearCache();

            }

            catch (NotSupportedException)

            {

                // The file format is not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., network errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

