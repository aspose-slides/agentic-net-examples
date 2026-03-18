using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Ensure there is at least one slide to start a section
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Add a new section starting from the first slide
            Aspose.Slides.ISection newSection = presentation.Sections.AddSection("New Section", firstSlide);

            // Rename the first existing section if it exists
            if (presentation.Sections.Count > 0)
            {
                Aspose.Slides.ISection firstSection = presentation.Sections[0];
                firstSection.Name = "Renamed Section";
            }

            // Move the newly added section to the beginning of the collection
            presentation.Sections.ReorderSectionWithSlides(newSection, 0);

            // Modify a custom document property using the indexer
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            docProps["Reviewed"] = true;

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}