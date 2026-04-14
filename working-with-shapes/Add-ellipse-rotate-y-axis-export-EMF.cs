using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and files
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        string pptxPath = Path.Combine(outputDir, "result.pptx");
        string emfPath = Path.Combine(outputDir, "slide.emf");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Apply a 3‑D rotation around the Y axis (using camera rotation)
        ellipse.ThreeDFormat.Camera.SetRotation(0, 30, 0); // 30 degrees around Y

        // Save the presentation (required before exit)
        presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the slide as EMF
        try
        {
            using (FileStream emfStream = new FileStream(emfPath, FileMode.Create, FileAccess.Write))
            {
                slide.WriteAsEmf(emfStream);
            }
        }
        catch (Exception ex)
        {
            // Handle possible export errors (e.g., unsupported format)
            Console.WriteLine("Error exporting EMF: " + ex.Message);
        }
    }
}