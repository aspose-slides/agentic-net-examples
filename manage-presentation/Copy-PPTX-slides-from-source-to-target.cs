using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("source.pptx");
            // Create a new target presentation
            Aspose.Slides.Presentation targetPresentation = new Aspose.Slides.Presentation();

            // Copy each slide from source to target
            for (int index = 0; index < sourcePresentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[index];
                targetPresentation.Slides.AddClone(sourceSlide);
            }

            // Save the target presentation
            targetPresentation.Save("target.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}