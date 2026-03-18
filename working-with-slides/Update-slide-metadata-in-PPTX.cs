using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set the slide title (Name property)
            slide.Name = "Updated Slide Title";

            // Change the slide's layout to the first layout slide
            Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];
            slide.LayoutSlide = layout;

            // Update document metadata
            presentation.DocumentProperties.Title = "Updated Presentation Title";
            presentation.DocumentProperties.Author = "Author Name";

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}