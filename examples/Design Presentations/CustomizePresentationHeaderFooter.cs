using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom text for all header placeholders in the presentation
        presentation.HeaderFooterManager.SetAllHeadersText("Custom Header");

        // Set custom text for all footer placeholders in the presentation
        presentation.HeaderFooterManager.SetAllFootersText("Custom Footer");

        // Save the presentation to a file
        presentation.Save("CustomHeaderFooter.pptx", SaveFormat.Pptx);
    }
}