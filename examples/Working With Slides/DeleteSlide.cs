using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";
        // Path to the output presentation
        string outputPath = "output.pptx";
        // Index of the slide to delete (zero-based)
        int slideIndex = 1;

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Remove the slide at the specified index
            presentation.Slides.RemoveAt(slideIndex);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}