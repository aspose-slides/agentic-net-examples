using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the hyperlink associated with the first shape on the slide
        Aspose.Slides.IHyperlink hyperlink = slide.Shapes[0].HyperlinkClick;

        // If the hyperlink has an attached sound, extract it
        if (hyperlink != null && hyperlink.Sound != null)
        {
            // Retrieve the sound data as a byte array
            byte[] audioData = hyperlink.Sound.BinaryData;

            // Save the extracted sound to a file
            File.WriteAllBytes("hyperlink_sound.bin", audioData);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}