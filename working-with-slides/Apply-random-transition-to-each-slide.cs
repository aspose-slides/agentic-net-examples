using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or loading errors
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                presentation = new Presentation();
                // Add a few blank slides for demonstration
                for (int i = 0; i < 5; i++)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }
            }

            // Prepare random generator and list of transition types
            Random random = new Random();
            Aspose.Slides.SlideShow.TransitionType[] transitions = (Aspose.Slides.SlideShow.TransitionType[])Enum.GetValues(typeof(Aspose.Slides.SlideShow.TransitionType));

            Aspose.Slides.SlideShow.TransitionType previousTransition = Aspose.Slides.SlideShow.TransitionType.None;

            // Apply random transition to each slide ensuring no consecutive duplicates
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.SlideShow.TransitionType selected;
                do
                {
                    selected = transitions[random.Next(transitions.Length)];
                } while (selected == previousTransition || selected == Aspose.Slides.SlideShow.TransitionType.None);

                presentation.Slides[i].SlideShowTransition.Type = selected;
                presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                presentation.Slides[i].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

                previousTransition = selected;
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}