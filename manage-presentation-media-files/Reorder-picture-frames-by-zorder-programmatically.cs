using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReorderPictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first slide (adjust index as needed)
                ISlide slide = pres.Slides[0];

                // Collect all picture frames on the slide
                List<IShape> pictureFrames = new List<IShape>();
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    IShape shape = slide.Shapes[i];
                    if (shape is PictureFrame)
                    {
                        pictureFrames.Add(shape);
                    }
                }

                // Sort picture frames by their Z-order position (back to front)
                pictureFrames.Sort((a, b) =>
                {
                    int zA = ((PictureFrame)a).ZOrderPosition;
                    int zB = ((PictureFrame)b).ZOrderPosition;
                    return zA.CompareTo(zB);
                });

                // Reorder the picture frames in the shape collection based on sorted order
                for (int i = 0; i < pictureFrames.Count; i++)
                {
                    slide.Shapes.Reorder(i, pictureFrames[i]);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}