using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the slide at the specified index (e.g., index 0)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example usage: display a message confirming retrieval
        Console.WriteLine("Slide at index 0 has been retrieved.");

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}