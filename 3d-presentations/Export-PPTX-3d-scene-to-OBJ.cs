// -----------------------------------------------------------------------------
// Example: Export PPTX 3D scene to OBJ using C#
//
// Description:
// Demonstrates how to export 3D scenes embedded in a PPTX presentation to
// Wavefront OBJ files using C# and Aspose.Slides for .NET. The example loads a
// presentation, iterates through all slides and shapes, detects shapes that
// contain a 3‑D scene, and saves each scene as an OBJ file. This pattern can be
// used to extract 3‑D assets from PowerPoint files for further processing or
// integration into other 3‑D pipelines.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, OBJ, 3D scene, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of 3‑D models from PPTX files.
// - Build C# tools for converting PowerPoint 3‑D content to standard 3‑D formats.
// - Integrate PowerPoint 3‑D assets into custom rendering or analysis pipelines.
// - Validate and archive 3‑D content from presentations before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Export3DSceneToOBJ
{
    class Program
    {
        static void Main(string[] args)
        {
            // First argument: path to the input PPTX file.
            // Second argument (optional): folder where OBJ files will be saved.
            string presentationPath = args.Length > 0 ? args[0] : "inputPresentation.pptx";
            string outputFolder = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Console.WriteLine($"Output folder does not exist: {outputFolder}");
                return;
            }

            Presentation presentation;
            try
            {
                presentation = new Presentation(presentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load presentation. {ex.Message}");
                return;
            }

            int exportedCount = 0;

            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape has a 3‑D format with an associated scene.
                    if (shape.ThreeDFormat?.Scene != null)
                    {
                        try
                        {
                            IThreeDScene scene = shape.ThreeDFormat.Scene;
                            string safeShapeName = string.IsNullOrWhiteSpace(shape.Name) ? "shape" : shape.Name;
                            string objFileName = $"slide{slide.SlideNumber}_{safeShapeName}_scene.obj";
                            string objPath = Path.Combine(outputFolder, objFileName);

                            // Export the 3‑D scene to OBJ using default options.
                            scene.ExportToObj(objPath, new ObjExportOptions());

                            Console.WriteLine($"Exported OBJ: {objPath}");
                            exportedCount++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to export OBJ for shape on slide {slide.SlideNumber}. {ex.Message}");
                        }
                    }
                }
            }

            presentation.Dispose();

            Console.WriteLine(exportedCount > 0
                ? $"Export completed. {exportedCount} OBJ file(s) created."
                : "No 3‑D scenes were found in the presentation.");
        }
    }
}
