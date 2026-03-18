using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Get layout of the first slide
                Aspose.Slides.ILayoutSlide layoutSlide = presentation.Slides[0].LayoutSlide;

                // Insert a new empty slide using the same layout to preserve formatting
                Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

                // Save the updated presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}