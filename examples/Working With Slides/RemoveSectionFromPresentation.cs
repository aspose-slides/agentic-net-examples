using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Ensure there is at least one section to remove
        if (pres.Sections.Count > 0)
        {
            // Retrieve the first section
            Aspose.Slides.ISection section = pres.Sections[0];

            // Remove the section (slides will be merged into the previous section)
            pres.Sections.RemoveSection(section);
        }

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}