using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation from file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}