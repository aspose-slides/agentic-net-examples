// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set easing curve for animation acceleration using C#

//

// Description:

// Demonstrates how to set easing curve for animation acceleration using C# and 

// Aspose.Slides for .NET. The example creates a presentation, adds a rectangle 

// shape with text, applies a FloatUp animation effect, and configures the 

// acceleration and deceleration timing properties to achieve smooth easing. 

// The resulting PPTX file is saved to the local file system.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Easing, Curve, Animation, 

// Acceleration, Deceleration, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting easing curves for animation acceleration and deceleration.

// - Build C# tools for PowerPoint presentation processing with custom animation timing.

// - Generate or transform PPTX files in .NET applications with specific animation effects.

// - Validate animation workflows before publishing or integration.

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

        // Create a new presentation

        Presentation presentation = new Presentation();



        // Get the first slide

        ISlide slide = presentation.Slides[0];



        // Add a rectangle shape with text

        IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

        rect.AddTextFrame("Animated Text");



        // Add a FloatUp effect to the shape

        IEffect effect = slide.Timeline.MainSequence.AddEffect(

            rect,

            EffectType.FloatUp,

            EffectSubtype.None,

            EffectTriggerType.AfterPrevious);



        // Configure acceleration and deceleration for smooth easing

        effect.Timing.Accelerate = 0.3f; // 30% accelerate

        effect.Timing.Decelerate = 0.3f; // 30% decelerate



        // Save the presentation

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EasingAnimation.pptx");

        try

        {

            presentation.Save(outputPath, SaveFormat.Pptx);

        }

        catch (Exception)

        {

            // Format not supported or other error handling

        }



        // Dispose the presentation

        presentation.Dispose();

    }

}

