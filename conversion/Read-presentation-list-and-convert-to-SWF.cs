// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Read presentation list and convert to SWF using C#

//

// Description:

// Demonstrates how to read a list of PowerPoint presentation file paths from a

// text file and convert each presentation to SWF format using Aspose.Slides for

// .NET. The example shows how to load presentations, apply optional SWF

// conversion settings, and save the resulting SWF files alongside the source

// files. This pattern can be used to batch‑process PPT/PPTX files for web

// preview or archival purposes.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, SWF, Aspose.Slides for .NET, Read, Presentation,

// List, Convert, Batch Processing, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PowerPoint presentations to SWF for web viewers.

// - Build C# utilities that process multiple presentation files based on a list.

// - Integrate presentation conversion into .NET applications or CI pipelines.

// - Validate and transform PPTX files before publishing or archiving.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Path to the text file containing presentation paths

        string listFilePath = "presentations.txt";

        if (!File.Exists(listFilePath))

        {

            Console.WriteLine("List file not found: " + listFilePath);

            return;

        }



        string[] lines = File.ReadAllLines(listFilePath);

        foreach (string line in lines)

        {

            string inputPath = line.Trim();

            if (inputPath.Length == 0)

                continue;



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Presentation file not found: " + inputPath);

                continue;

            }



            try

            {

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                    // Set any desired options here, e.g., swfOptions.Compressed = true;



                    string outputDirectory = Path.GetDirectoryName(inputPath);

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";

                    string outputPath = Path.Combine(outputDirectory, outputFileName);



                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    Console.WriteLine("Converted to SWF: " + outputPath);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("Format not supported for file: " + inputPath);

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors)

                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);

            }

        }

    }

}

