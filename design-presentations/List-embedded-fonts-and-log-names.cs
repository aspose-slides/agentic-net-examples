// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: List embedded fonts and log names using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, retrieve all embedded

// fonts, log each font name to the console, and save the presentation using

// Aspose.Slides for .NET. This example is a self‑contained console application

// suitable for automating font validation or reporting in PPTX files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List Embedded Fonts, Font Names,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Verify which fonts are embedded in a presentation.

// - Generate reports of embedded font usage.

// - Integrate font checks into CI/CD pipelines for PowerPoint assets.

// - Build tools that process or transform PPTX files while preserving font data.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle loading errors (e.g., unsupported format)

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            // Retrieve embedded fonts

            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



            if (embeddedFonts != null && embeddedFonts.Length > 0)

            {

                foreach (Aspose.Slides.IFontData font in embeddedFonts)

                {

                    // Log each embedded font name

                    Console.WriteLine("Embedded font: " + font.FontName);

                }

            }

            else

            {

                Console.WriteLine("No embedded fonts found.");

            }



            try

            {

                // Save the presentation before exiting

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                Console.WriteLine("Failed to save presentation: " + ex.Message);

            }



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}

