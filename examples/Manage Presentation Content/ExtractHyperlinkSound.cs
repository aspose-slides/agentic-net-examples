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
        // Path to the output PPT file (can be the same as input if no changes)
        string outputPath = "output.ppt";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape on the slide
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Access the hyperlink associated with the shape (click action)
            Aspose.Slides.IHyperlink link = shape.HyperlinkClick;

            // Check if the hyperlink has an associated sound
            if (link != null && link.Sound != null)
            {
                // Extract the sound data as a byte array
                byte[] audioData = link.Sound.BinaryData;

                // Example: write the extracted sound to a file
                File.WriteAllBytes("hyperlink_sound.wav", audioData);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}