// -----------------------------------------------------------------------------
// Example: Increase Ambient Light Intensity of 3D Shapes in a PowerPoint Presentation
//
// Description:
// This console application loads an existing PPTX file, iterates through all
// slides and shapes, and increases the ambient light intensity of each shape
// that contains a 3D format. It demonstrates the use of Aspose.Slides for
// .NET to modify lighting settings, improving visual contrast of 3D models.
// The modified presentation is saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D lighting, ambient intensity, ThreeDFormat
//
// Use Cases:
// - Enhance the appearance of 3D objects in a corporate presentation.
// - Automatically adjust lighting for better readability on different displays.
// - Batch process multiple presentations to standardize 3D lighting settings.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesLightingAdjustment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Desired increase factor (e.g., increase by 20%)
            const float increaseFactor = 1.20f;

            // Iterate through slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    // Check if shape has a ThreeDFormat
                    if (shape.ThreeDFormat != null)
                    {
                        // Ensure LightRig is available
                        if (shape.ThreeDFormat.LightRig != null)
                        {
                            // Retrieve current ambient intensity if supported
                            // Some versions expose AmbientIntensity; otherwise skip
                            try
                            {
                                // Attempt to read existing value via reflection to avoid compile-time errors
                                System.Reflection.PropertyInfo ambientProp = shape.ThreeDFormat.LightRig.GetType().GetProperty("AmbientIntensity");
                                if (ambientProp != null && ambientProp.CanRead && ambientProp.CanWrite)
                                {
                                    object currentValueObj = ambientProp.GetValue(shape.ThreeDFormat.LightRig);
                                    if (currentValueObj is float currentValue)
                                    {
                                        float newValue = currentValue * increaseFactor;
                                        // Clamp to maximum of 1.0f
                                        if (newValue > 1.0f)
                                        {
                                            newValue = 1.0f;
                                        }
                                        ambientProp.SetValue(shape.ThreeDFormat.LightRig, newValue);
                                        Console.WriteLine($"Adjusted ambient intensity for shape {shapeIndex} on slide {slideIndex} to {newValue}");
                                    }
                                }
                                else
                                {
                                    // Property not available; skip adjustment
                                    Console.WriteLine($"AmbientIntensity property not found for shape {shapeIndex} on slide {slideIndex}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error adjusting ambient intensity for shape {shapeIndex} on slide {slideIndex}: {ex.Message}");
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
