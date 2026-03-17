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
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide firstSlide = presentation.Slides[0];

                // Add a title shape to the first slide
                IAutoShape titleShape = (IAutoShape)firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 50);
                titleShape.AddTextFrame("Presentation Overview");

                // Add a second slide based on the layout of the first slide
                ISlide secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);
                IAutoShape contentShape = (IAutoShape)secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 600, 50);
                contentShape.AddTextFrame("Second Slide Content");

                // Extract and display a simple content overview
                Console.WriteLine("Presentation Overview:");
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    Console.WriteLine($"Slide {i + 1}:");
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            string text = autoShape.TextFrame.Text;
                            if (!string.IsNullOrEmpty(text))
                            {
                                Console.WriteLine($" - Shape Text: {text}");
                            }
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}