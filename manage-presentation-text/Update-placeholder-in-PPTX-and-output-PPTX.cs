using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Find all title placeholders on the slide
                System.Collections.Generic.IList<Aspose.Slides.IShape> titlePlaceholders = Aspose.Slides.Util.SlideUtil.FindShapesByPlaceholderType(slide, Aspose.Slides.PlaceholderType.Title);

                // Update text of each title placeholder
                foreach (Aspose.Slides.IShape shape in titlePlaceholders)
                {
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            autoShape.TextFrame.Text = "Updated Title";
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}