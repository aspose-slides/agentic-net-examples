using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve a blank layout slide
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Get the placeholder manager for the layout slide
        Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;

        // Add a table placeholder with specified coordinates (x, y, width, height)
        Aspose.Slides.IAutoShape tablePlaceholder = placeholderManager.AddTablePlaceholder(20f, 20f, 500f, 200f);

        // Save the presentation
        presentation.Save("TablePlaceholderDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}