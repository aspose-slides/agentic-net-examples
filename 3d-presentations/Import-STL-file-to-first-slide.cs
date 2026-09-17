// -----------------------------------------------------------------------------
// Example: Embed STL 3D Model into PowerPoint Slide using Aspose.Slides
//
// Description:
// This console application loads an external STL file, attempts to embed it as a
// native 3D model on the first slide of a new PowerPoint presentation using
// Aspose.Slides for .NET, and falls back to embedding the file as an OLE object
// if 3D support is unavailable. The resulting PPTX file is saved to disk.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, STL, 3D model, OLE embedding
//
// Use Cases:
// - Adding engineering 3D models to presentation decks for design reviews.
// - Automating the creation of product showcase slides with embedded STL files.
// - Providing a fallback mechanism for environments where 3D APIs are not supported.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlidesStlEmbed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Input STL file path (adjust as needed)
            string inputStlPath = "model.stl";
            // Output PPTX file path
            string outputPptxPath = "StlEmbeddedPresentation.pptx";

            // Verify input file exists
            if (!File.Exists(inputStlPath))
            {
                Console.WriteLine("Input STL file not found: " + inputStlPath);
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPptxPath));
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load STL bytes
            byte[] stlData = File.ReadAllBytes(inputStlPath);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            try
            {
                // Get the first slide (creates one by default)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Attempt to embed as native 3D model using reflection
                bool threeDEmbedded = false;
                try
                {
                    // Load the ThreeDModelDataInfo type
                    Type threeDModelDataInfoType = Type.GetType("Aspose.Slides.DOM.ThreeD.ThreeDModelDataInfo, Aspose.Slides");
                    if (threeDModelDataInfoType != null)
                    {
                        // Create an instance: new ThreeDModelDataInfo(stlData, "stl")
                        object threeDDataInfo = Activator.CreateInstance(threeDModelDataInfoType, new object[] { stlData, "stl" });

                        // Find Add3DModelFrame method on IShapeCollection
                        MethodInfo add3DModelMethod = slide.Shapes.GetType().GetMethod("Add3DModelFrame");
                        if (add3DModelMethod != null)
                        {
                            // Parameters: x, y, width, height, dataInfo
                            double x = 0;
                            double y = 0;
                            double width = presentation.SlideSize.Size.Width;
                            double height = presentation.SlideSize.Size.Height;

                            add3DModelMethod.Invoke(slide.Shapes, new object[] { x, y, width, height, threeDDataInfo });
                            threeDEmbedded = true;
                            Console.WriteLine("STL embedded as native 3D model.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log reflection errors but continue to fallback
                    Console.WriteLine("Reflection error while embedding 3D model: " + ex.Message);
                }

                // Fallback to OLE embedding if native 3D not supported
                if (!threeDEmbedded)
                {
                    // Create OLE embedded data info
                    Aspose.Slides.IOleEmbeddedDataInfo oleDataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(stlData, "stl");
                    // Add OLE object frame covering the whole slide
                    Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height, oleDataInfo);
                    Console.WriteLine("STL embedded as OLE object (fallback).");
                }

                // Save the presentation
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPptxPath);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
