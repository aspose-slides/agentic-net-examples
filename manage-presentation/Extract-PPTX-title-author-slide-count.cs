using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(filePath))
            {
                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
                var title = documentProperties.Title;
                var author = documentProperties.Author;
                var slideCount = presentation.Slides.Count;

                Console.WriteLine("Title: " + title);
                Console.WriteLine("Author: " + author);
                Console.WriteLine("Total Slides: " + slideCount);

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}