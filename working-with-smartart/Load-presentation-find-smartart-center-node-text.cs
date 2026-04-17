using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesSmartArtExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                            if (smartArt != null)
                            {
                                Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                                for (int nodeIndex = 0; nodeIndex < allNodes.Count; nodeIndex++)
                                {
                                    Aspose.Slides.SmartArt.ISmartArtNode node = allNodes[nodeIndex];
                                    if (node.TextFrame != null && node.TextFrame.Paragraphs.Count > 0)
                                    {
                                        Aspose.Slides.IParagraph paragraph = node.TextFrame.Paragraphs[0];
                                        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                                    }
                                }
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}