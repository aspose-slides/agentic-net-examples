using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                float scaleFactor = 1.5f; // Uniform scaling factor

                foreach (ISlide slide in pres.Slides)
                {
                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        Ink inkShape = slide.Shapes[i] as Ink;
                        if (inkShape != null)
                        {
                            // Preserve original dimensions and position
                            float originalX = inkShape.X;
                            float originalY = inkShape.Y;
                            float originalWidth = inkShape.Width;
                            float originalHeight = inkShape.Height;

                            // Apply uniform scaling
                            inkShape.Width = originalWidth * scaleFactor;
                            inkShape.Height = originalHeight * scaleFactor;

                            // Keep the shape centered
                            inkShape.X = originalX - (inkShape.Width - originalWidth) / 2;
                            inkShape.Y = originalY - (inkShape.Height - originalHeight) / 2;

                            // Brush size is left unchanged (no modifications to inkShape.Traces[i].Brush.Size)
                        }
                    }
                }

                string outputPath = "output_scaled.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}