using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source HTML file
        string htmlFilePath = "input.html";

        // Path where the resulting PowerPoint file will be saved
        string outputFilePath = "output.pptx";

        // Create a new presentation instance
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Open the HTML file as a stream
            using (FileStream htmlStream = File.OpenRead(htmlFilePath))
            {
                // Import slides from the HTML stream and add them to the presentation
                presentation.Slides.AddFromHtml(htmlStream);
            }

            // Save the presentation to a PPTX file
            presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}