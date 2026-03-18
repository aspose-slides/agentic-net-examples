using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the slide collection
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Choose the slide to duplicate (e.g., the first slide)
            Aspose.Slides.ISlide sourceSlide = slides[0];

            // Define the index where the cloned slide will be inserted
            int insertIndex = 2;

            // Insert a clone of the source slide at the specified index
            Aspose.Slides.ISlide clonedSlide = slides.InsertClone(insertIndex, sourceSlide);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}