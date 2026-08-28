// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion success size font warnings using C#

//

// Description:

// Demonstrates batch conversion of presentation files to PPTX format while

// logging conversion success, output file size, and any font substitution

// warnings using C# and Aspose.Slides for .NET. The example processes all files

// in an input folder, saves converted files to an output folder, and writes a

// detailed log for each operation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Conversion, Success, Size,

// Font, Logging, Batch Conversion, Presentation Processing

//

// Use Cases:

// - Automate batch conversion of presentations to PPTX with detailed logging.

// - Track output file sizes for storage or compliance purposes.

// - Detect and record font substitutions during conversion.

// - Integrate presentation conversion into .NET automation pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Util;



namespace BatchConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect three arguments: input folder, output folder, log file path

            if (args.Length < 3)

            {

                Console.WriteLine("Usage: BatchConversion <inputFolder> <outputFolder> <logFile>");

                return;

            }



            string inputFolder = args[0];

            string outputFolder = args[1];

            string logFilePath = args[2];



            // Verify input folder exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist: " + inputFolder);

                return;

            }



            // Ensure output folder exists

            Directory.CreateDirectory(outputFolder);

            // Ensure directory for log file exists

            string logDirectory = Path.GetDirectoryName(logFilePath);

            if (!string.IsNullOrEmpty(logDirectory))

            {

                Directory.CreateDirectory(logDirectory);

            }



            // Open log file for appending

            using (StreamWriter logWriter = new StreamWriter(logFilePath, true))

            {

                string[] files = Directory.GetFiles(inputFolder);

                foreach (string inputFile in files)

                {

                    try

                    {

                        // Check if file exists (redundant but per requirement)

                        if (!File.Exists(inputFile))

                        {

                            logWriter.WriteLine($"{DateTime.Now}: File not found - {inputFile}");

                            continue;

                        }



                        // Load presentation

                        Presentation presentation = new Presentation(inputFile);



                        // Determine output file path (convert to PPTX)

                        string outputFileName = Path.GetFileNameWithoutExtension(inputFile) + ".pptx";

                        string outputPath = Path.Combine(outputFolder, outputFileName);



                        // Save presentation as PPTX

                        presentation.Save(outputPath, SaveFormat.Pptx);



                        // Record file size

                        long fileSize = new FileInfo(outputPath).Length;



                        // Log success

                        logWriter.WriteLine($"{DateTime.Now}: SUCCESS - {inputFile} -> {outputPath} ({fileSize} bytes)");



                        // Log any font substitution warnings

                        foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())

                        {

                            logWriter.WriteLine($"{DateTime.Now}: FONT SUBSTITUTION - {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");

                        }



                        // Dispose presentation

                        presentation.Dispose();

                    }

                    catch (NotSupportedException)

                    {

                        // Format not supported

                        logWriter.WriteLine($"{DateTime.Now}: FORMAT NOT SUPPORTED - {inputFile} // format not supported");

                    }

                    catch (Exception ex)

                    {

                        // General exception handling (including web service errors)

                        logWriter.WriteLine($"{DateTime.Now}: ERROR - {inputFile} - {ex.Message}");

                    }

                }

            }

        }

    }

}

