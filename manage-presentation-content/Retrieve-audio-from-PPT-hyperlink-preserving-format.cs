using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output audio file path (preserve original format if known)
        string outputPath = "extractedAudio.bin";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        presentation = new Presentation(inputPath);

        // Access the first slide and the first shape on that slide
        ISlide slide = presentation.Slides[0];
        IShape shape = slide.Shapes[0];

        // Retrieve the hyperlink associated with the shape
        IHyperlink hyperlink = shape.HyperlinkClick;

        // Extract the audio linked to the hyperlink, if any
        if (hyperlink != null && hyperlink.Sound != null && hyperlink.Sound.BinaryData != null)
        {
            File.WriteAllBytes(outputPath, hyperlink.Sound.BinaryData);
            Console.WriteLine("Audio extracted to: " + outputPath);
        }
        else
        {
            Console.WriteLine("No audio found in the hyperlink.");
        }

        // Save the presentation (optional, ensures any changes are persisted)
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation before exiting
        presentation.Dispose();
    }
}