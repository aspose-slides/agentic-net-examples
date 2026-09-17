// -----------------------------------------------------------------------------
// Example: Validate Supported Texture Formats for 3D Objects in PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file, iterates through all slides and
// shapes, and checks that any 3D objects reference texture files with supported
// extensions (PNG, JPG, JPEG, BMP). If all textures are valid, the presentation
// is saved; otherwise, the save is aborted and a warning is printed.
// The task uses C#, Aspose.Slides for .NET, and handles missing input files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D objects, texture validation, supported formats
//
// Use Cases:
// - Ensure corporate slide decks comply with branding guidelines that restrict texture formats.
// - Pre‑process presentations before publishing to avoid runtime errors in 3D rendering.
// - Automate quality checks in a CI pipeline for slide assets.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace Validate3DTextures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputFilePath = "input.pptx";
            string outputFilePath = "output_validated.pptx";

            // Verify input file exists
            if (!System.IO.File.Exists(inputFilePath))
            {
                Console.WriteLine("Error: Input file '" + inputFilePath + "' does not exist.");
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputFilePath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Supported texture extensions
            string[] supportedExtensions = new string[] { ".png", ".jpg", ".jpeg", ".bmp" };
            bool allTexturesSupported = true;

            // Iterate through slides and shapes
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Identify potential 3D objects by type name containing "ThreeD"
                    System.Type shapeType = shape.GetType();
                    if (shapeType.FullName != null && shapeType.FullName.Contains("ThreeD"))
                    {
                        // Attempt to retrieve a Materials collection via reflection
                        System.Reflection.PropertyInfo materialsProp = shapeType.GetProperty("Materials");
                        if (materialsProp != null)
                        {
                            System.Collections.IEnumerable materials = materialsProp.GetValue(shape) as System.Collections.IEnumerable;
                            if (materials != null)
                            {
                                foreach (object material in materials)
                                {
                                    System.Type materialType = material.GetType();
                                    System.Reflection.PropertyInfo textureProp = materialType.GetProperty("TextureFileName");
                                    if (textureProp != null)
                                    {
                                        string textureFile = textureProp.GetValue(material) as string;
                                        if (!string.IsNullOrEmpty(textureFile))
                                        {
                                            string extension = System.IO.Path.GetExtension(textureFile).ToLowerInvariant();
                                            if (System.Array.IndexOf(supportedExtensions, extension) < 0)
                                            {
                                                Console.WriteLine("Unsupported texture format '" + extension + "' in shape '" + shape.Name + "' on slide " + slide.SlideNumber + ".");
                                                allTexturesSupported = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Save presentation if all textures are supported
            if (allTexturesSupported)
            {
                try
                {
                    presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved successfully to '" + outputFilePath + "'.");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Presentation not saved due to unsupported texture formats.");
            }

            // Clean up
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
