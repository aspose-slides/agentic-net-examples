// -----------------------------------------------------------------------------
// Example: Remove slide if no embedded media using C#
// 
// Description:
// Demonstrates how to remove a slide that does not contain any embedded media
// such as video, audio, or OLE objects using C# and Aspose.Slides for .NET.
// The program creates a sample PPTX if none exists, checks the first slide for
// media, removes the slide when none is found, and saves the modified file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove slide, Embedded media, Presentation processing
// 
// Use Cases:
// - Clean up presentations by deleting slides without media.
// - Validate PowerPoint files before publishing.
// - Automate slide management in document processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Ensure sample input exists
        if (!File.Exists(inputPath))
        {
            try
            {
                using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                {
                    // Add a blank slide (no media)
                    samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input: " + ex.Message);
                Environment.Exit(1);
            }
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            Environment.Exit(1);
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("Presentation contains no slides.");
                    Environment.Exit(1);
                }

                Aspose.Slides.ISlide slide = pres.Slides[0];
                bool hasMedia = false;

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IVideoFrame || shape is Aspose.Slides.IAudioFrame || shape is Aspose.Slides.IOleObjectFrame)
                    {
                        hasMedia = true;
                        break;
                    }
                }

                if (!hasMedia)
                {
                    pres.Slides.RemoveAt(0);
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Slide without media removed and presentation saved to " + outputPath);
                }
                else
                {
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Slide contains embedded media; no removal performed. Presentation saved to " + outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Format not supported or other error
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
