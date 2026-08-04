// -----------------------------------------------------------------------------
// Example: Dispose presentation isequence resources memory using C#
//
// Description:
// Demonstrates how to safely dispose Aspose.Slides Presentation objects while
// working with the slide animation ISequence (MainSequence). The example
// creates or loads a PPTX file, adds a simple fade animation to a shape, saves
// the result, and relies on using blocks to release unmanaged resources.
// This pattern is useful for managing memory when processing presentations
// that contain animation sequences.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Dispose, Presentation, ISequence,
// Animation, Resources, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure proper disposal of Presentation objects that contain animation sequences.
// - Build C# utilities that add or modify slide animations in PPTX files.
// - Automate PPTX creation or modification while preventing memory leaks.
// - Validate and test animation workflows in .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            // Create a new presentation when the file does not exist
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                var slide = pres.Slides[0];

                // Add a rectangle shape
                slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                // Retrieve the main animation sequence
                var mainSeq = slide.Timeline.MainSequence;

                // Add a simple fade effect to the shape
                var shape = slide.Shapes[0];
                mainSeq.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                // Presentation is disposed automatically by the using block
            }
        }
        else
        {
            // Load the existing presentation
            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    var slide = pres.Slides[0];

                    // Retrieve the main animation sequence
                    var mainSeq = slide.Timeline.MainSequence;

                    // Add an effect to the first shape if it exists
                    if (slide.Shapes.Count > 0)
                    {
                        var shape = slide.Shapes[0];
                        mainSeq.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                    // Presentation is disposed automatically by the using block
                }
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // The file format is not supported
                Console.WriteLine("The file format is not supported.");
            }
        }
    }
}
