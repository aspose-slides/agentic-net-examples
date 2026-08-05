// -----------------------------------------------------------------------------
// Example: Apply random transition to each slide using C#
//
// Description:
// Demonstrates how to create a presentation, add slides, and assign a random
// slide transition to each slide while ensuring that consecutive slides do not
// share the same transition type. The example uses Aspose.Slides for .NET to
// build a PPTX file in a console application.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Random Transition, SlideShow, Presentation Processing, .NET
//
// Use Cases:
// - Generate a PPTX with varied slide transitions for presentations.
// - Automate slide transition assignment in bulk PowerPoint files.
// - Build .NET tools that customize slide show behavior programmatically.
// - Ensure visual variety by avoiding repeated transition types.
// -----------------------------------------------------------------------------
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
