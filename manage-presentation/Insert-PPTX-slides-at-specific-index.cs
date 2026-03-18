using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Position where the new slide will be inserted (e.g., after the first slide)
            int insertIndex = 1;

            // Use the first layout slide as a template for the new empty slide
            Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];

            // Insert a new empty slide at the specified position
            Aspose.Slides.ISlide newSlide = presentation.Slides.InsertEmptySlide(insertIndex, layout);

            // Save the updated presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}