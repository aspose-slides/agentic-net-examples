// -----------------------------------------------------------------------------
// Example: Detect broken media links and remove using C#
//
// Description:
// Demonstrates how to detect broken video and audio media links in a PowerPoint
// presentation and remove the corresponding shapes using C# and Aspose.Slides for
// .NET. The example loads a PPTX file, checks each video and audio frame for an
// embedded source or a valid external file, removes shapes with missing media,
// and saves a cleaned presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Broken, Media, Links,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Clean up presentations by removing video/audio placeholders with missing files.
// - Automate validation of media assets before publishing or distribution.
// - Build .NET tools that ensure PPTX files contain only valid media references.
// - Integrate media integrity checks into larger PowerPoint processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_cleaned.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through slides in reverse order
                for (int slideIdx = presentation.Slides.Count - 1; slideIdx >= 0; slideIdx--)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIdx];

                    // Iterate through shapes in reverse order
                    for (int shapeIdx = slide.Shapes.Count - 1; shapeIdx >= 0; shapeIdx--)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIdx];

                        // Handle video frames
                        if (shape is Aspose.Slides.IVideoFrame videoFrame)
                        {
                            bool hasEmbeddedVideo = videoFrame.EmbeddedVideo != null;
                            string linkPath = videoFrame.LinkPathLong;
                            bool linkExists = !string.IsNullOrEmpty(linkPath) && File.Exists(linkPath);

                            // Remove the shape if the video is neither embedded nor linked to an existing file
                            if (!hasEmbeddedVideo && !linkExists)
                            {
                                slide.Shapes.RemoveAt(shapeIdx);
                            }
                        }
                        // Handle audio frames
                        else if (shape is Aspose.Slides.IAudioFrame audioFrame)
                        {
                            bool isEmbedded = audioFrame.Embedded;
                            string linkPath = audioFrame.LinkPathLong;
                            bool linkExists = !string.IsNullOrEmpty(linkPath) && File.Exists(linkPath);

                            // Remove the shape if the audio is neither embedded nor linked to an existing file
                            if (!isEmbedded && !linkExists)
                            {
                                slide.Shapes.RemoveAt(shapeIdx);
                            }
                        }
                    }
                }

                // Save the cleaned presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptCorruptFileException)
        {
            Console.WriteLine("The presentation file appears to be corrupted.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
