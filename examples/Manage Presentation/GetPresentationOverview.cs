using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Get the number of slides
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Number of slides: " + slideCount);

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            Console.WriteLine("Title: " + docProps.Title);
            Console.WriteLine("Author: " + docProps.Author);
            Console.WriteLine("Created: " + docProps.CreatedTime);

            // Iterate through slides and display their names
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string slideName = slide.Name;
                Console.WriteLine("Slide " + (i + 1) + " name: " + slideName);
            }

            // Save a copy of the presentation
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}