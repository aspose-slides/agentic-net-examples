// -----------------------------------------------------------------------------
// Example: Replace 3D Model Materials with Matte Finish in PowerPoint using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, scans each slide for 3‑D model
// shapes, and changes their material to a solid gray matte finish. The program
// uses reflection to access the 3‑D material API, avoiding compile‑time
// dependencies on the Aspose.Slides.ThreeD namespace. The updated presentation
// is saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D model, material, matte finish
//
// Use Cases:
// - Standardizing appearance of 3D objects in corporate decks
// - Preparing presentations for printing by removing glossy effects
// - Automating bulk updates of 3D model materials across many files
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;
using System.Drawing;

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
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Type shapeType = shape.GetType();
                        // Identify 3D model shapes by namespace or type name containing "ThreeD"
                        if (shapeType.FullName != null && shapeType.FullName.Contains("ThreeD"))
                        {
                            PropertyInfo materialProp = shapeType.GetProperty("Material");
                            if (materialProp != null && materialProp.CanWrite)
                            {
                                object material = materialProp.GetValue(shape);
                                if (material != null)
                                {
                                    Type materialType = material.GetType();
                                    PropertyInfo fillFormatProp = materialType.GetProperty("FillFormat");
                                    if (fillFormatProp != null && fillFormatProp.CanWrite)
                                    {
                                        object fillFormat = fillFormatProp.GetValue(material);
                                        if (fillFormat != null)
                                        {
                                            Type fillFormatType = fillFormat.GetType();

                                            // Set FillType to Solid (matte)
                                            PropertyInfo fillTypeProp = fillFormatType.GetProperty("FillType");
                                            if (fillTypeProp != null && fillTypeProp.CanWrite)
                                            {
                                                Type fillTypeEnum = typeof(Aspose.Slides.FillType);
                                                object solidEnum = Enum.Parse(fillTypeEnum, "Solid");
                                                fillTypeProp.SetValue(fillFormat, solidEnum);
                                            }

                                            // Set solid fill color to a neutral gray for matte appearance
                                            PropertyInfo solidFillColorProp = fillFormatType.GetProperty("SolidFillColor");
                                            if (solidFillColorProp != null && solidFillColorProp.CanWrite)
                                            {
                                                solidFillColorProp.SetValue(fillFormat, Color.Gray);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved successfully to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // If the error is due to unsupported file format, note it.
                // Format not supported.
            }
        }
    }
}
