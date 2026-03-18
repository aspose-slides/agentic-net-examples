using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var slideIndex = 2; // zero‑based index of the slide to delete

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                {
                    presentation.Slides.RemoveAt(slideIndex);
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}