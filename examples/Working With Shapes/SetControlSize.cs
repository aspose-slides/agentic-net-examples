using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output presentation paths
        string inputPath = Path.GetFullPath("input.pptm");
        string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptm");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first ActiveX control on the slide
        Aspose.Slides.IControl control = slide.Controls[0];

        // Desired new size for the control
        float newWidth = 200f;
        float newHeight = 100f;

        // Create a new frame with the new width and height (other properties remain unchanged)
        Aspose.Slides.IShapeFrame newFrame = new Aspose.Slides.ShapeFrame(
            control.Frame.X,
            control.Frame.Y,
            newWidth,
            newHeight,
            control.Frame.FlipH,
            control.Frame.FlipV,
            control.Frame.Rotation);

        // Assign the new frame to the control (Width/Height are read‑only on IShapeFrame, so we replace the frame)
        control.Frame = newFrame;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
    }
}