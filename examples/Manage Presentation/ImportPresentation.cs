using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Open the HTML file as a stream
            using (FileStream htmlStream = new FileStream("input.html", FileMode.Open, FileAccess.Read))
            {
                // Import slides from the HTML stream
                presentation.Slides.AddFromHtml(htmlStream);
            }

            // Save the presentation to a PPTX file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}