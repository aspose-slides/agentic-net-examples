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