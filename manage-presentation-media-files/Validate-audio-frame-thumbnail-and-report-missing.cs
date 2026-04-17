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
                bool anyMissing = false;

                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        IAudioFrame audioFrame = shape as IAudioFrame;
                        if (audioFrame != null)
                        {
                            // Check if the audio frame has a thumbnail image assigned
                            IPPImage thumbnail = audioFrame.PictureFormat.Picture.Image;
                            if (thumbnail == null)
                            {
                                anyMissing = true;
                                Console.WriteLine("Audio frame on slide " + slide.SlideNumber + " is missing a thumbnail.");
                            }
                        }
                    }
                }

                if (!anyMissing)
                {
                    Console.WriteLine("All audio frames have thumbnails.");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}