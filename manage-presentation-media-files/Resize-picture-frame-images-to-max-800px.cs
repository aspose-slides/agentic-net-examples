using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImageResizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides and shapes
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only picture frames (embedded images)
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame picture = (Aspose.Slides.IPictureFrame)shape;
                            float originalWidth = picture.Width;

                            // Resize if width exceeds 800 pixels
                            if (originalWidth > 800f)
                            {
                                float scaleFactor = 800f / originalWidth;
                                picture.Width = 800f;
                                picture.Height = picture.Height * scaleFactor;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for this operation.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}