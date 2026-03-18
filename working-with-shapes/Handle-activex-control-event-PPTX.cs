using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape (placeholder for an ActiveX control)
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
                autoShape.AddTextFrame("ActiveX Placeholder");

                // Initialize the animations generator with the slide size
                PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation.SlideSize.Size.ToSize());

                // Subscribe to the NewAnimation event
                animationsGenerator.NewAnimation += delegate (IPresentationAnimationPlayer animationPlayer)
                {
                    Console.WriteLine("New animation generated. Duration: " + animationPlayer.Duration);
                };

                // Run the generator to raise the event
                animationsGenerator.Run(presentation.Slides);

                // Save the presentation
                presentation.Save("ActiveXEventExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}