using System;

class Program
{
    static void Main()
    {
        // Load the existing PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Ensure there is at least one section to remove
        if (presentation.Sections.Count > 0)
        {
            // Get the first section
            Aspose.Slides.ISection section = presentation.Sections[0];

            // Remove the section along with its slides
            presentation.Sections.RemoveSectionWithSlides(section);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}