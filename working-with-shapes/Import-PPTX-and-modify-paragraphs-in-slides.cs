using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        // Iterate through shapes
                        for (int j = 0; j < slide.Shapes.Count; j++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[j];
                            // Check if shape is an AutoShape with a TextFrame
                            if (shape is Aspose.Slides.IAutoShape)
                            {
                                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                                if (autoShape.TextFrame != null)
                                {
                                    // Iterate paragraphs
                                    for (int p = 0; p < autoShape.TextFrame.Paragraphs.Count; p++)
                                    {
                                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[p];
                                        // Modify each portion text to uppercase
                                        for (int pt = 0; pt < paragraph.Portions.Count; pt++)
                                        {
                                            Aspose.Slides.IPortion portion = paragraph.Portions[pt];
                                            string upper = portion.Text.ToUpperInvariant();
                                            portion.Text = upper;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}