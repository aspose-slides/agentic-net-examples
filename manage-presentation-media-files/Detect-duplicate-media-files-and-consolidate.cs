using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MediaConsolidator
{
    class Program
    {
        static void Main()
        {
            // Input presentation files
            var inputFiles = new[] { "Presentation1.pptx", "Presentation2.pptx", "Presentation3.pptx" };
            var existingFiles = new List<string>();
            foreach (var file in inputFiles)
            {
                if (File.Exists(file))
                {
                    existingFiles.Add(file);
                }
                else
                {
                    Console.WriteLine($"File not found: {file}");
                }
            }

            if (existingFiles.Count == 0)
            {
                Console.WriteLine("No valid input files. Exiting.");
                return;
            }

            // Dictionary to store unique media hashes
            var videoHashMap = new Dictionary<string, IVideo>();
            var audioHashMap = new Dictionary<string, IAudio>();

            // Presentation to hold consolidated media
            var sharedPresentation = new Presentation();

            try
            {
                foreach (var path in existingFiles)
                {
                    try
                    {
                        using var pres = new Presentation(path);
                        // Process videos
                        foreach (var video in pres.Videos)
                        {
                            using var videoStream = video.GetStream();
                            using var sha256 = SHA256.Create();
                            var hashBytes = sha256.ComputeHash(videoStream);
                            var hashString = Convert.ToBase64String(hashBytes);
                            if (!videoHashMap.ContainsKey(hashString))
                            {
                                var addedVideo = sharedPresentation.Videos.AddVideo(video);
                                videoHashMap[hashString] = addedVideo;
                            }
                        }

                        // Process audios
                        foreach (var audio in pres.Audios)
                        {
                            // Assuming IAudio has BinaryData property; if not, adjust accordingly
                            var audioData = audio.BinaryData;
                            using var sha256 = SHA256.Create();
                            var hashBytes = sha256.ComputeHash(audioData);
                            var hashString = Convert.ToBase64String(hashBytes);
                            if (!audioHashMap.ContainsKey(hashString))
                            {
                                var addedAudio = sharedPresentation.Audios.AddAudio(audio);
                                audioHashMap[hashString] = addedAudio;
                            }
                        }
                    }
                    catch (Exception ex) when (ex is NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine($"Unsupported format for file: {path}");
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        Console.WriteLine($"IO error processing file: {path} - {ex.Message}");
                    }
                }

                // Save consolidated media presentation
                var outputPath = "ConsolidatedMedia.pptx";
                sharedPresentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Consolidated media saved to {outputPath}");
            }
            finally
            {
                sharedPresentation.Dispose();
            }
        }
    }
}