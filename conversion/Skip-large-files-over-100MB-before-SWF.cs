// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Skip large files over 100MB before SWF conversion using C#

//

// Description:

// Demonstrates how to iterate over presentation files supplied via command‑line

// arguments, skip any file larger than 100 MB, and convert the remaining PPT/PPTX

// files to SWF format using Aspose.Slides for .NET. The example shows file size

// checking, path handling, and basic error handling in a console application.

// Developers can adapt this pattern for batch processing or integration into

// larger automation pipelines.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SWF, conversion, batch processing, 

// file size check, skip large files, console application

//

// Use Cases:

// - Batch convert PowerPoint presentations to SWF while ignoring files >100 MB.

// - Integrate size‑based filtering into automated document conversion workflows.

// - Build command‑line tools for presentation processing in .NET environments.

// - Prevent out‑of‑memory or performance issues caused by very large source files.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchSwfConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            if (args == null || args.Length == 0)

            {

                Console.WriteLine("Please provide at least one presentation file path as an argument.");

                return;

            }



            foreach (var arg in args)

            {

                try

                {

                    var inputPath = arg;

                    if (!File.Exists(inputPath))

                    {

                        Console.WriteLine($"File not found: {inputPath}");

                        continue;

                    }



                    var fileInfo = new FileInfo(inputPath);

                    const long maxSizeBytes = 100L * 1024 * 1024; // 100 MB

                    if (fileInfo.Length > maxSizeBytes)

                    {

                        Console.WriteLine($"Skipping file larger than 100 MB: {inputPath}");

                        continue;

                    }



                    var outputPath = Path.Combine(

                        Path.GetDirectoryName(inputPath) ?? string.Empty,

                        Path.GetFileNameWithoutExtension(inputPath) + ".swf");



                    using (var presentation = new Presentation(inputPath))

                    {

                        var swfOptions = new SwfOptions

                        {

                            // Example option: include viewer

                            ViewerIncluded = true

                        };



                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                        Console.WriteLine($"Converted to SWF: {outputPath}");

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine($"The format of the file is not supported for conversion: {arg}");

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., I/O errors)

                    Console.WriteLine($"Error processing file {arg}: {ex.Message}");

                }

            }

        }

    }

}

