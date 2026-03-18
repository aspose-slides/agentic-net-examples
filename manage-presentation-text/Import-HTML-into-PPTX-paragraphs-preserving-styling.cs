using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // HTML content to be imported
                string htmlContent = "<h1>Title</h1><p>This is a <b>bold</b> paragraph with <i>italic</i> text.</p>";

                // Add slides from the HTML content
                Aspose.Slides.ISlide[] addedSlides = presentation.Slides.AddFromHtml(htmlContent);

                // Save the presentation to a PPTX file
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}