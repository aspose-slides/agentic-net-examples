using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    Aspose.Slides.IAutoShape targetShape = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                targetShape = autoShape;
                                break;
                            }
                        }
                    }

                    if (targetShape != null)
                    {
                        Aspose.Slides.ITextFrame textFrame = targetShape.TextFrame;

                        Aspose.Slides.IParagraph newParagraph = new Aspose.Slides.Paragraph();
                        Aspose.Slides.IPortion newPortion = new Aspose.Slides.Portion();
                        newPortion.Text = "New paragraph added.";
                        newParagraph.Portions.Add(newPortion);

                        textFrame.Paragraphs.Add(newParagraph);
                    }

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}