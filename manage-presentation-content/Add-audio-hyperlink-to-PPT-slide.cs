using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesHyperlinkAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input audio file path and output presentation path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AsposeSlidesHyperlinkAudio <audioFilePath> <outputPptxPath>");
                return;
            }

            string audioFilePath = args[0];
            string outputPptxPath = args[1];

            // Verify that the audio file exists
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file does not exist: " + audioFilePath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to act as the hyperlink target
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150f, 150f, 200f, 50f);

            // Add the audio to the presentation's audio collection
            IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioFilePath));

            // Create a hyperlink for the shape (empty URL) and assign the audio to it
            IHyperlink hyperlink = new Hyperlink("");
            hyperlink.Sound = audio;
            shape.HyperlinkClick = hyperlink;

            // Save the presentation
            pres.Save(outputPptxPath, SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}