using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the sections collection from the presentation
        Aspose.Slides.ISectionCollection sections = presentation.Sections;

        // Check if there is at least one section to remove
        if (sections.Count > 0)
        {
            // Retrieve the first section (or any specific section by index)
            Aspose.Slides.ISection sectionToRemove = sections[0];

            // Remove the section together with all slides it contains
            sections.RemoveSectionWithSlides(sectionToRemove);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}