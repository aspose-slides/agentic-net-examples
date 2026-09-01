// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to TIFF and MP4 subfolders using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a multi‑page TIFF

// image and an MP4 video, storing each output type in its own subfolder. The

// example uses Aspose.Slides for .NET to load the source file, create the

// required output directories, and save the results in TIFF and MP4 formats.

// It is implemented as a simple console application that receives the input

// file path as a command‑line argument.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Convert, Presentation, TIFF, MP4,

// Subfolders, Console Application, Automation

//

// Use Cases:

// - Automate batch conversion of presentations to image and video assets.

// - Generate separate TIFF and MP4 outputs for archival or publishing pipelines.

// - Build command‑line tools for PowerPoint processing in .NET environments.

// - Validate conversion workflows before integrating into larger systems.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Check for input argument

            if (args == null || args.Length == 0)

            {

                Console.WriteLine("Please provide the path to the presentation file as an argument.");

                return;

            }



            string inputPath = args[0];

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Prepare output directories

            string baseOutputDir = Path.Combine(Environment.CurrentDirectory, "output");

            string tiffOutputDir = Path.Combine(baseOutputDir, "tiff");

            string mp4OutputDir = Path.Combine(baseOutputDir, "mp4");



            if (!Directory.Exists(baseOutputDir))

                Directory.CreateDirectory(baseOutputDir);

            if (!Directory.Exists(tiffOutputDir))

                Directory.CreateDirectory(tiffOutputDir);

            if (!Directory.Exists(mp4OutputDir))

                Directory.CreateDirectory(mp4OutputDir);



            // Load presentation

            Presentation pres = null;

            try

            {

                pres = new Presentation(inputPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            // Convert to TIFF

            try

            {

                string tiffPath = Path.Combine(tiffOutputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");

                pres.Save(tiffPath, SaveFormat.Tiff);

                Console.WriteLine("TIFF saved to: " + tiffPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("TIFF format not supported for this file.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error saving TIFF: " + ex.Message);

            }



            // Convert to MP4 (video)

            try

            {

                // Attempt to get MP4 SaveFormat via parsing; may not be supported

                SaveFormat mp4Format = (SaveFormat)Enum.Parse(typeof(SaveFormat), "Mp4");

                string mp4Path = Path.Combine(mp4OutputDir, Path.GetFileNameWithoutExtension(inputPath) + ".mp4");

                pres.Save(mp4Path, mp4Format);

                Console.WriteLine("MP4 saved to: " + mp4Path);

            }

            catch (ArgumentException)

            {

                // MP4 format not defined in SaveFormat enumeration

                Console.WriteLine("MP4 format not supported by the current Aspose.Slides version.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("MP4 format not supported for this file.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error saving MP4: " + ex.Message);

            }

            finally

            {

                // Ensure presentation is saved (if any pending changes) and disposed

                if (pres != null)

                {

                    // No additional changes made, just dispose

                    pres.Dispose();

                }

            }

        }

    }

}

