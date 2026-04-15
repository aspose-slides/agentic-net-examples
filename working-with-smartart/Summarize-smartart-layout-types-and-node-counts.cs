using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is ISmartArt smartArt)
                        {
                            SmartArtLayoutType layout = smartArt.Layout;
                            int nodeCount = smartArt.AllNodes.Count;
                            Console.WriteLine($"Slide {slide.SlideNumber}: Layout = {layout}, Nodes = {nodeCount}");
                        }
                    }
                }

                // Save presentation before exit
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}