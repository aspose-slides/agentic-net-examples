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
                Aspose.Slides.IBaseSlide slideA = slides[i];
                for (int j = i + 1; j < slides.Count; j++)
                {
                    Aspose.Slides.IBaseSlide slideB = slides[j];
                    bool areEqual = slideA.Equals(slideB);
                    if (!areEqual)
                    {
                        Console.WriteLine($"Slide {i + 1} differs from Slide {j + 1}");
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}