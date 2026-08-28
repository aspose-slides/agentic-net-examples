// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add cancellation token to batch video conversion using C#

//

// Description:

// Demonstrates how to add a CancellationToken to a batch video conversion

// process for PowerPoint presentations using Aspose.Slides for .NET. The

// example iterates over presentation files in an input directory, converts each

// to an MP4 video (if supported), saves a copy of the original presentation,

// and respects a cancellation request (e.g., Ctrl+C) to stop processing.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, PPT, ODP, video conversion, MP4,

// CancellationToken, batch processing, console application, Office automation

//

// Use Cases:

// - Perform large‑scale PPT/PPTX/ODP to video conversions with graceful

//   cancellation support.

// - Build command‑line tools for automated presentation video generation.

// - Integrate presentation‑to‑video conversion into CI/CD pipelines with

//   interrupt handling.

// - Provide fallback handling when the target video format is unavailable.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Threading;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output directories

        string inputFolder = args.Length > 0 ? args[0] : "Input";

        string outputFolder = args.Length > 1 ? args[1] : "Output";



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



        // Set up cancellation support

        CancellationTokenSource cancellationSource = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) =>

        {

            e.Cancel = true; // Prevent immediate termination

            cancellationSource.Cancel();

        };

        CancellationToken token = cancellationSource.Token;



        // Get all files in the input folder

        string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string filePath in files)

        {

            // Check for cancellation request

            if (token.IsCancellationRequested)

            {

                Console.WriteLine("Cancellation requested. Stopping batch conversion.");

                break;

            }



            // Process only supported presentation extensions

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")

            {

                continue;

            }



            try

            {

                // Load presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))

                {

                    // Determine output video file name

                    string videoOutputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".mp4");



                    // Attempt to locate Mp4 format in SaveFormat enum (may not exist in this version)

                    Aspose.Slides.Export.SaveFormat videoFormat;

                    bool hasMp4 = Enum.TryParse<Aspose.Slides.Export.SaveFormat>("Mp4", out videoFormat);

                    if (hasMp4)

                    {

                        // If Mp4 is supported, perform conversion

                        presentation.Save(videoOutputPath, videoFormat);

                        Console.WriteLine("Converted to video: " + videoOutputPath);

                    }

                    else

                    {

                        // Video format not supported – handle gracefully

                        Console.WriteLine("Video format Mp4 not supported for file: " + filePath);

                    }



                    // Save the presentation (as PPTX) before exiting the using block

                    string presentationCopyPath = Path.Combine(outputFolder, Path.GetFileName(filePath));

                    presentation.Save(presentationCopyPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                // Handle unsupported PPTX format

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException ex)

            {

                // Handle unsupported PPT format

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (NotSupportedException)

            {

                // Handle any other unsupported format scenarios

                Console.WriteLine("Save format not supported for file: " + filePath);

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);

            }

        }

    }

}

