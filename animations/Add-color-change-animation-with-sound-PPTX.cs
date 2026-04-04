using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output presentation and audio file
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string audioPath = "sound.wav";

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation pres = null;
        if (File.Exists(inputPath))
        {
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                return;
            }
        }
        else
        {
            pres = new Aspose.Slides.Presentation();
        }

        // Ensure the presentation is disposed after use
        using (pres)
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f, 100f, 200f, 100f);
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Add a color change animation (ChangeFillColor) to the shape
            Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.ChangeFillColor,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Set the after‑animation type to Color and define the target color
            effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.Color;
            effect.AfterAnimationColor.Color = System.Drawing.Color.Green;

            // If the audio file exists, embed it and associate it with the effect
            if (File.Exists(audioPath))
            {
                byte[] audioBytes = File.ReadAllBytes(audioPath);
                Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioBytes);
                effect.Sound = audio;
                // Optionally stop any previous sound when this effect starts
                // effect.StopPreviousSound = true;
            }

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}