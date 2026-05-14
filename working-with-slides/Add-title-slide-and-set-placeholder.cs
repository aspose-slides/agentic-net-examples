using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Output file path
        string outputPath = "TitleSlide.pptx";

        // Get the layout slides collection from the first master slide
        Aspose.Slides.IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;

        // Try to obtain a Title layout; fallback to TitleOnly or Blank if not found
        Aspose.Slides.ILayoutSlide layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title) ??
                                                layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleOnly);
        if (layoutSlide == null)
        {
            layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        }

        // Insert a new empty slide at position 0 using the selected layout
        Aspose.Slides.ISlide slide = presentation.Slides.InsertEmptySlide(0, layoutSlide);

        // Set the title placeholder text programmatically
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                {
                    text = "My Presentation Title";
                }
                if (text != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                }
            }
        }

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}