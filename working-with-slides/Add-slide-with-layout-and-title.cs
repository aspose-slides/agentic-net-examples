using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get a Title layout slide; fallback to TitleOnly or Blank if not available
        Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
        if (layout == null)
        {
            layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleOnly);
        }
        if (layout == null)
        {
            layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        }

        // Add a new slide based on the selected layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layout);

        // Dynamic title text
        string dynamicTitle = "Dynamic Slide Title";

        // Populate the title placeholder with the dynamic text
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle ||
                    shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
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
        string outputPath = "OutputPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}