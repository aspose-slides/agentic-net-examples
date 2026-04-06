using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlides3DExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", Path.GetFileNameWithoutExtension(inputPath) + "_processed.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                int threeDObjectCount = 0;

                // Iterate through all slides and shapes
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        // Check if the shape has a ThreeDFormat (i.e., is a 3D object)
                        if (shape.ThreeDFormat != null)
                        {
                            threeDObjectCount++;
                            // Get effective 3D data
                            Aspose.Slides.IThreeDFormatEffectiveData effectiveData = shape.ThreeDFormat.GetEffective();

                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}:");
                            Console.WriteLine($"  Depth: {effectiveData.Depth}");
                            Console.WriteLine($"  Extrusion Height: {effectiveData.ExtrusionHeight}");
                            Console.WriteLine($"  Light Rig Type: {effectiveData.LightRig.LightType}");
                            Console.WriteLine($"  Camera Type: {effectiveData.Camera.CameraType}");
                        }
                    }
                }

                Console.WriteLine($"Total 3D objects found: {threeDObjectCount}");

                // Save the presentation before exit
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported file format, it will be caught here.
            }
        }
    }
}