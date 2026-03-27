using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractAudioFromHyperlink
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputAudioPath = "extractedAudio.mp3";
            string outputPresentationPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide and first shape
            ISlide slide = pres.Slides[0];
            IShape shape = slide.Shapes[0];

            // Get the hyperlink associated with the shape
            IHyperlink link = shape.HyperlinkClick;

            // Extract the audio linked to the hyperlink, if present
            if (link != null && link.Sound != null && link.Sound.BinaryData != null)
            {
                File.WriteAllBytes(outputAudioPath, link.Sound.BinaryData);
                Console.WriteLine("Audio extracted to: " + outputAudioPath);
            }
            else
            {
                Console.WriteLine("No audio linked to the hyperlink.");
            }

            // Save the (unchanged) presentation before exiting
            pres.Save(outputPresentationPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}