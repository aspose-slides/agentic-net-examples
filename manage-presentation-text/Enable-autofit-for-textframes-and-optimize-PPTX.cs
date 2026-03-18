using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AutoFitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a sample shape with text to demonstrate autofit
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("This is a long text that will demonstrate the autofit functionality of the text frame.");

                // Retrieve all text frames in the presentation (including masters)
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

                // Apply autofit mode to each text frame
                foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                {
                    // Set autofit to shrink text on overflow (Normal)
                    textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;
                }

                // Save the presentation
                presentation.Save("AutoFitOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}