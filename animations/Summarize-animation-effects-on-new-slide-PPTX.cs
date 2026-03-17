using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationSummaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for input and output presentations
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Add a new empty slide for the summary (using layout of first slide)
                    Aspose.Slides.ISlide summarySlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                    // Add a title shape
                    Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)summarySlide.Shapes.AddAutoShape(
                        ShapeType.Rectangle,
                        0,
                        0,
                        presentation.SlideSize.Size.Width,
                        50);
                    titleShape.AddTextFrame("Animation Effects Summary");
                    titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                    // Starting vertical position for bullet points
                    float currentY = 60f;

                    // Iterate through all slides and collect animation effects
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Access the animation timeline of the slide
                        Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;

                        // Get the main sequence of effects
                        Aspose.Slides.Animation.ISequence mainSequence = timeline.MainSequence;

                        // Iterate over each effect in the main sequence
                        for (int i = 0; i < mainSequence.Count; i++)
                        {
                            Aspose.Slides.Animation.IEffect effect = mainSequence[i];

                            // Prepare description text
                            string effectDescription = $"Slide {slide.SlideNumber}: {effect.Type}";

                            // Add a bullet shape with the description
                            Aspose.Slides.IAutoShape bulletShape = (Aspose.Slides.IAutoShape)summarySlide.Shapes.AddAutoShape(
                                ShapeType.Rectangle,
                                20,
                                currentY,
                                presentation.SlideSize.Size.Width - 40,
                                20);
                            bulletShape.AddTextFrame(effectDescription);

                            // Move to next line position
                            currentY += 25f;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}