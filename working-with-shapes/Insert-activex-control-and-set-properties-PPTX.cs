using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ActiveX control (Windows Media Player) to the slide
            Aspose.Slides.IControl control = slide.Controls.AddControl(
                Aspose.Slides.ControlType.WindowsMediaPlayer,
                100f,   // X position
                100f,   // Y position
                300f,   // Width
                50f);   // Height

            // Set the control's name
            control.Name = "MyMediaPlayer";

            // Adjust the control's frame (position, size, flip, rotation)
            Aspose.Slides.IShapeFrame newFrame = new Aspose.Slides.ShapeFrame(
                control.Frame.X,                     // X
                control.Frame.Y + 10f,               // Y (offset by 10 points)
                control.Frame.Width,                 // Width
                control.Frame.Height,                // Height
                Aspose.Slides.NullableBool.False,   // FlipH
                Aspose.Slides.NullableBool.False,   // FlipV
                control.Frame.Rotation);             // Rotation

            control.Frame = newFrame;

            // Save the presentation in PPTM format
            presentation.Save("ActiveXControl_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}