using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get total number of slides
            int slideCount = presentation.Slides.Count;

            // Compare each slide with every other slide
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slideI = presentation.Slides[i];
                for (int j = i + 1; j < slideCount; j++)
                {
                    Aspose.Slides.ISlide slideJ = presentation.Slides[j];
                    bool areEqual = slideI.Equals(slideJ);
                    if (areEqual)
                    {
                        Console.WriteLine($"Slide {i + 1} is equal to Slide {j + 1}");
                    }
                    else
                    {
                        Console.WriteLine($"Slide {i + 1} differs from Slide {j + 1}");
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}