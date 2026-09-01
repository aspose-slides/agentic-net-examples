// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add network share fallback fonts and render using C#

//

// Description:

// Demonstrates how to load fallback fonts from a network share, configure

// font fallback rules for Unicode ranges (e.g., emojis), render the first slide

// of a PowerPoint presentation to a PNG image, and save the modified presentation

// using Aspose.Slides for .NET. The example includes handling of missing input files,

// error handling for font loading, and cleanup of the font cache.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Network Share, Fallback Fonts,

// FontFallBackRules, Rendering, Slide to Image, Presentation Processing

//

// Use Cases:

// - Load custom fonts from a network location for presentation rendering.

// - Define font fallback rules for specific Unicode ranges.

// - Convert a slide to an image file.

// - Save a presentation after applying font settings.

// - Automate PowerPoint processing in .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = @"C:\Presentations\input.pptx";

        string outputImagePath = @"C:\Presentations\output.png";

        string outputPresentationPath = @"C:\Presentations\output.pptx";

        string[] networkFontFolders = new string[] { @"\\NetworkShare\Fonts" };



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Load fonts from network share

        try

        {

            Aspose.Slides.FontsLoader.LoadExternalFonts(networkFontFolders);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Failed to load external fonts: " + ex.Message);

            // Continue without external fonts

        }



        try

        {

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

            {

                // Create fallback rules collection

                Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();



                // Define a fallback rule for a Unicode range (e.g., emojis)

                Aspose.Slides.IFontFallBackRule emojiRule = new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji");

                // Add additional fallback fonts

                emojiRule.AddFallBackFonts(new string[] { "Arial Unicode MS", "Noto Color Emoji" });



                // Add rule to collection

                rules.Add(emojiRule);



                // Assign the collection to the presentation's FontsManager

                pres.FontsManager.FontFallBackRulesCollection = rules;



                // Render first slide to an image

                Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);

                img.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                img.Dispose();



                // Save the presentation (ensure it's saved before exit)

                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error processing presentation: " + ex.Message);

        }

        finally

        {

            // Clear font cache

            Aspose.Slides.FontsLoader.ClearCache();

        }

    }

}

