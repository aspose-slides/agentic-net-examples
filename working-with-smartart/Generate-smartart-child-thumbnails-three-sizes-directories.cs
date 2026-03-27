using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputBasePath = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create directories for three sizes
            string smallDir = Path.Combine(outputBasePath, "Small");
            string mediumDir = Path.Combine(outputBasePath, "Medium");
            string largeDir = Path.Combine(outputBasePath, "Large");

            if (!Directory.Exists(smallDir))
                Directory.CreateDirectory(smallDir);
            if (!Directory.Exists(mediumDir))
                Directory.CreateDirectory(mediumDir);
            if (!Directory.Exists(largeDir))
                Directory.CreateDirectory(largeDir);

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Find SmartArt shapes
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is SmartArt)
                    {
                        SmartArt smartArt = (SmartArt)shape;

                        // Iterate through all nodes
                        for (int nodeIndex = 0; nodeIndex < smartArt.AllNodes.Count; nodeIndex++)
                        {
                            ISmartArtNode parentNode = smartArt.AllNodes[nodeIndex];

                            // Iterate through child nodes of each parent node
                            for (int childIndex = 0; childIndex < parentNode.ChildNodes.Count; childIndex++)
                            {
                                ISmartArtNode childNode = parentNode.ChildNodes[childIndex];

                                // Get the first shape of the child node
                                if (childNode.Shapes.Count > 0)
                                {
                                    ISmartArtShape childShape = childNode.Shapes[0];

                                    // Generate thumbnail image
                                    IImage thumbnail = childShape.GetImage();

                                    // Build file names
                                    string baseFileName = $"Slide{slideIndex + 1}_Node{nodeIndex + 1}_Child{childIndex + 1}";
                                    string smallPath = Path.Combine(smallDir, baseFileName + "_small.jpg");
                                    string mediumPath = Path.Combine(mediumDir, baseFileName + "_medium.jpg");
                                    string largePath = Path.Combine(largeDir, baseFileName + "_large.jpg");

                                    // Save the same thumbnail to each directory (size differentiation can be handled later)
                                    thumbnail.Save(smallPath, Aspose.Slides.ImageFormat.Jpeg);
                                    thumbnail.Save(mediumPath, Aspose.Slides.ImageFormat.Jpeg);
                                    thumbnail.Save(largePath, Aspose.Slides.ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }
            }

            // Save presentation before exit
            presentation.Save("modified_output.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}