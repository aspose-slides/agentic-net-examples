// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply Arabic font fallback and export slides to SVG using C#

//

// Description:

// Demonstrates how to add a font fallback rule for Arabic Unicode characters

// (U+0600–U+06FF) using Aspose.Slides for .NET, export each slide of a PPTX

// presentation to individual SVG files, and save the modified presentation.

// The example illustrates loading a presentation, configuring the FontsManager,

// creating an output directory, writing SVG files, and persisting the updated

// PPTX.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SVG, FontFallback, Arabic, Unicode, 

// Slide Export, Presentation Processing, .NET

//

// Use Cases:

// - Apply Arabic font fallback to ensure correct rendering of Arabic text.

// - Export PowerPoint slides to SVG for web or vector graphics workflows.

// - Automate PPTX processing and conversion in C# console applications.

// - Integrate font fallback configuration into existing .NET presentation pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackSvgExport

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputSvgDir = "output_svg";

            string outputPresPath = "output.pptx";



            if (!File.Exists(inputPath))

            {

                // Input file does not exist

                return;

            }



            try

            {

                // Load presentation

                Presentation pres = new Presentation(inputPath);



                // Create fallback rule for Arabic Unicode range (0x0600-0x06FF) using an Arabic OpenType font

                IFontFallBackRule arabicRule = new FontFallBackRule(0x0600u, 0x06FFu, "Amiri");

                // Add rule to collection

                IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;

                rules.Add(arabicRule);

                pres.FontsManager.FontFallBackRulesCollection = rules;



                // Ensure output directory exists

                if (!Directory.Exists(outputSvgDir))

                {

                    Directory.CreateDirectory(outputSvgDir);

                }



                // Export each slide as SVG

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    string svgPath = Path.Combine(outputSvgDir, $"slide_{i + 1}.svg");

                    using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                    {

                        pres.Slides[i].WriteAsSvg(fs);

                    }

                }



                // Save presentation before exit

                pres.Save(outputPresPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other exceptions

                // Format not supported

            }

        }

    }

}

