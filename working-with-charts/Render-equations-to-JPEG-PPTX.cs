using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace RenderMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify input argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the input presentation file.");
                return;
            }

            string inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Directory for output images
            string outputDir = Path.Combine(Path.GetDirectoryName(inputPath), "MathImages");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Iterate through slides and shapes to find mathematical equations
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        bool hasMath = false;
                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                if (portion is MathPortion)
                                {
                                    hasMath = true;
                                    break;
                                }
                            }
                            if (hasMath) break;
                        }

                        if (hasMath)
                        {
                            // Render the entire slide as image (includes the equation)
                            IImage slideImage = slide.GetImage(1f, 1f);
                            string imagePath = Path.Combine(outputDir,
                                string.Format("Slide_{0}_Shape_{1}.jpg", slide.SlideNumber, shapeIndex));
                            slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                            slideImage.Dispose();
                        }
                    }
                }
            }

            // Save presentation (no modifications made, but required by rules)
            string savedPath = Path.Combine(Path.GetDirectoryName(inputPath), "Processed_" + Path.GetFileName(inputPath));
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}