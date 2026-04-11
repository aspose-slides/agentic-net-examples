using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    // Collect hidden picture frames to remove
                    List<Aspose.Slides.IShape> shapesToRemove = new List<Aspose.Slides.IShape>();
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IPictureFrame picFrame = shape as Aspose.Slides.IPictureFrame;
                        if (picFrame != null && shape.Hidden)
                        {
                            shapesToRemove.Add(shape);
                        }
                    }

                    // Remove the collected picture frames
                    foreach (Aspose.Slides.IShape shape in shapesToRemove)
                    {
                        slide.Shapes.Remove(shape);
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}