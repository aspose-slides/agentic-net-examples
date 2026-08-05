// -----------------------------------------------------------------------------
// Example: Add ellipse 3D rotation y to EMF using C#
//
// Description:
// Demonstrates how to add an ellipse shape with a 3‑D Y‑axis rotation,
// export the slide as an EMF file, and save the presentation as PPTX using
// Aspose.Slides for .NET. The example shows the required presentation‑processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// generate EMF graphics, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, EMF, Aspose.Slides for .NET, Ellipse, Rotation, 3D,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an ellipse with Y‑axis 3‑D rotation and exporting to EMF.
// - Build C# tools for PowerPoint presentation processing and graphics extraction.
// - Generate or transform PPTX files and corresponding EMF images in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
