using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                            bool hasHiddenNode = false;
                            for (int nodeIndex = 0; nodeIndex < smartArt.AllNodes.Count; nodeIndex++)
                            {
                                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smartArt.AllNodes[nodeIndex];
                                if (node.IsHidden)
                                {
                                    hasHiddenNode = true;
                                    break;
                                }
                            }
                            if (hasHiddenNode)
                            {
                                Console.WriteLine("Hidden SmartArt found on slide index: " + slideIndex);
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}