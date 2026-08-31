// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: List embedded fonts, remove duplicates, and compress using C#

//

// Description:

// Demonstrates how to list embedded fonts, remove duplicate embedded fonts,

// and compress them using C# and Aspose.Slides for .NET. The example shows the

// required presentation-processing steps for PowerPoint files and produces

// the requested output in a standalone console application. Developers can

// use this pattern to automate PPTX workflows, validate results, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Embedded, Fonts, Remove,

// Duplicates, Compress, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate listing of embedded fonts, removal of duplicates, and compression.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.LowCode;



namespace FontManagementExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Retrieve embedded fonts

                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                // List embedded fonts

                Console.WriteLine("Embedded fonts before deduplication:");

                foreach (IFontData font in embeddedFonts)

                {

                    Console.WriteLine("- " + font.FontName);

                }



                // Remove duplicate embedded fonts based on font name

                HashSet<string> seenFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (IFontData font in embeddedFonts)

                {

                    if (seenFontNames.Contains(font.FontName))

                    {

                        presentation.FontsManager.RemoveEmbeddedFont(font);

                    }

                    else

                    {

                        seenFontNames.Add(font.FontName);

                    }

                }



                // Compress remaining embedded fonts

                Compress.CompressEmbeddedFonts(presentation);



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);



                // Dispose the presentation

                presentation.Dispose();



                // List embedded fonts after processing

                Console.WriteLine("Processing completed. Output saved to: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // Note: If the exception is due to unsupported format, the format is not supported.

            }

        }

    }

}

