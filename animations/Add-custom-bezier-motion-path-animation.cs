// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add custom bezier motion path animation using C#

//

// Description:

// Demonstrates how to add a custom Bezier motion path animation to a shape 

// using Aspose.Slides for .NET. The example creates a presentation, adds a 

// rectangle with text, defines a Bezier curve motion path, and saves the 

// result as a PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Bezier, Motion Path, 

// Animation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding custom Bezier motion path animations to PowerPoint slides.

// - Build C# tools for advanced animation scripting in presentations.

// - Generate or modify PPTX files with custom motion paths in .NET applications.

// - Validate and test animation workflows before deployment.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main()

    {

        // Create a new presentation

        var pres = new Presentation();



        // Add a rectangle shape with text

        var rect = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

        rect.AddTextFrame("Motion Path");



        // Add a motion path effect to the shape

        var effect = pres.Slides[0].Timeline.MainSequence.AddEffect(

            rect,

            Aspose.Slides.Animation.EffectType.PathUser,

            Aspose.Slides.Animation.EffectSubtype.None,

            Aspose.Slides.Animation.EffectTriggerType.OnClick);



        // Get the motion effect behavior

        var motionEffect = (Aspose.Slides.Animation.IMotionEffect)effect.Behaviors[0];



        // Define Bezier curve control points

        PointF[] bezierPoints = new PointF[3];

        bezierPoints[0] = new PointF(0, 0);          // First control point

        bezierPoints[1] = new PointF(100, -50);     // Second control point

        bezierPoints[2] = new PointF(200, 0);       // End point



        // Start the motion path at the shape's current position

        motionEffect.Path.Add(

            Aspose.Slides.Animation.MotionCommandPathType.MoveTo,

            new PointF[] { new PointF(0, 0) },

            Aspose.Slides.Animation.MotionPathPointsType.Auto,

            false);



        // Add a Bezier curve segment

        motionEffect.Path.Add(

            Aspose.Slides.Animation.MotionCommandPathType.CurveTo,

            bezierPoints,

            Aspose.Slides.Animation.MotionPathPointsType.CurveSmooth,

            false);



        // End the motion path

        motionEffect.Path.Add(

            Aspose.Slides.Animation.MotionCommandPathType.End,

            null,

            Aspose.Slides.Animation.MotionPathPointsType.Auto,

            false);



        // Save the presentation

        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "MotionPathBezier.pptx");

        try

        {

            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }



        pres.Dispose();

    }

}

