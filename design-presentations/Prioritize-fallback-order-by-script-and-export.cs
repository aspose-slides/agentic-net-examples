// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Prioritize fallback order by script and export using C#

//

// Description:

// Demonstrates how to define font fallback rules for specific Unicode ranges,

// render the first slide to a PNG image, and save the updated presentation

// using Aspose.Slides for .NET. The example shows how to prioritize fallback

// fonts for Cyrillic, Greek, and Emoji characters, export a slide image, and

// write the modified PPTX file.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Font fallback, Unicode ranges, Slide export,

// Image rendering, Presentation processing, .NET automation

//

// Use Cases:

// - Apply custom font fallback rules for multilingual presentations.

// - Export slide thumbnails or images from a PPTX file.

// - Automate PPTX modifications and re‑save with updated font settings.

// - Integrate presentation processing into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";

        string imagePath = "slide1.png";



        // Override paths with command‑line arguments if provided

        if (args.Length > 0)

        {

            inputPath = args[0];

        }

        if (args.Length > 1)

        {

            outputPath = args[1];

        }

        if (args.Length > 2)

        {

            imagePath = args[2];

        }



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Create a collection of font fallback rules

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();



            // Cyrillic range fallback: first try Arial, then Times New Roman

            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));

            // Greek range fallback: Calibri

            rules.Add(new Aspose.Slides.FontFallBackRule(0x0370, 0x03FF, "Calibri"));

            // Emoji range fallback: multiple fonts in order of preference

            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };

            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));



            // Assign the fallback rules to the presentation

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Render the first slide to an image

            Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);

            img.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            img.Dispose();



            // Save the modified presentation

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (NotSupportedException ex)

        {

            // Format not supported

            Console.WriteLine("File format not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

