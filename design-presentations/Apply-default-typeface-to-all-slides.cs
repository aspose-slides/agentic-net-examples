using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDefaultTypeface
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Define the default typeface
                string defaultTypeface = "Arial";

                // Apply the default typeface to all existing text portions
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            for (int paragraphIndex = 0; paragraphIndex < autoShape.TextFrame.Paragraphs.Count; paragraphIndex++)
                            {
                                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];
                                for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                {
                                    Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(defaultTypeface);
                                }
                            }
                        }
                    }
                }

                // Add a new shape with text to demonstrate the default typeface for newly added content
                Aspose.Slides.IAutoShape newShape = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 150, 400, 100);
                newShape.AddTextFrame("This text uses the default typeface.");
                // Apply the default typeface to the newly added text
                Aspose.Slides.IParagraph newParagraph = newShape.TextFrame.Paragraphs[0];
                for (int portionIndex = 0; portionIndex < newParagraph.Portions.Count; portionIndex++)
                {
                    Aspose.Slides.IPortion portion = newParagraph.Portions[portionIndex];
                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(defaultTypeface);
                }

                // Configure save options with the default regular font
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.DefaultRegularFont = defaultTypeface;

                // Save the presentation
                presentation.Save("DefaultTypefacePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}