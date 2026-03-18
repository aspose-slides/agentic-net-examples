using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Iterate through all shapes on the slide
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];

                    // Process only AutoShapes that contain a text frame
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                            // Iterate through paragraphs and portions to apply formatting
                            for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                            {
                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[p];
                                for (int pr = 0; pr < paragraph.Portions.Count; pr++)
                                {
                                    Aspose.Slides.IPortion portion = paragraph.Portions[pr];
                                    Aspose.Slides.IPortionFormat format = portion.PortionFormat;

                                    // Apply bold, increase font size, and set font color to blue
                                    format.FontBold = Aspose.Slides.NullableBool.True;
                                    format.FontHeight = 24;
                                    format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    format.FillFormat.SolidFillColor.Color = Color.Blue;
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation as PPTX
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}