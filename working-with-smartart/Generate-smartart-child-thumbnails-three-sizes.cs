using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace GenerateSmartArtThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output folders for three sizes
            string outputBase = "output";
            string smallFolder = Path.Combine(outputBase, "Small");
            string mediumFolder = Path.Combine(outputBase, "Medium");
            string largeFolder = Path.Combine(outputBase, "Large");
            Directory.CreateDirectory(smallFolder);
            Directory.CreateDirectory(mediumFolder);
            Directory.CreateDirectory(largeFolder);

            // Desired dimensions (width x height) in pixels
            int[] desiredWidths = new int[] { 200, 400, 800 };
            int[] desiredHeights = new int[] { 150, 300, 600 };
            string[] sizeFolders = new string[] { smallFolder, mediumFolder, largeFolder };

            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Find SmartArt objects on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        // Attempt to cast shape to SmartArt
                        ISmartArt smartArt = slide.Shapes[shapeIndex] as ISmartArt;
                        if (smartArt == null)
                        {
                            continue;
                        }

                        // Iterate through all nodes (including child nodes)
                        for (int nodeIndex = 0; nodeIndex < smartArt.AllNodes.Count; nodeIndex++)
                        {
                            ISmartArtNode node = smartArt.AllNodes[nodeIndex];

                            // Each node may contain multiple shapes
                            for (int nodeShapeIndex = 0; nodeShapeIndex < node.Shapes.Count; nodeShapeIndex++)
                            {
                                IShape nodeShape = node.Shapes[nodeShapeIndex] as IShape;
                                if (nodeShape == null)
                                {
                                    continue;
                                }

                                // Generate thumbnails for each desired size
                                for (int sizeIndex = 0; sizeIndex < desiredWidths.Length; sizeIndex++)
                                {
                                    float scaleX = (float)desiredWidths[sizeIndex] / pres.SlideSize.Size.Width;
                                    float scaleY = (float)desiredHeights[sizeIndex] / pres.SlideSize.Size.Height;

                                    using (IImage image = nodeShape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY))
                                    {
                                        string fileName = string.Format(
                                            "slide{0}_node{1}_shape{2}_{3}x{4}.png",
                                            slide.SlideNumber,
                                            nodeIndex,
                                            nodeShapeIndex,
                                            desiredWidths[sizeIndex],
                                            desiredHeights[sizeIndex]);

                                        string outputPath = Path.Combine(sizeFolders[sizeIndex], fileName);
                                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                string outputPresentation = Path.Combine(outputBase, "ProcessedPresentation.pptx");
                pres.Save(outputPresentation, SaveFormat.Pptx);
            }
        }
    }
}