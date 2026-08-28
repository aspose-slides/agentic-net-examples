// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT and PPTX to SWF with 80% JPEG quality including hidden slides using C#

//

// Description:

// Demonstrates how to batch convert PPT and PPTX files to SWF format with JPEG

// quality set to 80 and hidden slides included, using C# and Aspose.Slides for .NET.

// The example processes all presentations in a specified directory (or the

// current working directory) and saves the resulting SWF files alongside the

// source files. Developers can use this pattern to automate PowerPoint to SWF

// conversion workflows, handle hidden content, or integrate presentation

// processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, SWF, Aspose.Slides for .NET, Batch, Convert, 80Jpeg,

// Hidden Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPT/PPTX to SWF with specific JPEG quality.

// - Include hidden slides during conversion for complete presentation output.

// - Build C# utilities for PowerPoint presentation processing and publishing.

// - Validate and transform presentation files in .NET environments.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input directory from arguments or use current directory

        string inputDirectory;

        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

        {

            inputDirectory = args[0];

        }

        else

        {

            inputDirectory = Environment.CurrentDirectory;

        }



        // Collect PPT and PPTX files

        string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt");

        string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");

        string[] allFiles = new string[pptFiles.Length + pptxFiles.Length];

        pptFiles.CopyTo(allFiles, 0);

        pptxFiles.CopyTo(allFiles, pptFiles.Length);



        foreach (string filePath in allFiles)

        {

            // Verify file existence

            if (!File.Exists(filePath))

            {

                Console.WriteLine($"File not found: {filePath}");

                continue;

            }



            try

            {

                // Load presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))

                {

                    // Configure SWF options

                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                    swfOptions.JpegQuality = 80;

                    swfOptions.ShowHiddenSlides = true;



                    // Prepare output path

                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".swf";

                    string outputPath = Path.Combine(inputDirectory, outputFileName);



                    // Save as SWF with options

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine($"Format not supported for file: {filePath}");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");

            }

        }

    }

}

