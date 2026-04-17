using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Locate the first SmartArt shape on the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    break;
                }
            }

            if (smartArt != null)
            {
                // Clone the SmartArt shape to the desired coordinates (250,150)
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(smartArt, 250f, 150f);

                // Ensure the cloned shape does not intersect any other shapes
                foreach (Aspose.Slides.IShape other in slide.Shapes)
                {
                    if (other != clonedShape)
                    {
                        bool intersect = !(clonedShape.X + clonedShape.Width <= other.X ||
                                           clonedShape.X >= other.X + other.Width ||
                                           clonedShape.Y + clonedShape.Height <= other.Y ||
                                           clonedShape.Y >= other.Y + other.Height);
                        while (intersect)
                        {
                            // Move the cloned shape down until it no longer intersects
                            clonedShape.Y += 20f;
                            intersect = !(clonedShape.X + clonedShape.Width <= other.X ||
                                           clonedShape.X >= other.X + other.Width ||
                                           clonedShape.Y + clonedShape.Height <= other.Y ||
                                           clonedShape.Y >= other.Y + other.Height);
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}