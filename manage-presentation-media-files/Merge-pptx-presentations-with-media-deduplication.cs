// -----------------------------------------------------------------------------
// Example: Merge pptx presentations with media deduplication using C#
//
// Description:
// Demonstrates how to merge two PPTX presentations into a single file while
// deduplicating embedded audio and video media using Aspose.Slides for .NET.
// The example clones slides and masters, tracks media by SHA‑256 hash, and
// saves the combined presentation as a new PPTX file.
//
// Keywords:
// C#, Aspose.Slides for .NET, PPTX, Merge, Media deduplication, Audio, Video,
// Presentation processing, PowerPoint automation
//
// Use Cases:
// - Combine multiple PowerPoint files into one while avoiding duplicate media.
// - Build .NET tools that consolidate presentations with efficient media handling.
// - Automate preparation of slide decks for distribution or publishing.
// - Ensure minimal file size by reusing identical audio/video assets.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file paths
            string sourcePath1 = "Source1.pptx";
            string sourcePath2 = "Source2.pptx";
            string outputPath = "MergedOutput.pptx";

            // Verify input files exist
            if (!File.Exists(sourcePath1))
            {
                Console.WriteLine("Source file 1 does not exist.");
                return;
            }
            if (!File.Exists(sourcePath2))
            {
                Console.WriteLine("Source file 2 does not exist.");
                return;
            }

            // Destination presentation
            Presentation destPres = new Presentation();

            // Keep track of already added media to avoid duplication
            Dictionary<string, IAudio> audioMap = new Dictionary<string, IAudio>();
            Dictionary<string, IVideo> videoMap = new Dictionary<string, IVideo>();

            // Process each source presentation
            string[] sourceFiles = new string[] { sourcePath1, sourcePath2 };
            foreach (string srcFile in sourceFiles)
            {
                try
                {
                    using (Presentation srcPres = new Presentation(srcFile))
                    {
                        // Clone slides with their masters
                        for (int i = 0; i < srcPres.Slides.Count; i++)
                        {
                            ISlide sourceSlide = srcPres.Slides[i];
                            IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                            IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                            destPres.Slides.AddClone(sourceSlide, destMaster, true);
                        }

                        // Copy audios without duplication
                        for (int i = 0; i < srcPres.Audios.Count; i++)
                        {
                            IAudio srcAudio = srcPres.Audios[i];
                            // Use hash of audio data as key
                            using (MemoryStream ms = new MemoryStream(srcAudio.BinaryData))
                            {
                                using (SHA256 sha = SHA256.Create())
                                {
                                    byte[] hash = sha.ComputeHash(ms);
                                    string hashString = Convert.ToBase64String(hash);
                                    if (!audioMap.ContainsKey(hashString))
                                    {
                                        IAudio addedAudio = destPres.Audios.AddAudio(srcAudio);
                                        audioMap.Add(hashString, addedAudio);
                                    }
                                }
                            }
                        }

                        // Copy videos without duplication
                        for (int i = 0; i < srcPres.Videos.Count; i++)
                        {
                            IVideo srcVideo = srcPres.Videos[i];
                            using (MemoryStream ms = new MemoryStream(srcVideo.BinaryData))
                            {
                                using (SHA256 sha = SHA256.Create())
                                {
                                    byte[] hash = sha.ComputeHash(ms);
                                    string hashString = Convert.ToBase64String(hash);
                                    if (!videoMap.ContainsKey(hashString))
                                    {
                                        IVideo addedVideo = destPres.Videos.AddVideo(srcVideo);
                                        videoMap.Add(hashString, addedVideo);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    Console.WriteLine($"Error processing file '{srcFile}': {ex.Message}");
                }
            }

            // Save the merged presentation
            try
            {
                destPres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save merged presentation: {ex.Message}");
            }
            finally
            {
                destPres.Dispose();
            }
        }
    }
}
