using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output paths
        string inputPath = "input.pptx";
        string outputAudioPath = "hyperlink_sound.mp3";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Extract hyperlink sound
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.IHyperlink link = shape.HyperlinkClick;

        if (link != null && link.Sound != null && link.Sound.BinaryData != null)
        {
            try
            {
                File.WriteAllBytes(outputAudioPath, link.Sound.BinaryData);
                Console.WriteLine("Hyperlink sound extracted to " + outputAudioPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving audio file: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("No sound associated with the hyperlink.");
        }

        // Save presentation before exit
        try
        {
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose presentation
        if (pres != null)
        {
            pres.Dispose();
        }
    }
}