// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test wildcard font fallback rules using C#

//

// Description:

// Demonstrates how to define wildcard font fallback rules for specific Unicode

// ranges (e.g., Cyrillic and Emoji) using Aspose.Slides for .NET. The example

// loads an existing PPTX file, applies the fallback rules, renders the first

// slide to a PNG image, and saves the modified presentation. This pattern can

// be used to ensure proper font substitution when a presentation contains

// characters that are not available in the original fonts.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Fallback, Wildcard, Unicode,

// Cyrillic, Emoji, Presentation Processing, Office Automation

//

// Use Cases:

// - Test and verify wildcard font fallback rules in PowerPoint files.

// - Generate slide images after applying custom font substitution.

// - Automate presentation processing pipelines that require specific font handling.

// - Validate that fallback fonts are correctly applied for unsupported characters.

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

        string outputPath = "output.pptx";

        string imagePath = "slide1.png";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));

            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Noto Color Emoji" };

            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            presentation.FontsManager.FontFallBackRulesCollection = rules;



            Aspose.Slides.IImage image = presentation.Slides[0].GetImage(1f, 1f);

            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            image.Dispose();



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // format not supported

            Console.WriteLine("File format not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

