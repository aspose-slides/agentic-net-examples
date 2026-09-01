// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT to XPS preserving hierarchy using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint (.ppt and .pptx) files to XPS

// format while preserving the original folder hierarchy. The example uses

// Aspose.Slides for .NET to load each presentation, convert it to XPS, and

// write the output to a corresponding directory structure under a specified

// output root. It includes handling for missing directories, unsupported

// formats, and general error conditions.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, XPS, Aspose.Slides for .NET, Batch Conversion,

// Preserve Hierarchy, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate bulk conversion of PPT/PPTX files to XPS for archiving or printing.

// - Maintain source folder structure in the converted output.

// - Integrate PowerPoint conversion into .NET backend services or tools.

// - Process presentations from network shares with error handling.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvertPptToXps

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input directory (network share) and output directory can be passed as arguments

            string inputRoot;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

            {

                inputRoot = args[0];

            }

            else

            {

                inputRoot = @"\\networkshare\presentations";

            }



            string outputRoot;

            if (args.Length > 1 && !String.IsNullOrEmpty(args[1]))

            {

                outputRoot = args[1];

            }

            else

            {

                outputRoot = @"C:\ConvertedXps";

            }



            // Verify that the input directory exists

            if (!Directory.Exists(inputRoot))

            {

                Console.WriteLine("Input directory does not exist: " + inputRoot);

                return;

            }



            // Ensure the output root directory exists

            if (!Directory.Exists(outputRoot))

            {

                Directory.CreateDirectory(outputRoot);

            }



            // Collect all .ppt and .pptx files recursively

            List<string> allFiles = new List<string>();

            allFiles.AddRange(Directory.GetFiles(inputRoot, "*.ppt", SearchOption.AllDirectories));

            allFiles.AddRange(Directory.GetFiles(inputRoot, "*.pptx", SearchOption.AllDirectories));



            foreach (string inputFilePath in allFiles)

            {

                // Compute relative path to preserve folder hierarchy

                string relativePath = Path.GetRelativePath(inputRoot, inputFilePath);

                string outputFilePath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".xps"));

                string outputDirectory = Path.GetDirectoryName(outputFilePath);



                // Ensure the output subdirectory exists

                if (!Directory.Exists(outputDirectory))

                {

                    Directory.CreateDirectory(outputDirectory);

                }



                try

                {

                    // Load the presentation and save as XPS

                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFilePath))

                    {

                        pres.Save(outputFilePath, SaveFormat.Xps);

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported – skip this file

                    Console.WriteLine("File format not supported for: " + inputFilePath);

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., file access issues)

                    Console.WriteLine("Error processing file: " + inputFilePath);

                    Console.WriteLine("Exception: " + ex.Message);

                }

            }



            // All presentations have been saved before exiting

        }

    }

}

