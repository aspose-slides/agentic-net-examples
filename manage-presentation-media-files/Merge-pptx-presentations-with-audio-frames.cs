using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentationsWithAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect three arguments: first input file, second input file, output file
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: MergePresentationsWithAudio <input1.pptx> <input2.pptx> <output.pptx>");
                return;
            }

            string inputPath1 = args[0];
            string inputPath2 = args[1];
            string outputPath = args[2];

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.WriteLine($"File not found: {inputPath1}");
                return;
            }

            if (!File.Exists(inputPath2))
            {
                Console.WriteLine($"File not found: {inputPath2}");
                return;
            }

            try
            {
                // Destination presentation (starts with one empty slide)
                using (Presentation destination = new Presentation())
                {
                    // Mapping from source audio objects to destination audio objects
                    Dictionary<IAudio, IAudio> audioMap = new Dictionary<IAudio, IAudio>();

                    // Process each source presentation
                    string[] sourceFiles = new string[] { inputPath1, inputPath2 };
                    foreach (string sourceFile in sourceFiles)
                    {
                        using (Presentation source = new Presentation(sourceFile))
                        {
                            // Copy audios
                            foreach (IAudio srcAudio in source.Audios)
                            {
                                IAudio destAudio = destination.Audios.AddAudio(srcAudio);
                                audioMap[srcAudio] = destAudio;
                            }

                            // Copy slides
                            foreach (ISlide srcSlide in source.Slides)
                            {
                                // Clone slide into destination
                                ISlide destSlide = destination.Slides.AddClone(srcSlide);

                                // Copy audio frames from the source slide to the cloned slide
                                foreach (IShape shape in srcSlide.Shapes)
                                {
                                    IAudioFrame srcAudioFrame = shape as IAudioFrame;
                                    if (srcAudioFrame != null && srcAudioFrame.EmbeddedAudio != null)
                                    {
                                        IAudio mappedAudio = audioMap[srcAudioFrame.EmbeddedAudio];
                                        IAudioFrame destAudioFrame = destSlide.Shapes.AddAudioFrameEmbedded(
                                            srcAudioFrame.X,
                                            srcAudioFrame.Y,
                                            srcAudioFrame.Width,
                                            srcAudioFrame.Height,
                                            mappedAudio);

                                        // Preserve playback settings
                                        destAudioFrame.PlayAcrossSlides = srcAudioFrame.PlayAcrossSlides;
                                        destAudioFrame.RewindAudio = srcAudioFrame.RewindAudio;
                                        destAudioFrame.Volume = srcAudioFrame.Volume;
                                        destAudioFrame.PlayMode = srcAudioFrame.PlayMode;
                                    }
                                }
                            }
                        }
                    }

                    // Remove the initial empty slide if it still exists
                    if (destination.Slides.Count > 0 && destination.Slides[0].Shapes.Count == 0)
                    {
                        destination.Slides.RemoveAt(0);
                    }

                    // Save the merged presentation
                    destination.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}