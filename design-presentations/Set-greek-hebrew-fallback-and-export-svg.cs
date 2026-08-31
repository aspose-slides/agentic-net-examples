// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set Greek Hebrew fallback and export SVG using C#

//

// Description:

// Demonstrates how to configure Greek and Hebrew font fallback rules and export

// each slide of a PowerPoint presentation to SVG using Aspose.Slides for .NET.

// The example also saves the modified presentation. This pattern can be used

// to ensure proper rendering of multilingual content and to generate SVG assets

// from PPTX files in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Greek, Hebrew, FontFallback,

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Apply Greek and Hebrew font fallback to a presentation.

// - Export slides as SVG files for web or documentation purposes.

// - Automate PPTX processing and SVG generation in .NET tools.

// - Validate multilingual presentation rendering before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackSvgDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputFolder = "output";

            string savedPresentationPath = Path.Combine(outputFolder, "output.pptx");



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Create fallback rules collection

                    IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

                    // Greek range

                    rules.Add(new FontFallBackRule(0x0370u, 0x03FFu, "Arial"));

                    // Hebrew range

                    rules.Add(new FontFallBackRule(0x0590u, 0x05FFu, "Times New Roman"));

                    // Assign to presentation

                    pres.FontsManager.FontFallBackRulesCollection = rules;



                    // Ensure output folder exists

                    if (!Directory.Exists(outputFolder))

                    {

                        Directory.CreateDirectory(outputFolder);

                    }



                    // Render each slide to SVG

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");

                        using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                        {

                            pres.Slides[i].WriteAsSvg(fs);

                        }

                    }



                    // Save presentation

                    pres.Save(savedPresentationPath, SaveFormat.Pptx);

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

