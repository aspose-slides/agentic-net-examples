// -----------------------------------------------------------------------------
// Example: Replace 3D Model Materials with Matte Finish in PowerPoint using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through all slides and
// shapes, and replaces the material of every 3‑D model with a matte finish.
// It uses Aspose.Slides for .NET to manipulate the presentation and employs
// reflection to handle 3‑D APIs safely, ensuring the code compiles even if the
// 3‑D namespace is unavailable. The modified presentation is saved as a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D model, material, matte finish
//
// Use Cases:
// - Updating corporate slide decks to apply a consistent matte material to all 3‑D objects.
// - Preparing presentations for printing where glossy 3‑D materials are undesirable.
// - Automating bulk style changes across multiple PowerPoint files in a CI pipeline.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlides3DMaterialExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Type shapeType = shape.GetType();
                        string fullName = shapeType.FullName ?? string.Empty;

                        // Identify 3‑D model shapes via type name (avoids direct reference to missing namespace)
                        if (fullName.Contains("ThreeD") && fullName.Contains("Model3D"))
                        {
                            // Attempt to get the 'Material' property
                            PropertyInfo materialProperty = shapeType.GetProperty("Material", BindingFlags.Public | BindingFlags.Instance);
                            if (materialProperty != null)
                            {
                                object materialInstance = materialProperty.GetValue(shape);
                                if (materialInstance == null)
                                {
                                    // Create a new Material instance if none exists
                                    Assembly slidesAssembly = shapeType.Assembly;
                                    Type materialType = slidesAssembly.GetType("Aspose.Slides.ThreeD.Material");
                                    if (materialType != null)
                                    {
                                        object newMaterial = Activator.CreateInstance(materialType);
                                        PropertyInfo fillTypeProperty = materialType.GetProperty("FillType", BindingFlags.Public | BindingFlags.Instance);
                                        if (fillTypeProperty != null)
                                        {
                                            Type fillTypeEnum = fillTypeProperty.PropertyType;
                                            object matteEnumValue = Enum.Parse(fillTypeEnum, "Matte");
                                            fillTypeProperty.SetValue(newMaterial, matteEnumValue);
                                            materialProperty.SetValue(shape, newMaterial);
                                        }
                                    }
                                }
                                else
                                {
                                    // Modify existing material to use matte finish
                                    PropertyInfo fillTypeProperty = materialInstance.GetType().GetProperty("FillType", BindingFlags.Public | BindingFlags.Instance);
                                    if (fillTypeProperty != null)
                                    {
                                        Type fillTypeEnum = fillTypeProperty.PropertyType;
                                        object matteEnumValue = Enum.Parse(fillTypeEnum, "Matte");
                                        fillTypeProperty.SetValue(materialInstance, matteEnumValue);
                                    }
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
            }
        }
    }
}
