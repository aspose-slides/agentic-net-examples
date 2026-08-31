// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure fallback and render presentation PNG using C#

//

// Description:

// Demonstrates how to configure font fallback rules and render the first slide

// of a PowerPoint presentation to a PNG image using Aspose.Slides for .NET.

// The example loads a PPTX file, sets up Unicode range based font fallback,

// saves the rendered slide as PNG, and then saves the (potentially modified)

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Configure, Fallback, FontFallback, Render, Presentation, ImageExport, Office Automation

//

// Use Cases:

// - Apply custom font fallback for specific Unicode ranges in presentations.

// - Generate PNG images from slides for thumbnails or previews.

// - Automate PowerPoint processing workflows in .NET applications.

// - Validate and transform PPTX files before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputImagePath = "slide0.png";

            string outputPresentationPath = "output.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Configure font fallback rules

                    IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

                    rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                    pres.FontsManager.FontFallBackRulesCollection = rules;



                    // Render first slide to PNG

                    IImage image = pres.Slides[0].GetImage(1f, 1f);

                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);



                    // Save presentation before exit

                    pres.Save(outputPresentationPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

