using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first master slide in the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a custom layout slide to the master slide collection
        Aspose.Slides.ILayoutSlide customLayout = masterSlide.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

        // Add a new empty slide that uses the custom layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

        // Example: apply the custom layout to an existing slide (optional)
        // Aspose.Slides.ISlide existingSlide = presentation.Slides[0];
        // existingSlide.LayoutSlide = customLayout;

        // Save the presentation to a file
        presentation.Save("CustomLayoutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}