using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve the layout slide from the first (default) slide
        Aspose.Slides.ILayoutSlide layout = presentation.Slides[0].LayoutSlide;

        // Add a large number of empty slides to demonstrate memory‑efficient handling
        for (int i = 0; i < 1000; i++)
        {
            presentation.Slides.AddEmptySlide(layout);
        }

        // Save the presentation in PPTX format before exiting
        presentation.Save("LargePresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}