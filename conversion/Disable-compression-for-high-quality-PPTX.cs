using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DisableCompressionForHighQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to configuration file
            string configPath = "config.txt";
            bool highQuality = false;

            // Read configuration if it exists
            if (File.Exists(configPath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(configPath);
                    foreach (string line in lines)
                    {
                        string trimmed = line.Trim();
                        if (trimmed.StartsWith("highQuality", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] parts = trimmed.Split('=');
                            if (parts.Length == 2 && bool.TryParse(parts[1].Trim(), out bool result))
                            {
                                highQuality = result;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading configuration: " + ex.Message);
                }
            }

            // Expect input file path as first argument
            if (args.Length == 0)
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

            // Output path (same directory with suffix)
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + "_processed.pptx");

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    if (highQuality)
                    {
                        // Disable image compression by setting resolution to DocumentResolution
                        for (int i = 0; i < pres.Slides.Count; i++)
                        {
                            ISlide slide = pres.Slides[i];
                            for (int j = 0; j < slide.Shapes.Count; j++)
                            {
                                if (slide.Shapes[j] is IPictureFrame pictureFrame)
                                {
                                    // CompressImage with DocumentResolution (no compression)
                                    pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.DocumentResolution);
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}