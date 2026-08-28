// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML embed fonts using C#

//

// Description:

// Demonstrates how to export a PPTX file to a single HTML document with

// embedded fonts using C# and Aspose.Slides for .NET. The example loads a

// presentation, ensures all used fonts are embedded as base64 data, and

// saves the result as HTML. This pattern can be used in console utilities

// or integrated into larger .NET applications for PowerPoint processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Embed Fonts, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to self-contained HTML files with embedded fonts.

// - Build automation tools that prepare PowerPoint content for web publishing.

// - Ensure font fidelity when displaying slides in browsers without installing fonts.

// - Integrate PPTX-to-HTML conversion into .NET services or desktop applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesHtmlExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.html";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Embed all fonts used in the presentation (if not already embedded)

                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                    foreach (IFontData font in allFonts)

                    {

                        bool alreadyEmbedded = false;

                        foreach (IFontData embedded in embeddedFonts)

                        {

                            if (embedded.FontName.Equals(font.FontName, StringComparison.OrdinalIgnoreCase))

                            {

                                alreadyEmbedded = true;

                                break;

                            }

                        }



                        if (!alreadyEmbedded)

                        {

                            // Embed the entire font (all characters) as base64 data

                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                        }

                    }



                    // Set HTML export options (fonts will be embedded as base64)

                    HtmlOptions htmlOptions = new HtmlOptions();



                    // Save the presentation as a single HTML file with embedded fonts

                    presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

                }



                Console.WriteLine("Presentation exported successfully to: " + outputPath);

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported for export

                Console.WriteLine("The specified format is not supported for export.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors, Aspose.Slides exceptions)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

