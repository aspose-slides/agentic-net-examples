// -----------------------------------------------------------------------------
// Example: Report slide media type size and encoding using C#
//
// Description:
// Demonstrates how to enumerate and report the size, type, and content encoding
// of image, audio, and video media files embedded in a PowerPoint presentation
// using C# and Aspose.Slides for .NET. The example loads an existing PPTX file,
// iterates through its media collections, outputs details to the console, and
// saves the presentation unchanged.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Report, Slide, Media, Type,
// Size, Encoding, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of media metadata from PowerPoint files.
// - Build C# utilities for validating embedded media in presentations.
// - Integrate media reporting into .NET applications that process PPTX files.
// - Ensure media compliance before publishing or further transformation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                Console.WriteLine("Images:");
                foreach (IPPImage img in pres.Images)
                {
                    string type = "Image";
                    long size = img.BinaryData.Length;
                    string format = img.ContentType;
                    Console.WriteLine($"Type: {type}, Size: {size} bytes, Format: {format}");
                }

                Console.WriteLine("Audios:");
                foreach (IAudio audio in pres.Audios)
                {
                    string type = "Audio";
                    long size = audio.BinaryData.Length;
                    string format = audio.ContentType;
                    Console.WriteLine($"Type: {type}, Size: {size} bytes, Format: {format}");
                }

                Console.WriteLine("Videos:");
                foreach (IVideo video in pres.Videos)
                {
                    string type = "Video";
                    long size = video.BinaryData.Length;
                    string format = video.ContentType;
                    Console.WriteLine($"Type: {type}, Size: {size} bytes, Format: {format}");
                }

                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
