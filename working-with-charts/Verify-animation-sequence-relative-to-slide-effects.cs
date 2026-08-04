// -----------------------------------------------------------------------------
// Example: Verify animation sequence relative to slide effects using C#
//
// Description:
// Demonstrates how to verify animation sequence relative to slide effects 
// using C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Animation, Sequence, 
// Relative, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verify animation sequence relative to slide effects.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationSequenceVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Get first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape to animate
                IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50) as IAutoShape;
                rect.AddTextFrame("Animated Shape");

                // Add a new effect to the main sequence
                IEffect newEffect = slide.Timeline.MainSequence.AddEffect(
                    rect,
                    EffectType.Fly,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Verify that the newly added effect appears at the end of the sequence
                ISequence mainSeq = slide.Timeline.MainSequence;
                int effectCount = mainSeq.Count;
                IEffect lastEffect = mainSeq[effectCount - 1];

                if (lastEffect == newEffect)
                {
                    Console.WriteLine("The new effect is correctly positioned at the end of the sequence.");
                }
                else
                {
                    Console.WriteLine("The new effect is not at the expected position in the sequence.");
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}
