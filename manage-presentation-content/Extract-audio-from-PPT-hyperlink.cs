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
            // Input PPTX file and output audio file paths
            string inputPath = "input.pptx";
            string outputPath = "hyperlinkAudio.mp3";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = null;
            pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide and its first shape
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Get the hyperlink associated with the shape
            Aspose.Slides.IHyperlink link = shape.HyperlinkClick;

            // Extract the audio linked to the hyperlink, if any
            if (link != null && link.Sound != null && link.Sound.BinaryData != null)
            {
                File.WriteAllBytes(outputPath, link.Sound.BinaryData);
                Console.WriteLine("Audio extracted to " + outputPath);
            }
            else
            {
                Console.WriteLine("No audio found in hyperlink.");
            }

            // Save the presentation before exiting
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}