using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                using (presentation)
                {
                    ISlide titleSlide = presentation.Slides[0];

                    // Create a group shape on the title slide
                    IGroupShape group = titleSlide.Shapes.AddGroupShape();

                    // Add shapes to the group
                    group.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 50);
                    group.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 50);
                    group.Shapes.AddAutoShape(ShapeType.Triangle, 350, 50, 100, 50);

                    // Get the main animation sequence of the slide
                    ISequence mainSequence = titleSlide.Timeline.MainSequence;

                    // Apply a Fly animation to each shape in the group
                    foreach (IShape shape in group.Shapes)
                    {
                        mainSequence.AddEffect(shape, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.AfterPrevious);
                    }

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}