using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "shape_thumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Apply an animation to the shape
        pres.Slides[0].Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.PathFootball,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Generate thumbnail using Appearance bounds (includes animations)
        Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Appearance, 1f, 1f);
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        try
        {
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Clean up
        pres.Dispose();
    }
}