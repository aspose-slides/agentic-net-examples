using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get a Title layout slide (fallback to Blank if not found)
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
        if (layoutSlide == null)
        {
            layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        }

        // Add a new slide based on the selected layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Dynamic title text
        string dynamicTitle = "Dynamic Slide Title";

        // Populate the title placeholder with dynamic text
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                {
                    text = dynamicTitle;
                }
                else if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                {
                    text = dynamicTitle;
                }

                if (text != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                }
            }
        }

        // Save the presentation
        string outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}