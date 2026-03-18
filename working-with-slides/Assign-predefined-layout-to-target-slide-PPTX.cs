using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation that contains the predefined layout
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("source.pptx");

            // Load the target presentation where the layout will be applied
            Aspose.Slides.Presentation targetPresentation = new Aspose.Slides.Presentation("target.pptx");

            // Retrieve a layout slide of a specific type (e.g., Title) from the source presentation
            Aspose.Slides.ILayoutSlide predefinedLayout = sourcePresentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);

            // Assign the retrieved layout to the first slide of the target presentation
            targetPresentation.Slides[0].LayoutSlide = predefinedLayout;

            // Save the modified target presentation
            targetPresentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}