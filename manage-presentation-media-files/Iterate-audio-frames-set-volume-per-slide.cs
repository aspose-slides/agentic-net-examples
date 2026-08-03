// -----------------------------------------------------------------------------
// Example: Iterate audio frames set volume per slide using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, iterate through each slide
// and its shapes, identify audio frames and set their volume based on the slide
// index (e.g., increasing by 10 % per slide, capped at 100 %). The modified
// presentation is then saved. This pattern shows the essential steps for
// processing audio media in PPTX files with Aspose.Slides for .NET.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, audio frame, volume, presentation
// processing, slide iteration, media manipulation
//
// Use Cases:
// - Adjust audio volume programmatically across slides.
// - Build automation tools that normalize or customize audio levels in PPTX.
// - Integrate audio handling into .NET applications that generate or modify
//   presentations.
// - Validate and test audio settings before publishing a presentation.
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

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load presentation
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other loading errors
            Console.WriteLine("Error loading presentation: " + ex.Message);
            // Format not supported comment
            // The file format is not supported.
            return;
        }

        // Iterate through slides
        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
            // Iterate through shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.IAudioFrame audioFrame = shape as Aspose.Slides.IAudioFrame;
                if (audioFrame != null)
                {
                    // Set volume based on slide index (e.g., 10% per slide, capped at 100%)
                    float volume = (float)((slideIndex + 1) * 10);
                    if (volume > 100f)
                    {
                        volume = 100f;
                    }
                    audioFrame.VolumeValue = volume;
                }
            }
        }

        try
        {
            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
