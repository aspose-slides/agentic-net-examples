using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation to a PPTX file
        presentation.Save("ManagedMediaPresentation.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}