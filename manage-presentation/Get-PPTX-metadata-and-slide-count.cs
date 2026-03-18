using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "input.pptx";
            using (Presentation presentation = new Presentation(filePath))
            {
                IDocumentProperties docProps = presentation.DocumentProperties;
                Console.WriteLine("Title: " + docProps.Title);
                Console.WriteLine("Author: " + docProps.Author);
                Console.WriteLine("Created: " + docProps.CreatedTime);
                Console.WriteLine("Slide Count: " + docProps.Slides);
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}