// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace missing fonts with fallback before JPEG using C#

//

// Description:

// Demonstrates how to replace missing fonts with fallback before JPEG using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Replace, Missing, Fonts, 

// Fallback, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replace missing fonts with fallback before JPEG.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputPptxPath = "output.pptx";

            string outputDir = "output_images";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Set fallback font for missing characters (e.g., Arial)

                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();

                fallbackRules.Add(new FontFallBackRule(0x0, 0xFFFF, "Arial"));

                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;



                // Ensure output directory exists

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Export each slide to JPG

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    IImage slideImage = presentation.Slides[i].GetImage(1f, 1f);

                    string slidePath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");

                    slideImage.Save(slidePath, Aspose.Slides.ImageFormat.Jpeg);

                    slideImage.Dispose();

                }



                // Save the modified presentation before exiting

                presentation.Save(outputPptxPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // TODO: Add handling for unsupported file formats if needed

            }

        }

    }

}

