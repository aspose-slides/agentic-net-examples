using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPT file
        string inputPath = "input.ppt";
        // Path to save the extracted audio
        string outputAudioPath = "hyperlink_sound.wav";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape on the slide
        Aspose.Slides.IShape shape = slide.Shapes[0];

        // Access the hyperlink associated with the shape (click action)
        Aspose.Slides.IHyperlink hyperlink = shape.HyperlinkClick;

        // Check if the hyperlink has an associated sound
        if (hyperlink != null && hyperlink.Sound != null)
        {
            // Extract the sound data as a byte array
            byte[] audioData = hyperlink.Sound.BinaryData;

            // Save the extracted audio to a file
            File.WriteAllBytes(outputAudioPath, audioData);
        }

        // Save the presentation (even if unchanged) before exiting
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Clean up resources
        presentation.Dispose();
    }
}