using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Reflection;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            IShape shape = slide.Shapes[0];

            PropertyInfo flipProp = shape.GetType().GetProperty("FlipH");
            if (flipProp != null && flipProp.CanWrite == false)
            {
                flipProp.SetValue(shape, Aspose.Slides.NullableBool.True, null);
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}