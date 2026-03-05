using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the slide at zero‑based index 0
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example usage: retrieve the index of the accessed slide (optional)
        int index = presentation.Slides.IndexOf(slide);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}