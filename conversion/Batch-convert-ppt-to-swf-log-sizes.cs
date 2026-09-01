// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert ppt to swf log sizes using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations (PPT, PPTX) to

// SWF format while logging the original and converted file sizes using C# and

// Aspose.Slides for .NET. The example processes each file supplied via command‑line

// arguments, saves the SWF output, and writes size information to the console.

// This pattern can be used for automated conversion workflows and size analysis.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, SWF, Aspose.Slides for .NET, Batch Conversion,

// File Size Logging, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPT/PPTX files to SWF format.

// - Generate size reports for original and converted presentations.

// - Integrate PowerPoint to SWF conversion into .NET command‑line tools.

// - Validate conversion results before publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        if (args == null || args.Length == 0)

        {

            Console.WriteLine("Please provide at least one presentation file path.");

            return;

        }



        foreach (string inputPath in args)

        {

            try

            {

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine($"File not found: {inputPath}");

                    continue;

                }



                FileInfo inputInfo = new FileInfo(inputPath);

                long originalSize = inputInfo.Length;



                string directory = Path.GetDirectoryName(inputPath);

                string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                string outputPath = Path.Combine(directory ?? "", filenameWithoutExt + ".swf");



                using (Presentation presentation = new Presentation(inputPath))

                {

                    SwfOptions swfOptions = new SwfOptions();

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                }



                FileInfo outputInfo = new FileInfo(outputPath);

                long swfSize = outputInfo.Length;



                Console.WriteLine($"Converted: {inputPath}");

                Console.WriteLine($"Original size: {originalSize} bytes");

                Console.WriteLine($"SWF size: {swfSize} bytes");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine($"Format not supported for file: {inputPath}");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs)

                Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");

            }

        }

    }

}

