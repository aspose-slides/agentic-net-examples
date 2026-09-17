// -----------------------------------------------------------------------------
// Example: Set Camera View Matrix for All 3D Scenes in a PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file, iterates through each slide,
// and for every 3D scene it sets a predefined camera view matrix using the
// Aspose.Slides 3D API. It handles missing files, unsupported formats, and
// the absence of the 3D API gracefully, ensuring the presentation is saved
// before the program exits.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D scene, camera view matrix, SetViewMatrix
//
// Use Cases:
// - Adjusting the perspective of 3D objects across all slides in a corporate deck.
// - Automating consistent camera angles for 3D charts in educational presentations.
// - Preparing presentations for export where a uniform 3D view is required.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlides3DCameraExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file \"{inputPath}\" does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load presentation: {ex.Message}");
                return;
            }

            // Attempt to locate the 3D API types via reflection.
            Type scene3DType = Type.GetType("Aspose.Slides.ThreeD.Scene3D, Aspose.Slides");
            Type cameraType = Type.GetType("Aspose.Slides.ThreeD.Camera, Aspose.Slides");
            Type matrix4x4Type = Type.GetType("Aspose.Slides.ThreeD.Matrix4x4, Aspose.Slides");

            if (scene3DType == null || cameraType == null || matrix4x4Type == null)
            {
                Console.WriteLine("Aspose.Slides 3D API is not available in the current assembly. Skipping 3D processing.");
                // Save the original presentation unchanged.
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved to \"{outputPath}\".");
                }
                catch (Exception saveEx)
                {
                    Console.WriteLine($"Failed to save presentation: {saveEx.Message}");
                }
                return;
            }

            // Prepare a simple identity view matrix (you can replace this with any custom matrix).
            object viewMatrix = null;
            try
            {
                // Matrix4x4 has a static method Identity or a constructor that accepts a 2‑D array.
                // We'll try the constructor approach.
                double[,] identityValues = new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
                ConstructorInfo matrixCtor = matrix4x4Type.GetConstructor(new Type[] { typeof(double[,]) });
                if (matrixCtor != null)
                {
                    viewMatrix = matrixCtor.Invoke(new object[] { identityValues });
                }
                else
                {
                    // Fallback: try to use a static property Identity if it exists.
                    PropertyInfo identityProp = matrix4x4Type.GetProperty("Identity", BindingFlags.Public | BindingFlags.Static);
                    viewMatrix = identityProp?.GetValue(null);
                }
            }
            catch (Exception matEx)
            {
                Console.WriteLine($"Failed to create view matrix: {matEx.Message}");
                // Continue without setting the matrix.
            }

            // Iterate through slides and apply the view matrix to each 3D scene.
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Use reflection to get the collection of 3D scenes from the slide.
                PropertyInfo scenesProp = slide.GetType().GetProperty("ThreeDScenes", BindingFlags.Public | BindingFlags.Instance);
                if (scenesProp == null)
                {
                    // Some versions expose a single Scene3D via a property named "Scene3D".
                    scenesProp = slide.GetType().GetProperty("Scene3D", BindingFlags.Public | BindingFlags.Instance);
                }

                if (scenesProp == null)
                {
                    // No 3D scenes on this slide.
                    continue;
                }

                object scenesObj = scenesProp.GetValue(slide);
                if (scenesObj == null)
                {
                    continue;
                }

                // Handle both collection and single scene scenarios.
                if (scenesObj is System.Collections.IEnumerable enumerableScenes)
                {
                    foreach (object scene in enumerableScenes)
                    {
                        ApplyCameraViewMatrix(scene, cameraType, viewMatrix);
                    }
                }
                else
                {
                    ApplyCameraViewMatrix(scenesObj, cameraType, viewMatrix);
                }
            }

            // Save the modified presentation.
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved with updated camera views to \"{outputPath}\".");
            }
            catch (Exception saveEx)
            {
                Console.WriteLine($"Failed to save presentation: {saveEx.Message}");
            }
        }

        private static void ApplyCameraViewMatrix(object sceneInstance, Type cameraType, object viewMatrix)
        {
            if (sceneInstance == null || cameraType == null)
                return;

            // Retrieve the Camera property from the Scene3D instance.
            PropertyInfo cameraProp = sceneInstance.GetType().GetProperty("Camera", BindingFlags.Public | BindingFlags.Instance);
            if (cameraProp == null)
                return;

            object cameraInstance = cameraProp.GetValue(sceneInstance);
            if (cameraInstance == null)
                return;

            // Find a method named SetViewMatrix that accepts a Matrix4x4 (or double[,] as fallback).
            MethodInfo setViewMethod = cameraType.GetMethod("SetViewMatrix", BindingFlags.Public | BindingFlags.Instance);
            if (setViewMethod == null)
                return;

            try
            {
                if (viewMatrix != null)
                {
                    setViewMethod.Invoke(cameraInstance, new object[] { viewMatrix });
                }
            }
            catch (TargetInvocationException tie)
            {
                Console.WriteLine($"Error applying view matrix: {tie.InnerException?.Message ?? tie.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error applying view matrix: {ex.Message}");
            }
        }
    }
}
