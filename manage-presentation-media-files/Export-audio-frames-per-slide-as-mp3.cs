using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through each shape on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        IAudioFrame audioFrame = shape as IAudioFrame;

                        // Check if the shape is an audio frame with embedded audio
                        if (audioFrame != null && audioFrame.EmbeddedAudio != null && audioFrame.EmbeddedAudio.BinaryData != null)
                        {
                            // Export the audio as an MP3 file named after the slide number
                            string outputFile = $"slide_{slideIndex + 1}.mp3";
                            File.WriteAllBytes(outputFile, audioFrame.EmbeddedAudio.BinaryData);
                        }
                    }
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}