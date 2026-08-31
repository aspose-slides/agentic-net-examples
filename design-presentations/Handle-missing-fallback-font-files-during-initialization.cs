// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Handle missing fallback font files during initialization using C#

//

// Description:

// Demonstrates how to handle missing fallback font files during initialization 

// using C# and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Missing, Fallback, 

// Font, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate handle missing fallback font files during initialization.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string presentationPath = "input.pptx";

            string fallbackFontPath = "fallback.ttf";

            string outputPresentationPath = "output.pptx";

            string outputImagePath = "output.png";



            // Check if the presentation file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            // Check if the fallback font file exists

            if (!File.Exists(fallbackFontPath))

            {

                Console.WriteLine("Fallback font file not found: " + fallbackFontPath);

                return;

            }



            try

            {

                // Load the fallback font into Aspose.Slides

                byte[] fallbackFontData = File.ReadAllBytes(fallbackFontPath);

                Aspose.Slides.FontsLoader.LoadExternalFont(fallbackFontData);



                // Create a new presentation instance

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);



                // Initialize fallback rules collection

                Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();



                // Add a fallback rule (example Unicode range and font name)

                string fallbackFontName = Path.GetFileNameWithoutExtension(fallbackFontPath);

                rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, fallbackFontName));



                // Assign the rules collection to the presentation's FontsManager

                pres.FontsManager.FontFallBackRulesCollection = rules;



                // Render the first slide to an image

                Aspose.Slides.IImage image = pres.Slides[0].GetImage(1f, 1f);

                image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);



                // Save the modified presentation

                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);



                // Clean up

                pres.Dispose();

                Aspose.Slides.FontsLoader.ClearCache();



                Console.WriteLine("Processing completed successfully.");

            }

            catch (Exception ex)

            {

                // Handle any unexpected errors (e.g., unsupported format)

                Console.WriteLine("An error occurred: " + ex.Message);

                // If the exception is due to unsupported format, you could add a comment here.

                // Format not supported.

            }

        }

    }

}

