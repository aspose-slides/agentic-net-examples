using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Apply3DRotation
{
    class Program
    {
        static void Main(string[] args)
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    if (presentation.Slides.Count < 2)
                    {
                        Console.WriteLine("The presentation does not contain a second slide.");
                        return;
                    }

                    Aspose.Slides.ISlide secondSlide = presentation.Slides[1];

                    foreach (Aspose.Slides.IShape shape in secondSlide.Shapes)
                    {
                        if (shape is Aspose.Slides.PictureFrame)
                        {
                            Aspose.Slides.PictureFrame picture = (Aspose.Slides.PictureFrame)shape;
                            // Apply a 3‑D rotation (example: 30 degrees around X‑axis)
                            picture.ThreeDFormat.Camera.SetRotation(30, 0, 0);
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}