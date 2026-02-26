using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string __INPUT_PATH__ = "input.ppt";
        string __OUTPUT_PATH__ = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation __PRESENTATION__ = new Aspose.Slides.Presentation(__INPUT_PATH__);

        // Remove all hyperlinks from the presentation
        __PRESENTATION__.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the modified presentation in PPTX format
        __PRESENTATION__.Save(__OUTPUT_PATH__, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        __PRESENTATION__.Dispose();
    }
}