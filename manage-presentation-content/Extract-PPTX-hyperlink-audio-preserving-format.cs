using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Presentation presentation = new Presentation("input.pptx");

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape has a hyperlink with an associated sound
                    IHyperlink hyperlink = shape.HyperlinkClick;
                    if (hyperlink != null && hyperlink.Sound != null)
                    {
                        IAudio audio = hyperlink.Sound;
                        byte[] audioData = audio.BinaryData;

                        // Save the extracted audio preserving its original format (using .mp3 as a generic extension)
                        string outputDirectory = Path.Combine("ExtractedAudio");
                        Directory.CreateDirectory(outputDirectory);
                        string outputPath = Path.Combine(outputDirectory, $"audio_slide{slideIndex + 1}_shape{shapeIndex + 1}.mp3");
                        File.WriteAllBytes(outputPath, audioData);
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}