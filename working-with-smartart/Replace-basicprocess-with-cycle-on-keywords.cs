using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Check if the slide contains the keyword
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetTextBoxesContainsText(slide, "keyword", false);
                if (textFrames.Length == 0)
                {
                    continue;
                }

                // Iterate through shapes to find SmartArt objects
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                    if (smartArt != null)
                    {
                        // Replace BasicProcess layout with BasicCycle layout
                        if (smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess)
                        {
                            smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}