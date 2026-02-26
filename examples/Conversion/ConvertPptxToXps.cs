using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Save the presentation to XPS format
            pres.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}