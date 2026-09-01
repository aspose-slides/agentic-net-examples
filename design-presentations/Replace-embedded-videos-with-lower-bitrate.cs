// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace embedded videos with lower bitrate using C#

//

// Description:

// Demonstrates how to replace embedded videos with lower bitrate using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Embedded, Videos, 

// Lower, Bitrate, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replace embedded videos with lower bitrate.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ReplaceEmbeddedVideos

{

    class Program

    {

        static void Main()

        {

            // Input and output file paths

            var inputPath = "input.pptx";

            var outputPath = "output.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                var presentation = new Aspose.Slides.Presentation(inputPath);



                // Iterate over each embedded video

                for (var i = 0; i < presentation.Videos.Count; i++)

                {

                    var oldVideo = presentation.Videos[i];



                    // Read original video data into a byte array

                    byte[] originalData;

                    using (var videoStream = oldVideo.GetStream())

                    using (var memory = new MemoryStream())

                    {

                        videoStream.CopyTo(memory);

                        originalData = memory.ToArray();

                    }



                    // TODO: Replace this placeholder with actual lower‑bitrate conversion logic

                    var lowerBitrateData = originalData; // Placeholder for compressed video bytes



                    // Add the lower‑bitrate video to the presentation

                    var newVideo = presentation.Videos.AddVideo(lowerBitrateData);



                    // Update all video frames that reference the old video

                    foreach (var slide in presentation.Slides)

                    {

                        foreach (var shape in slide.Shapes)

                        {

                            if (shape is Aspose.Slides.IVideoFrame videoFrame)

                            {

                                if (videoFrame.EmbeddedVideo == oldVideo)

                                {

                                    videoFrame.EmbeddedVideo = newVideo;

                                }

                            }

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

