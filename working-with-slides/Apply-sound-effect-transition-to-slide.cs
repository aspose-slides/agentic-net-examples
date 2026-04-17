using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplySoundEffectTransition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the source presentation, sound file and output presentation
            string presPath = "input.pptx";
            string soundPath = "transition.wav";
            string outPath = "output.pptx";

            // Verify that the source presentation exists
            if (!File.Exists(presPath))
            {
                Console.WriteLine("Presentation file not found: " + presPath);
                return;
            }

            // Verify that the sound file exists
            if (!File.Exists(soundPath))
            {
                Console.WriteLine("Sound file not found: " + soundPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presPath))
                {
                    // Add the sound file to the presentation's audio collection
                    Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(soundPath));

                    // Get the first slide (or any slide you wish to modify)
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Access the slide's transition object
                    Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;

                    // Assign the embedded audio to the transition
                    transition.Sound = audio;

                    // Optional: set a human‑readable name for the sound
                    transition.SoundName = Path.GetFileName(soundPath);

                    // Optional: define how the sound should be played during the transition
                    transition.SoundMode = Aspose.Slides.SlideShow.TransitionSoundMode.StartSound;

                    // Save the modified presentation
                    pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved with custom transition sound: " + outPath);
            }
            catch (Aspose.Slides.PptxException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, permission issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}