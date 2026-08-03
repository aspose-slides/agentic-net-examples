// -----------------------------------------------------------------------------
// Example: Validate video frame codec and report missing using C#
//
// Description:
// Demonstrates how to validate video frame codec and report missing using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Video, Frame, Codec, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate video frame codec and report missing.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoCodecValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "validated_output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // List of supported video MIME types
            string[] supportedCodecs = new string[] { "video/mp4", "video/avi", "video/mov" };

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);
                try
                {
                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a video frame
                            if (shape is IVideoFrame)
                            {
                                IVideoFrame videoFrame = (IVideoFrame)shape;
                                IVideo embeddedVideo = videoFrame.EmbeddedVideo;
                                if (embeddedVideo != null)
                                {
                                    string contentType = embeddedVideo.ContentType;
                                    bool isSupported = false;
                                    foreach (string codec in supportedCodecs)
                                    {
                                        if (string.Equals(contentType, codec, StringComparison.OrdinalIgnoreCase))
                                        {
                                            isSupported = true;
                                            break;
                                        }
                                    }

                                    if (!isSupported)
                                    {
                                        Console.WriteLine("Unsupported codec found in slide {0}, shape {1}: {2}",
                                            slide.SlideNumber, videoFrame.Name, contentType);
                                    }
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                finally
                {
                    // Ensure resources are released
                    presentation.Dispose();
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported file format or other loading errors
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported format, it will be reported here.
            }
        }
    }
}
