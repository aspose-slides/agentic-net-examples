using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfGenerationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // ---------- Generate compressed SWF ----------
                    SwfOptions compressedOptions = new SwfOptions();
                    compressedOptions.Compressed = true; // default is true, set explicitly
                    string compressedSwfPath = "compressed.swf";
                    presentation.Save(compressedSwfPath, SaveFormat.Swf, compressedOptions);

                    // ---------- Generate uncompressed SWF ----------
                    SwfOptions uncompressedOptions = new SwfOptions();
                    uncompressedOptions.Compressed = false;
                    string uncompressedSwfPath = "uncompressed.swf";
                    presentation.Save(uncompressedSwfPath, SaveFormat.Swf, uncompressedOptions);

                    // ---------- Optional: Extract animation frames for visual comparison ----------
                    using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(presentation))
                    {
                        // Play animations at 33 FPS (compressed version)
                        using (PresentationPlayer player = new PresentationPlayer(generator, 33))
                        {
                            player.FrameTick += (sender, e) =>
                            {
                                string frameDir = Path.Combine("frames_compressed");
                                Directory.CreateDirectory(frameDir);
                                string framePath = Path.Combine(frameDir, $"frame_{sender.FrameIndex}.png");
                                e.GetFrame().Save(framePath, ImageFormat.Png);
                            };
                            generator.Run(presentation.Slides);
                        }

                        // Play animations at 45 FPS (uncompressed version)
                        using (PresentationPlayer player = new PresentationPlayer(generator, 45))
                        {
                            player.FrameTick += (sender, e) =>
                            {
                                string frameDir = Path.Combine("frames_uncompressed");
                                Directory.CreateDirectory(frameDir);
                                string framePath = Path.Combine(frameDir, $"frame_{sender.FrameIndex}.png");
                                e.GetFrame().Save(framePath, ImageFormat.Png);
                            };
                            generator.Run(presentation.Slides);
                        }
                    }

                    // Save the presentation (required before exit)
                    string outputPptxPath = "output.pptx";
                    presentation.Save(outputPptxPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported.
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}