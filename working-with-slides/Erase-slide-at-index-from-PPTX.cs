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
            var slideIndex = 2; // zero‑based index of the slide to remove

            using (var presentation = new Presentation(inputPath))
            {
                if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                {
                    presentation.Slides.RemoveAt(slideIndex);
                }
                else
                {
                    Console.WriteLine("Invalid slide index.");
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Slide removed and presentation saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}