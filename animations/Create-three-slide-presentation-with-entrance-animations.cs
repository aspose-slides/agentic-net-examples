// -----------------------------------------------------------------------------
// Example: Create three slide presentation with entrance animations using C#
//
// Description:
// Demonstrates how to create a three‑slide PowerPoint presentation where each
// slide contains a rectangle shape with a different entrance animation (Appear,
// Fly, Zoom) using Aspose.Slides for .NET. The example shows creating a blank
// layout, adding shapes, applying animation effects, and saving the file as a
// PPTX document in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Three Slides, Entrance Animation,
// Appear, Fly, Zoom, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate a multi‑slide presentation with predefined entrance animations.
// - Automate PowerPoint content creation for training, marketing, or reporting.
// - Build .NET tools that programmatically add animation effects to slides.
// - Validate animation workflows before manual editing or publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get a blank layout slide (fallback to first layout if not found)
        var layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        if (layout == null)
        {
            layout = presentation.LayoutSlides[0];
        }

        // Slide 1 with Appear entrance animation
        var slide1 = presentation.Slides.AddEmptySlide(layout);
        var shape1 = slide1.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
        shape1.TextFrame.Text = "Slide 1 - Appear";
        slide1.Timeline.MainSequence.AddEffect(shape1,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Slide 2 with Fly entrance animation
        var slide2 = presentation.Slides.AddEmptySlide(layout);
        var shape2 = slide2.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
        shape2.TextFrame.Text = "Slide 2 - Fly";
        slide2.Timeline.MainSequence.AddEffect(shape2,
            Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Slide 3 with Zoom entrance animation
        var slide3 = presentation.Slides.AddEmptySlide(layout);
        var shape3 = slide3.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
        shape3.TextFrame.Text = "Slide 3 - Zoom";
        slide3.Timeline.MainSequence.AddEffect(shape3,
            Aspose.Slides.Animation.EffectType.Zoom,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Save the presentation
        presentation.Save("ThreeSlideAnimations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
