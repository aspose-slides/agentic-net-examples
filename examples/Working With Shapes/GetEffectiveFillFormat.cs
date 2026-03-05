using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Load an existing presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("MyPresentation.pptx");

            // Get the first shape on the first slide
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

            // Retrieve effective fill format with inheritance applied
            Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

            // Output basic fill type information
            Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);

            // Output additional details based on fill type
            switch (effectiveFill.FillType)
            {
                case Aspose.Slides.FillType.Solid:
                    Console.WriteLine("Solid Fill Color: " + effectiveFill.SolidFillColor);
                    break;
                case Aspose.Slides.FillType.Pattern:
                    Console.WriteLine("Pattern Style: " + effectiveFill.PatternFormat.PatternStyle);
                    Console.WriteLine("Fore Color: " + effectiveFill.PatternFormat.ForeColor);
                    Console.WriteLine("Back Color: " + effectiveFill.PatternFormat.BackColor);
                    break;
                case Aspose.Slides.FillType.Gradient:
                    Console.WriteLine("Gradient Direction: " + effectiveFill.GradientFormat.GradientDirection);
                    Console.WriteLine("Gradient Stops Count: " + effectiveFill.GradientFormat.GradientStops.Count);
                    break;
                case Aspose.Slides.FillType.Picture:
                    Console.WriteLine("Picture Width: " + effectiveFill.PictureFillFormat.Picture.Image.Width);
                    Console.WriteLine("Picture Height: " + effectiveFill.PictureFillFormat.Picture.Image.Height);
                    break;
            }

            // Save the presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}