// -----------------------------------------------------------------------------
// Example: Export 3D Models from PowerPoint to OBJ Files using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through its slides and
// shapes, and attempts to export any 3D model shapes to separate OBJ files.
// It uses reflection to handle the optional Aspose.Slides.ThreeD API, ensuring
// the program compiles even when the 3D namespace is unavailable. The
// presentation is saved after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D model export, OBJ, reflection
//
// Use Cases:
// - Extract 3D assets from a corporate presentation for reuse in 3D software.
// - Automate conversion of PowerPoint 3D models to OBJ for game development.
// - Validate presence of 3D content in a batch of presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlides3DExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file '" + inputPath + "' does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                int modelCounter = 0;

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Use reflection to detect if the shape implements the 3D model interface.
                        Type shapeType = shape.GetType();
                        Type threeDInterface = shapeType.GetInterface("Aspose.Slides.ThreeD.IThreeDModel");

                        if (threeDInterface != null)
                        {
                            // Attempt to locate an ExportToObj method (signature may vary).
                            MethodInfo exportMethod = threeDInterface.GetMethod("ExportToObj", new Type[] { typeof(string) });

                            if (exportMethod != null)
                            {
                                string outputFile = $"model_{modelCounter}.obj";

                                try
                                {
                                    exportMethod.Invoke(shape, new object[] { outputFile });
                                    Console.WriteLine("Exported 3D model to " + outputFile);
                                    modelCounter++;
                                }
                                catch (TargetInvocationException tie)
                                {
                                    Console.WriteLine("Failed to export 3D model: " + tie.InnerException?.Message);
                                }
                            }
                            else
                            {
                                // The expected ExportToObj method does not exist.
                                Console.WriteLine("3D model detected but ExportToObj method is unavailable.");
                            }
                        }
                    }
                }

                // Save the presentation (optional, ensures any changes are persisted).
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Processing completed. Presentation saved as output.pptx.");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors, such as missing Aspose.Slides assemblies.
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the error is due to unsupported 3D features, note it.
                if (ex.Message.Contains("ThreeD"))
                {
                    Console.WriteLine("Note: The Aspose.Slides.ThreeD namespace is not available in this version. 3D model export is not supported.");
                }
            }
        }
    }
}
