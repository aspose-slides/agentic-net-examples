using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SoundHyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the audio file and the output presentation
            string audioPath = "sample.mp3";
            string outputPath = "output.pptx";

            // Verify that the audio file exists
            if (!File.Exists(audioPath))
            {
                Console.WriteLine("Audio file not found: " + audioPath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to act as the clickable object
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 50f);

            // Add the audio file to the presentation's audio collection
            IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

            // Create a hyperlink (can point to any URL; the sound will be played on click)
            Hyperlink hyperlink = new Hyperlink("https://example.com");

            // Assign the audio to the hyperlink's Sound property
            hyperlink.Sound = audio;

            // Attach the hyperlink to the shape
            shape.HyperlinkClick = hyperlink;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}