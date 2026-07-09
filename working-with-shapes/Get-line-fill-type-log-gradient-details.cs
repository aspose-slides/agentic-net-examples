using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            // Create a presentation with a gradient line if the file does not exist
            if (!File.Exists(inputPath))
            {
                using (Presentation pres = new Presentation())
                {
                    ISlide slide = pres.Slides[0];
                    // Add a line shape (coordinates as float literals)
                    IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);
                    // Set line fill to gradient
                    line.LineFormat.FillFormat.FillType = FillType.Gradient;
                    // Configure gradient properties
                    IGradientFormat gradient = line.LineFormat.FillFormat.GradientFormat;
                    gradient.LinearGradientAngle = 45f;
                    // Save the newly created presentation
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    ISlide slide = pres.Slides[0];
                    // Assume the first shape is the line
                    IShape shape = slide.Shapes[0];
                    ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
                    ILineFillFormatEffectiveData lineFill = effectiveLine.FillFormat;

                    Console.WriteLine("Line Fill Type: " + lineFill.FillType);

                    if (lineFill.FillType == FillType.Gradient)
                    {
                        IGradientFormatEffectiveData gradientEff = lineFill.GradientFormat;
                        Console.WriteLine("Gradient Angle: " + gradientEff.LinearGradientAngle);
                        Console.WriteLine("Gradient Shape: " + gradientEff.GradientShape);
                        Console.WriteLine("Gradient Stops Count: " + gradientEff.GradientStops.Count);

                        for (int i = 0; i < gradientEff.GradientStops.Count; i++)
                        {
                            IGradientStopEffectiveData stop = gradientEff.GradientStops[i];
                            Console.WriteLine("Stop " + i + " Position: " + stop.Position + " Color: " + stop.Color);
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}