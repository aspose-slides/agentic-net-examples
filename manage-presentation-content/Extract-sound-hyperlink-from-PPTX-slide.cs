using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExtractHyperlinkFromSound
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputAudioPath = "extractedAudio.mp3";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.IHyperlink hyperlink = shape.HyperlinkClick;

                if (hyperlink != null)
                {
                    Console.WriteLine("Hyperlink External URL: " + hyperlink.ExternalUrl);
                    Console.WriteLine("Hyperlink Tooltip: " + hyperlink.Tooltip);

                    if (hyperlink.Sound != null && hyperlink.Sound.BinaryData != null)
                    {
                        File.WriteAllBytes(outputAudioPath, hyperlink.Sound.BinaryData);
                        Console.WriteLine("Audio extracted to: " + outputAudioPath);
                    }
                    else
                    {
                        Console.WriteLine("No sound associated with the hyperlink.");
                    }
                }
                else
                {
                    Console.WriteLine("No hyperlink assigned to the shape.");
                }

                // Save the presentation (no modifications) to satisfy save requirement
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
}