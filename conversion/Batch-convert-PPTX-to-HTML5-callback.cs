// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to HTML5 callback using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations (PPTX and other

// supported formats) to HTML5 using Aspose.Slides for .NET while receiving

// progress updates through a custom IProgressCallback implementation.

// The example processes all files in an input directory, saves the HTML5

// output to a target directory, and optionally saves a copy of the original

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Convert, HTML5, 

// Presentation Processing, Office Automation, Progress Callback

//

// Use Cases:

// - Automate batch conversion of PowerPoint files to HTML5 with progress reporting.

// - Build command‑line tools for PowerPoint presentation processing in .NET.

// - Integrate presentation conversion into CI pipelines or web services.

// - Monitor conversion progress for large or numerous presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvertToHtml5

{

    // Implements IProgressCallback to receive progress updates during saving

    public class SlideLoadProgressCallback : IProgressCallback

    {

        public void Reporting(double progressValue)

        {

            // Write progress percentage to console

            Console.WriteLine($"Saving progress: {progressValue}%");

        }

    }



    class Program

    {

        static void Main(string[] args)

        {

            // Expect two arguments: input folder and output folder

            if (args.Length < 2)

            {

                Console.WriteLine("Usage: BatchConvertToHtml5 <inputFolder> <outputFolder>");

                return;

            }



            string inputFolder = args[0];

            string outputFolder = args[1];



            // Verify input folder exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine($"Input folder does not exist: {inputFolder}");

                return;

            }



            // Create output folder if it does not exist

            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            // Supported presentation extensions

            string[] supportedExtensions = new string[] { ".pptx", ".ppt", ".odp", ".potx", ".pot", ".pptm", ".ppsx", ".pps", ".potm", ".otp", ".fodp" };



            // Process each file in the input folder

            foreach (string filePath in Directory.GetFiles(inputFolder))

            {

                // Skip files with unsupported extensions

                if (Array.IndexOf(supportedExtensions, Path.GetExtension(filePath).ToLower()) < 0)

                {

                    Console.WriteLine($"Skipping unsupported file format: {Path.GetFileName(filePath)}");

                    continue;

                }



                // Verify the file exists before loading

                if (!File.Exists(filePath))

                {

                    Console.WriteLine($"File not found: {filePath}");

                    continue;

                }



                try

                {

                    // Load the presentation

                    using (Presentation presentation = new Presentation(filePath))

                    {

                        // Prepare HTML5 export options with custom progress callback

                        Html5Options options = new Html5Options();

                        options.ProgressCallback = new SlideLoadProgressCallback();



                        // Example of enabling animation of transitions (customizable)

                        options.AnimateTransitions = true;



                        // Determine output file name

                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".html";

                        string outputPath = Path.Combine(outputFolder, outputFileName);



                        // Save as HTML5

                        presentation.Save(outputPath, SaveFormat.Html5, options);



                        // Save presentation before exit (as per requirement)

                        string tempSavePath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + "_saved.pptx");

                        presentation.Save(tempSavePath, SaveFormat.Pptx);

                    }



                    Console.WriteLine($"Successfully converted: {Path.GetFileName(filePath)}");

                }

                catch (PptxUnsupportedFormatException)

                {

                    // Format not supported for PPTX

                    Console.WriteLine($"Unsupported PPTX format: {Path.GetFileName(filePath)}");

                }

                catch (PptUnsupportedFormatException)

                {

                    // Format not supported for PPT

                    Console.WriteLine($"Unsupported PPT format: {Path.GetFileName(filePath)}");

                }

                catch (Exception ex)

                {

                    // General exception handling

                    Console.WriteLine($"Error processing file {Path.GetFileName(filePath)}: {ex.Message}");

                }

            }

        }

    }

}

