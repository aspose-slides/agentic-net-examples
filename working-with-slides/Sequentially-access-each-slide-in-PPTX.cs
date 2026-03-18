using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.ISlideCollection slides = presentation.Slides;
            for (int i = 0; i < slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = slides[i];
                Console.WriteLine("Processing slide number: " + (i + 1));
                // Additional slide processing can be done here
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}