// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to HTML5 hierarchy using C#

//

// Description:

// Demonstrates how to batch convert PPTX files to an HTML5 hierarchy using C#

// and Aspose.Slides for .NET. The example recursively scans an input folder for

// PPTX files, preserves the original folder structure in the output location,

// and saves each presentation as a standalone HTML5 file with its resources.

// This pattern can be used to automate PPTX conversion workflows in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Convert, HTML5, 

// Presentation Processing, Office Automation, Folder Hierarchy

//

// Use Cases:

// - Automate batch conversion of PPTX files to HTML5 while preserving directory structure.

// - Build C# utilities for PowerPoint presentation processing and publishing.

// - Integrate PPTX to HTML5 conversion into .NET services or CI pipelines.

// - Validate and transform presentations before web deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input folder

        string inputFolder;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputFolder = args[0];

        }

        else

        {

            inputFolder = Path.Combine(Environment.CurrentDirectory, "Input");

        }



        // Determine output folder

        string outputFolder;

        if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))

        {

            outputFolder = args[1];

        }

        else

        {

            outputFolder = Path.Combine(Environment.CurrentDirectory, "Output");

        }



        // Verify input folder exists

        if (!Directory.Exists(inputFolder))

        {

            Console.WriteLine("Input folder does not exist: " + inputFolder);

            return;

        }



        // Ensure output folder exists

        if (!Directory.Exists(outputFolder))

        {

            Directory.CreateDirectory(outputFolder);

        }



        // Get all PPTX files recursively

        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.AllDirectories);

        foreach (string pptxPath in pptxFiles)

        {

            try

            {

                // Compute relative path to preserve hierarchy

                string relativePath = Path.GetRelativePath(inputFolder, pptxPath);

                string relativeDir = Path.GetDirectoryName(relativePath);

                string targetDir = Path.Combine(outputFolder, relativeDir ?? string.Empty);

                if (!Directory.Exists(targetDir))

                {

                    Directory.CreateDirectory(targetDir);

                }



                // Define output HTML5 file path

                string outputFileName = Path.GetFileNameWithoutExtension(pptxPath) + ".html";

                string outputPath = Path.Combine(targetDir, outputFileName);



                // Load presentation and save as HTML5

                using (Presentation pres = new Presentation(pptxPath))

                {

                    Html5Options options = new Html5Options

                    {

                        // Store external resources in the same directory as the HTML file

                        OutputPath = targetDir

                    };

                    pres.Save(outputPath, SaveFormat.Html5, options);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error processing file: " + pptxPath);

                Console.WriteLine(ex.Message);

            }

        }

    }

}

