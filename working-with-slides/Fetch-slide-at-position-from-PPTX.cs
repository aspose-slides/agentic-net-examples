using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var index = 0; // zero‑based slide index

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = GetSlideAtIndex(presentation, index);
                Console.WriteLine("Retrieved slide number: " + slide.SlideNumber);

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static Aspose.Slides.ISlide GetSlideAtIndex(Aspose.Slides.Presentation presentation, int index)
    {
        if (index < 0 || index >= presentation.Slides.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return presentation.Slides[index];
    }
}