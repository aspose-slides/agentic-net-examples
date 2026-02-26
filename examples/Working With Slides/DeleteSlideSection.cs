using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Presentation presentation = new Presentation("input.pptx");

        // Access the sections collection
        ISectionCollection sections = presentation.Sections;

        // Ensure there is at least one section to remove
        if (sections.Count > 0)
        {
            // Get the first section
            ISection section = sections[0];

            // Remove the section along with its slides
            sections.RemoveSectionWithSlides(section);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}