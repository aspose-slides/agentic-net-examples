using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Paths for input presentation, audio file and output presentation
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string inputPresentation = Path.Combine(dataDir, "input.pptx");
        string audioPath = Path.Combine(dataDir, "sound.wav");
        string outputPresentation = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the required files exist
        if (!File.Exists(inputPresentation))
        {
            Console.WriteLine("Input presentation not found: " + inputPresentation);
            return;
        }
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found: " + audioPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentation))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to the slide
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
                shape.TextFrame.Text = "Animated Shape";

                // Load the audio file into the presentation's audio collection
                Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(File.ReadAllBytes(audioPath));

                // Add a color change animation effect to the shape
                Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.ChangeFillColor,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Configure the effect to change the fill color to red after animation
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.Color;
                effect.AfterAnimationColor.Color = Color.Red;

                // Synchronize the effect with the sound
                effect.Sound = audio;

                // Save the modified presentation
                presentation.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}