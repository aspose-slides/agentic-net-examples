// -----------------------------------------------------------------------------
// Example: Clone slide to section and set name using C#
//
// Description:
// Demonstrates how to clone a slide into a new section and set the section's
// name using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a shape, defines an original section, creates an empty section, clones
// the first slide into that section, renames the section, and saves the file.
// This pattern can be used to programmatically reorganize slides within
// PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Section, Name,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate moving or copying slides into specific sections.
// - Build tools that reorganize PPTX content for review or publishing.
// - Generate presentations with dynamically created sections.
// - Validate slide organization workflows in .NET applications.
// -----------------------------------------------------------------------------

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
