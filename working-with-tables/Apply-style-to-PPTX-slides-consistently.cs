using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace ApplyStyleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "styled_output.pptx";

                Aspose.Slides.Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                for (int i = 0; i < slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = slides[i];

                    // Set a solid light gray background for each slide
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;

                    // Apply consistent text formatting to all AutoShapes on the slide
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = shapes[j];
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                for (int p = 0; p < autoShape.TextFrame.Paragraphs.Count; p++)
                                {
                                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[p];
                                    for (int po = 0; po < paragraph.Portions.Count; po++)
                                    {
                                        Aspose.Slides.IPortion portion = paragraph.Portions[po];
                                        portion.PortionFormat.FontHeight = 14;
                                        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the presentation with the applied style
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}