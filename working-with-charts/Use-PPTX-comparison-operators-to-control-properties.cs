using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add an additional slide for demonstration
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Iterate through all slides and hide those with even slide numbers
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                // Use comparison operator to evaluate slide number
                if (slide.SlideNumber % 2 == 0)
                {
                    slide.Hidden = true;
                }
            }

            // Save the presentation before exiting
            presentation.Save("ComparisonDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}