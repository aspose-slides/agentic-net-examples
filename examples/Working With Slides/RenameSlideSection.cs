using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first section in the presentation
        Aspose.Slides.ISection section = pres.Sections[0];

        // Rename the section
        section.Name = "Renamed Section";

        // Save the modified presentation
        pres.Save("output.pptx", SaveFormat.Pptx);
    }
}