using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];

            IGroupShape groupShape = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IGroupShape)
                {
                    groupShape = (IGroupShape)shape;
                    break;
                }
            }

            if (groupShape == null)
            {
                Console.WriteLine("No group shape found on the slide.");
                presentation.Dispose();
                return;
            }

            IShape clonedShape = slide.Shapes.AddClone(groupShape, groupShape.X + 100, groupShape.Y + 100);
            clonedShape.FillFormat.FillType = FillType.Solid;
            clonedShape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}