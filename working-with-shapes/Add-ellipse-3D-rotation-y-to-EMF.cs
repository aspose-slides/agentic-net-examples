using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputDir = "Output";
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);
        string emfPath = System.IO.Path.Combine(outputDir, "ellipse.emf");
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                var slide = presentation.Slides[0];
                var ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 150);
                // Apply 3‑D rotation around Y axis via camera rotation
                ellipse.ThreeDFormat.Camera.SetRotation(0, 45, 0);
                using (var fs = new System.IO.FileStream(emfPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    slide.WriteAsEmf(fs);
                }
                // Save the presentation before exit
                string pptxPath = System.IO.Path.Combine(outputDir, "presentation.pptx");
                presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}