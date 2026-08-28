// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set click trigger for shape animation using C#

//

// Description:

// Demonstrates how to add a rectangle shape to a slide and assign an

// OnClick animation trigger using Aspose.Slides for .NET. The example creates

// a new presentation, adds a shape, applies an Appear effect with a click

// trigger, and saves the result as a PPTX file. This pattern can be used to

// automate PowerPoint animation workflows in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Click Trigger, Shape Animation,

// Timeline, Effect, Presentation Automation, Office Automation

//

// Use Cases:

// - Programmatically set click-triggered animations for shapes.

// - Build C# utilities for PowerPoint presentation creation or modification.

// - Generate PPTX files with custom animation sequences.

// - Validate animation settings before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace AnimationTriggerExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            Presentation presentation = new Presentation();



            // Add a rectangle shape to the first slide

            IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);



            // Add an animation effect to the shape with OnClick trigger

            IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(

                shape,

                EffectType.Appear,

                EffectSubtype.None,

                EffectTriggerType.OnClick);



            // Save the presentation

            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "AnimationTrigger.pptx");

            presentation.Save(outputPath, SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}

