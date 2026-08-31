// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create emoji fallback and export PNG using C#

//

// Description:

// Demonstrates how to create a PowerPoint presentation containing an emoji,

// apply a font fallback rule for emoji characters, export the first slide as a

// PNG image, and save the updated presentation using Aspose.Slides for .NET.

// The example also shows how to generate a source PPTX file on‑the‑fly if it

// does not exist.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, PNG, Emoji, FontFallback, 

// Presentation Export, Slide Image, Office Automation

//

// Use Cases:

// - Generate a PPTX with emoji content when missing.

// - Apply font fallback to ensure emoji rendering across platforms.

// - Export slides containing emojis to PNG for preview or publishing.

// - Automate PPTX processing and image extraction in .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputImagePath = "slide0.png";



        // Ensure the input presentation exists; create one with an emoji if missing

        if (!File.Exists(inputPath))

        {

            using (Presentation presCreate = new Presentation())

            {

                // Add a rectangle shape containing an emoji character

                IAutoShape shape = (IAutoShape)presCreate.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

                shape.AddTextFrame("Hello 😊");

                // Save the newly created presentation

                presCreate.Save(inputPath, SaveFormat.Pptx);

            }

        }



        try

        {

            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Create a fallback rules collection for emoji characters

                IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

                // Emoji Unicode range (Emoticons)

                rules.Add(new FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji"));

                // Assign the fallback rules to the presentation's FontsManager

                pres.FontsManager.FontFallBackRulesCollection = rules;



                // Export the first slide as PNG to verify rendering

                IImage img = pres.Slides[0].GetImage(1f, 1f);

                img.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                img.Dispose();



                // Save the presentation after applying fallback rules

                pres.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported formats

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

