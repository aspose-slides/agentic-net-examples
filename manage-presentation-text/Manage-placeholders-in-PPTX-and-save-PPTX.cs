using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Replace text in all placeholders on the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Updated Placeholder Text";
                }
            }

            // Add a new text placeholder to a blank layout slide
            Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;
            placeholderManager.AddTextPlaceholder(20, 20, 500, 300);

            // Remove notes from the first slide
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
            notesManager.RemoveNotesSlide();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}