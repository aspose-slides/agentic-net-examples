using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string outputPath = "output.pptx";
        string soundPath = "transition.wav";

        // Verify input files exist
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        if (!File.Exists(soundPath))
        {
            Console.WriteLine("Sound file not found.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Add the sound to the presentation's audio collection
                IAudio transitionAudio = pres.Audios.AddAudio(File.ReadAllBytes(soundPath));

                // Configure a custom transition with the embedded sound on the first slide
                ISlideShowTransition transition = pres.Slides[0].SlideShowTransition;
                transition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                transition.Sound = transitionAudio;
                transition.SoundName = "CustomTransitionSound";

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}