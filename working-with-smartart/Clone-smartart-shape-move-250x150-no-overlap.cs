using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = new Presentation(inputPath);
        ISlide slide = pres.Slides[0];

        // Find the first SmartArt shape on the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = null;
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                break;
            }
        }

        if (smartArt != null)
        {
            // Clone the SmartArt shape and place it at (250,150)
            IShape clonedShape = slide.Shapes.AddClone(smartArt, 250f, 150f);

            // Ensure the cloned shape does not intersect any other shape
            bool intersect;
            do
            {
                intersect = false;
                foreach (IShape otherShape in slide.Shapes)
                {
                    if (otherShape == clonedShape)
                        continue;

                    if (otherShape.X < clonedShape.X + clonedShape.Width &&
                        otherShape.X + otherShape.Width > clonedShape.X &&
                        otherShape.Y < clonedShape.Y + clonedShape.Height &&
                        otherShape.Y + otherShape.Height > clonedShape.Y)
                    {
                        // Move the cloned shape down by 20 points and re‑check
                        clonedShape.Y += 20f;
                        intersect = true;
                        break;
                    }
                }
            } while (intersect);
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}