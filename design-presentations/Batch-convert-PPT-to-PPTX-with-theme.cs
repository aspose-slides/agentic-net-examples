// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT to PPTX with theme using C#

//

// Description:

// Demonstrates how to batch convert legacy PPT files to PPTX format while

// applying an external theme (.thmx) using C# and Aspose.Slides for .NET.

// The example processes all PPT files in a specified input directory,

// applies the theme to each master slide, and saves the converted files

// to an output directory.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Batch, Convert, Theme,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of legacy PPT presentations to modern PPTX with a

//   consistent theme.

// - Build command‑line tools for bulk PowerPoint presentation processing.

// - Integrate theme application into .NET workflows for presentation

//   preparation or publishing.

// - Validate and transform PPT files before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvert

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input directory containing PPT files

            string inputDir = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : "InputPpt";

            // Output directory for converted PPTX files

            string outputDir = args.Length > 1 && !String.IsNullOrEmpty(args[1]) ? args[1] : "OutputPptx";

            // Path to the external theme file (.thmx)

            string themePath = args.Length > 2 && !String.IsNullOrEmpty(args[2]) ? args[2] : "Theme.thmx";



            // Verify directories exist or create them

            if (!Directory.Exists(inputDir))

            {

                Console.WriteLine($"Input directory does not exist: {inputDir}");

                return;

            }

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }

            if (!File.Exists(themePath))

            {

                Console.WriteLine($"Theme file not found: {themePath}");

                return;

            }



            // Process each PPT file in the input directory

            string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt");

            foreach (string pptFile in pptFiles)

            {

                try

                {

                    // Load the PPT presentation

                    Presentation presentation = new Presentation(pptFile);



                    // Apply the external theme to all master slides

                    foreach (IMasterSlide master in presentation.Masters)

                    {

                        master.ApplyExternalThemeToDependingSlides(themePath);

                    }



                    // Determine output file path with .pptx extension

                    string outputFileName = Path.GetFileNameWithoutExtension(pptFile) + ".pptx";

                    string outputPath = Path.Combine(outputDir, outputFileName);



                    // Save the presentation as PPTX

                    presentation.Save(outputPath, SaveFormat.Pptx);



                    // Dispose the presentation object

                    presentation.Dispose();



                    Console.WriteLine($"Converted: {pptFile} -> {outputPath}");

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine($"File format not supported for: {pptFile}");

                }

                catch (Exception ex)

                {

                    // General exception handling

                    Console.WriteLine($"Error processing {pptFile}: {ex.Message}");

                }

            }

        }

    }

}

