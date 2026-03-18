using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Define the range of slides to duplicate (0‑based indices)
                int startIndex = 0;
                int endIndex = 2; // inclusive

                for (int i = startIndex; i <= endIndex; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = presentation.Slides[i];
                    // Clone the slide and add it to the end of the collection
                    presentation.Slides.AddClone(sourceSlide);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}