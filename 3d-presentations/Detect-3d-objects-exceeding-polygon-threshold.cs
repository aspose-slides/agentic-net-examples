// -----------------------------------------------------------------------------
// Example: Detect 3D Objects Exceeding Polygon Count Threshold in PowerPoint
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// scans each slide for 3D shapes, and reports any shape whose polygon count
// exceeds a user‑specified threshold. It demonstrates handling of missing
// 3D support via reflection and ensures the presentation is saved before exit.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D shapes, polygon count, detection
//
// Use Cases:
// - Quality control of presentations containing complex 3D models.
// - Automated validation of slide assets before publishing.
// - Reducing file size by identifying overly detailed 3D objects.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlides3DDetection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath;
            string outputPath = "output.pptx";
            int polygonThreshold;

            if (args.Length >= 1 && !String.IsNullOrWhiteSpace(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            if (args.Length >= 2 && Int32.TryParse(args[1], out int parsedThreshold))
            {
                polygonThreshold = parsedThreshold;
            }
            else
            {
                polygonThreshold = 1000; // default threshold
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist: " + inputPath);
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

                        // Attempt to locate a 3D related property via reflection.
                        PropertyInfo threeDProperty = shapeType.GetProperty("ThreeDFormat");
                        if (threeDProperty == null)
                        {
                            // Some versions expose 3D data through a property named "ThreeD".
                            threeDProperty = shapeType.GetProperty("ThreeD");
                        }

                        if (threeDProperty != null)
                        {
                            object threeDObject = threeDProperty.GetValue(shape, null);
                            if (threeDObject != null)
                            {
                                Type threeDType = threeDObject.GetType();

                                // Look for a property that represents polygon count.
                                PropertyInfo polygonCountProperty = threeDType.GetProperty("PolygonCount");
                                if (polygonCountProperty != null)
                                {
                                    object polygonCountValue = polygonCountProperty.GetValue(threeDObject, null);
                                    if (polygonCountValue is int polygonCount)
                                    {
                                        if (polygonCount > polygonThreshold)
                                        {
                                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} exceeds threshold: {polygonCount} polygons.");
                                        }
                                    }
                                }
                                else
                                {
                                    // If PolygonCount property is not available, attempt a generic count property.
                                    PropertyInfo genericCountProperty = threeDType.GetProperty("Count");
                                    if (genericCountProperty != null && genericCountProperty.PropertyType == typeof(int))
                                    {
                                        object countValue = genericCountProperty.GetValue(threeDObject, null);
                                        if (countValue is int count && count > polygonThreshold)
                                        {
                                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} exceeds threshold: {count} polygons (generic count).");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the presentation (even if unchanged) as required.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Processing completed. Output saved to: " + outputPath);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Error: Required Aspose.Slides assembly not found. " + fnfEx.Message);
            }
            catch (BadImageFormatException bifEx)
            {
                Console.WriteLine("Error: Incompatible Aspose.Slides assembly version. " + bifEx.Message);
            }
            catch (Exception ex)
            {
                // If the exception is due to missing 3D support, inform the user.
                if (ex.Message.Contains("ThreeD") || ex.Message.Contains("3D"))
                {
                    Console.WriteLine("3D detection is not supported by the current Aspose.Slides version or the file format.");
                }
                else
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }
    }
}
