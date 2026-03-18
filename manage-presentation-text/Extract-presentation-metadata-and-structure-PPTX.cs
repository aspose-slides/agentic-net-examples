using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "sample.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                // Document properties
                Aspose.Slides.IDocumentProperties props = presentation.DocumentProperties;
                Console.WriteLine("Title: " + props.Title);
                Console.WriteLine("Author: " + props.Author);
                Console.WriteLine("Created: " + props.CreatedTime);
                Console.WriteLine("Subject: " + props.Subject);

                // Structural information
                int slideCount = presentation.Slides.Count;
                Console.WriteLine("Slide count: " + slideCount);

                int masterCount = presentation.Masters.Count;
                Console.WriteLine("Master slide count: " + masterCount);

                int layoutCount = presentation.LayoutSlides.Count;
                Console.WriteLine("Layout slide count: " + layoutCount);

                int sectionCount = presentation.Sections.Count;
                Console.WriteLine("Section count: " + sectionCount);

                // List slide IDs
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Console.WriteLine($"Slide {i + 1} ID: {slide.SlideId}");
                }

                // Save presentation before exit
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}