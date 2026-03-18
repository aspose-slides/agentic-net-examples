using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get reference to the first slide
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Add a rectangle AutoShape to the first slide
                Aspose.Slides.IAutoShape rectangleShape = (Aspose.Slides.IAutoShape)firstSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Add a TextFrame with initial text
                rectangleShape.AddTextFrame("First Slide");

                // Configure transition for the first slide
                firstSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                firstSlide.SlideShowTransition.AdvanceOnClick = true;
                firstSlide.SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
                firstSlide.SlideShowTransition.Duration = 2000; // 2 seconds

                // Clone the first slide to create a second slide
                Aspose.Slides.ISlide secondSlide = presentation.Slides.AddClone(firstSlide);

                // Modify the rectangle shape on the second slide (move and resize)
                Aspose.Slides.IShape clonedShape = secondSlide.Shapes[0];
                clonedShape.X += 50;
                clonedShape.Y += 50;
                clonedShape.Width -= 20;
                clonedShape.Height -= 20;

                // Configure a Morph transition for the second slide
                secondSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;
                secondSlide.SlideShowTransition.AdvanceOnClick = true;
                secondSlide.SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
                secondSlide.SlideShowTransition.Duration = 2500; // 2.5 seconds

                // Save the presentation
                string outputPath = "CustomTransitions.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}