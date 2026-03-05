using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[index];

            // Export the slide (which may contain charts) as an SVG file
            using (FileStream fileStream = new FileStream($"slide_{index + 1}.svg", FileMode.Create, FileAccess.Write))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (required before exiting)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}