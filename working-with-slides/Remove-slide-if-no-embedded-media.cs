// -----------------------------------------------------------------------------
// Example: Remove slide if no embedded media using C#
//
// Description:
// Demonstrates how to remove a slide that does not contain any embedded
// media (video, audio, or OLE objects) using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, checks the first slide for media, removes the
// slide when none is found, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Slide, Embedded, Media,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically clean up presentations by deleting empty or media‑free slides.
// - Build .NET utilities for PowerPoint content validation and transformation.
// - Integrate slide‑removal logic into larger document‑processing pipelines.
// - Ensure presentations meet media requirements before distribution.
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
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            bool hasMedia = false;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IVideoFrame || shape is IAudioFrame || shape is OleObjectFrame)
                {
                    hasMedia = true;
                    break;
                }
            }

            if (!hasMedia)
            {
                pres.Slides.Remove(slide);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            else
            {
                Console.WriteLine("Slide contains embedded media; not removed.");
            }

            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
