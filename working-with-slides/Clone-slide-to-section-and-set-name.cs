using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation if input does not exist
                presentation = new Aspose.Slides.Presentation();
            }

            // Add a rectangle shape to the first slide
            presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

            // Add an initial section starting from the first slide
            Aspose.Slides.ISection initialSection = presentation.Sections.AddSection("Initial Section", presentation.Slides[0]);

            // Append an empty section that will hold the cloned slide
            Aspose.Slides.ISection clonedSection = presentation.Sections.AppendEmptySection("Cloned Slides Section");

            // Clone the first slide into the newly created section
            presentation.Slides.AddClone(presentation.Slides[0], clonedSection);

            // Set the section name to describe its purpose
            clonedSection.Name = "Purpose: Cloned Slide Section";

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}