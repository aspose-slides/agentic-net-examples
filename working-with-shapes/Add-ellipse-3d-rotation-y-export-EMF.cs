using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        // Path for the EMF file
        string emfFilePath = Path.Combine(outputDirectory, "Ellipse.emf");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Apply a 3‑D rotation around the Y axis using the shape's camera
        // (Set Y rotation to 30 degrees)
        ellipse.ThreeDFormat.Camera.SetRotation(0, 30, 0);

        // Export the slide as an EMF file
        using (FileStream emfStream = new FileStream(emfFilePath, FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsEmf(emfStream);
        }

        // Save the presentation (optional, demonstrates saving before exit)
        string pptxFilePath = Path.Combine(outputDirectory, "Ellipse.pptx");
        presentation.Save(pptxFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}