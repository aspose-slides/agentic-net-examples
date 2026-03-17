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

            // Get the master layout collection
            Aspose.Slides.IMasterLayoutSlideCollection masterLayouts = presentation.Masters[0].LayoutSlides;

            // Try to obtain a TitleAndObject layout; create if it doesn't exist
            Aspose.Slides.ILayoutSlide faqLayout = masterLayouts.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
            if (faqLayout == null)
            {
                faqLayout = masterLayouts.Add(Aspose.Slides.SlideLayoutType.TitleAndObject, "FAQLayout");
            }

            // Insert a new empty slide using the FAQ layout
            presentation.Slides.InsertEmptySlide(0, faqLayout);

            // Access the newly created slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a title shape
            Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
            titleShape.AddTextFrame("FAQ");
            titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

            // Add a content shape with FAQ items
            Aspose.Slides.IAutoShape contentShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 80, 600, 350);
            contentShape.AddTextFrame(
                "Q1: What is Aspose.Slides?\nA1: A .NET library for PowerPoint manipulation.\n\n" +
                "Q2: How to add text?\nA2: Use IAutoShape.AddTextFrame.");
            contentShape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

            // Save the presentation
            String outputPath = "FaqPresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}