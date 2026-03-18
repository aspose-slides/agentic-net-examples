using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageBulletsAndNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                            // Ensure there is at least one paragraph
                            if (textFrame.Paragraphs.Count > 0)
                            {
                                // Example: set all paragraphs to a numbered list
                                for (int i = 0; i < textFrame.Paragraphs.Count; i++)
                                {
                                    Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[i];
                                    paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                                    // Optional: set bullet start number
                                    paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)(i + 1);
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