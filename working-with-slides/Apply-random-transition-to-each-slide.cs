using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RandomSlideTransitions
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "RandomTransitions.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add additional slides (total 5 slides)
                for (int i = 0; i < 4; i++)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Define a set of transition types to choose from
                Aspose.Slides.SlideShow.TransitionType[] transitionTypes = new Aspose.Slides.SlideShow.TransitionType[]
                {
                    Aspose.Slides.SlideShow.TransitionType.Fade,
                    Aspose.Slides.SlideShow.TransitionType.Wipe,
                    Aspose.Slides.SlideShow.TransitionType.Zoom,
                    Aspose.Slides.SlideShow.TransitionType.Cut,
                    Aspose.Slides.SlideShow.TransitionType.Flip,
                    Aspose.Slides.SlideShow.TransitionType.Random
                };

                Random random = new Random();
                Aspose.Slides.SlideShow.TransitionType previousType = Aspose.Slides.SlideShow.TransitionType.None;

                // Apply random transitions ensuring no two consecutive slides share the same type
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.SlideShow.TransitionType selectedType;
                    do
                    {
                        selectedType = transitionTypes[random.Next(transitionTypes.Length)];
                    } while (selectedType == previousType);

                    presentation.Slides[i].SlideShowTransition.Type = selectedType;
                    presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;

                    previousType = selectedType;
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}