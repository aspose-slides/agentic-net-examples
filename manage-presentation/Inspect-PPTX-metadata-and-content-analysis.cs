using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string sourcePath = "sample.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            Console.WriteLine("Title: " + docProps.Title);
            Console.WriteLine("Author: " + docProps.Author);
            Console.WriteLine("Created: " + docProps.CreatedTime);
            Console.WriteLine("Total Slides: " + presentation.Slides.Count);

            // Access sections
            Aspose.Slides.ISectionCollection sections = presentation.Sections;
            Console.WriteLine("Sections Count: " + sections.Count);
            for (int i = 0; i < sections.Count; i++)
            {
                Aspose.Slides.ISection section = sections[i];
                Console.WriteLine($"Section {i}: {section.Name}");

                // First slide of the section
                Aspose.Slides.ISlide firstSlide = section.StartedFromSlide;
                if (firstSlide != null)
                {
                    Console.WriteLine($"  Starts at Slide Number: {firstSlide.SlideNumber}");
                }

                // List all slides belonging to this section
                Aspose.Slides.ISectionSlideCollection slideList = section.GetSlidesListOfSection();
                foreach (Aspose.Slides.ISlide slide in slideList)
                {
                    Console.WriteLine($"    Slide #{slide.SlideNumber}");
                }
            }

            // Save the (potentially modified) presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}