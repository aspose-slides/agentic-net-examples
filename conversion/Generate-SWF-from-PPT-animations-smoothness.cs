// -----------------------------------------------------------------------------
// Example: Generate SWF from PPT animations smoothness using C#
//
// Description:
// Demonstrates how to generate both compressed and uncompressed SWF files from a
// PowerPoint presentation and optionally extract animation frames for visual
// comparison using Aspose.Slides for .NET. The example shows the required
// presentation-processing steps, SWF generation options, and frame extraction
// logic in a standalone console application. Developers can use this pattern to
// automate SWF creation, evaluate animation smoothness, and integrate presentation
// workflows into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SWF, Generate, Animations,
// Smoothness, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of compressed and uncompressed SWF from PPT animations.
// - Compare animation smoothness between compressed and uncompressed SWF outputs.
// - Extract animation frames for visual analysis or testing.
// - Integrate PowerPoint to SWF conversion into .NET tools and services.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

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
