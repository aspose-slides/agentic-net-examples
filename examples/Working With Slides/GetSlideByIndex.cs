using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the slide at zero‑based index 0
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example operation: output a message indicating the slide was accessed
        Console.WriteLine("Slide at index 0 has been accessed.");

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}