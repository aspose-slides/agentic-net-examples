using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path where the rendered JPEG image will be saved
        string jpegPath = "slide0.jpg";
        // Path to save the presentation (required by authoring rules)
        string savedPath = "saved_output.pptx";

        // Load the presentation from the specified file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Render the first slide (including any 3‑D effects) to an image
        Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);

        // Save the rendered slide as a JPEG image
        slideImage.Save(jpegPath, Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation before exiting the application
        presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release all resources used by the presentation
        presentation.Dispose();
    }
}