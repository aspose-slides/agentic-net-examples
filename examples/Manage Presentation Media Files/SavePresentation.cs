using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide (presentation has one empty slide by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Save the presentation to PPTX format
        presentation.Save("ModifiedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}