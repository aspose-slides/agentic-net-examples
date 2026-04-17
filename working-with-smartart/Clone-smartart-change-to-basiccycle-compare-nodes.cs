using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtExample
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

            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported.
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            Aspose.Slides.ISlide srcSlide = pres.Slides[0];
            Aspose.Slides.IShape srcSmartArtShape = null;
            foreach (Aspose.Slides.IShape shape in srcSlide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    srcSmartArtShape = shape;
                    break;
                }
            }

            if (srcSmartArtShape == null)
            {
                Console.WriteLine("No SmartArt shape found on the first slide.");
                pres.Dispose();
                return;
            }

            Aspose.Slides.SmartArt.ISmartArt srcSmartArt = (Aspose.Slides.SmartArt.ISmartArt)srcSmartArtShape;
            int srcNodeCount = srcSmartArt.AllNodes.Count;

            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(srcSmartArtShape, 0f, 0f);
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

            // Change layout of the cloned SmartArt
            clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle;

            int clonedNodeCount = clonedSmartArt.AllNodes.Count;

            Console.WriteLine("Source SmartArt node count: " + srcNodeCount);
            Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);

            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            pres.Dispose();
        }
    }
}