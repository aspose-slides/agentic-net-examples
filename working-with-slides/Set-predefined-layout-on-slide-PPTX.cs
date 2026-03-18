using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first master slide
            Aspose.Slides.IMasterSlide master = presentation.Masters[0];

            // Add a new layout slide of type TitleOnly
            Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(master, Aspose.Slides.SlideLayoutType.TitleOnly, "CustomTitle");

            // Assign the custom layout to the slide
            slide.LayoutSlide = customLayout;

            // Update placeholder text (title placeholder)
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.IAutoShape && shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                {
                    Aspose.Slides.IAutoShape placeholder = (Aspose.Slides.IAutoShape)shape;
                    placeholder.TextFrame.Text = "New Title Text";
                    break;
                }
            }

            // Save the presentation
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}