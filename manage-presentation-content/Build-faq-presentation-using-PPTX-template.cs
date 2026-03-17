using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FAQPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // First slide - Question 1
                ISlide slide1 = presentation.Slides[0];
                IAutoShape shape1 = (IAutoShape)slide1.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
                shape1.AddTextFrame("Q: What is Aspose.Slides?");
                shape1.TextFrame.Text = "A: A .NET library for working with PowerPoint files.";

                // Second slide - Question 2
                ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                IAutoShape shape2 = (IAutoShape)slide2.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
                shape2.AddTextFrame("Q: Which formats can be saved?");
                shape2.TextFrame.Text = "A: PPT, PPTX, PDF, XPS, HTML, and more.";

                // Third slide - Question 3
                ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                IAutoShape shape3 = (IAutoShape)slide3.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
                shape3.AddTextFrame("Q: How to save a presentation?");
                shape3.TextFrame.Text = "A: Use presentation.Save with Aspose.Slides.Export.SaveFormat.";

                // Save the presentation in PPTX format
                presentation.Save("FAQPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}