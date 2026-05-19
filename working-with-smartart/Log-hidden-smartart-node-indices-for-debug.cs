using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectHiddenSmartArtNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                            Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;

                            int nodeIndex = 0;
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                            {
                                if (node.IsHidden)
                                {
                                    Console.WriteLine($"Slide {slideIndex}, SmartArt node index {nodeIndex} is hidden.");
                                }
                                nodeIndex++;
                            }
                        }
                    }
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}