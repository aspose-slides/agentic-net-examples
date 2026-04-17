using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output file path
        string outputPath = "TablePlaceholderDemo.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get blank layout slide
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Get placeholder manager
        Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;

        // Add placeholders (including table placeholder)
        placeholderManager.AddContentPlaceholder(10, 10, 300, 200);
        placeholderManager.AddVerticalTextPlaceholder(350, 10, 200, 300);
        placeholderManager.AddChartPlaceholder(10, 350, 300, 300);
        placeholderManager.AddTablePlaceholder(350, 350, 300, 200);

        // Add a new empty slide based on the layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}