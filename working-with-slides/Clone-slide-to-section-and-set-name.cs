using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 50, 300, 100);

        // Add an initial section starting from the first slide
        Aspose.Slides.ISection originalSection = presentation.Sections.AddSection("Original Section", presentation.Slides[0]);

        // Append an empty section for the cloned slide
        Aspose.Slides.ISection clonedSection = presentation.Sections.AppendEmptySection("Cloned Slides Section");

        // Clone the first slide into the new section
        presentation.Slides.AddClone(presentation.Slides[0], clonedSection);

        // Set a descriptive name for the cloned section
        clonedSection.Name = "Cloned Slides for Review";

        // Save the presentation
        presentation.Save("ClonedSlideInSection.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}