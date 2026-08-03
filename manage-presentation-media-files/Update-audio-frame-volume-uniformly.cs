// -----------------------------------------------------------------------------
// Example: Update audio frame volume uniformly using C#
//
// Description:
// Demonstrates how to set a uniform volume level for all audio frames in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, iterates through each slide and shape, updates the
// VolumeValue property of any IAudioFrame found, and saves the modified
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio Frame, Volume, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Standardize audio playback volume across all slides.
// - Create automated tools for adjusting audio settings in presentations.
// - Prepare presentations for consistent audio experience before distribution.
// - Integrate audio volume normalization into .NET based PPTX workflows.
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
        string outputPath = "output.pptx";
        // Desired uniform volume in percent
        float uniformVolume = 85f;

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and shapes
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.IAudioFrame audioFrame = shape as Aspose.Slides.IAudioFrame;
                    if (audioFrame != null)
                    {
                        // Set uniform volume
                        audioFrame.VolumeValue = uniformVolume;
                    }
                }
            }

            // Save the updated presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
