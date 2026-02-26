using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Instantiate a new Presentation object
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation to a file
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}