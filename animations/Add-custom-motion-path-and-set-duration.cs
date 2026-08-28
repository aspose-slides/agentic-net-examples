// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add custom motion path and set duration using C#

//

// Description:

// Demonstrates how to add a custom motion path to a shape and set the animation

// duration using C# and Aspose.Slides for .NET. The example creates a new

// presentation, inserts a rectangle, applies a user-defined motion path effect,

// configures its duration, and saves the result as a PPTX file. This pattern can

// be used to automate PowerPoint animation creation in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Motion Path, Duration,

// Animation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding custom motion paths and setting animation durations.

// - Build C# tools for PowerPoint animation processing.

// - Generate or modify PPTX files with custom animations in .NET applications.

// - Validate and test presentation workflows before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



        // Get the first slide

        Aspose.Slides.ISlide slide = presentation.Slides[0];



        // Add a rectangle shape to the slide

        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);



        // Add a custom motion path effect to the shape

        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(

            shape,

            Aspose.Slides.Animation.EffectType.PathUser,

            Aspose.Slides.Animation.EffectSubtype.None,

            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);



        // Set animation duration to three seconds (3000 milliseconds)

        effect.Timing.Duration = 3000;



        // Get the motion effect behavior from the effect

        Aspose.Slides.Animation.IMotionEffect motionEffect = (Aspose.Slides.Animation.IMotionEffect)effect.Behaviors[0];



        // Define a custom motion path (line to a point)

        System.Drawing.PointF[] points = new System.Drawing.PointF[1];

        points[0] = new System.Drawing.PointF(300, 0);

        motionEffect.Path.Add(

            Aspose.Slides.Animation.MotionCommandPathType.LineTo,

            points,

            Aspose.Slides.Animation.MotionPathPointsType.Auto,

            true);



        // Save the presentation

        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomMotionPath.pptx");

        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        presentation.Dispose();

    }

}

