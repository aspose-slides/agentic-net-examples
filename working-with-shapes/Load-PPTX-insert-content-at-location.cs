using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Assuming the first shape is an AutoShape with a TextFrame
                    Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

                        // Create a new portion
                        Aspose.Slides.Portion newPortion = new Aspose.Slides.Portion();
                        newPortion.Text = "Inserted Portion";

                        // Insert the new portion at index 0
                        paragraph.Portions.Insert(0, newPortion);
                    }

                    // Save the presentation
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