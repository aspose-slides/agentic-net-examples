using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            // Ensure input file exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = pres.Slides[0];
                    Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();
                    group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 100, 100);
                    group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 120, 0, 100, 100);
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IGroupShape originalGroup = null;

                // Find the first group shape on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IGroupShape)
                    {
                        originalGroup = (Aspose.Slides.IGroupShape)shape;
                        break;
                    }
                }

                if (originalGroup != null)
                {
                    // Clone the group shape and offset its position
                    float offsetX = 200f;
                    float offsetY = 150f;
                    Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(
                        originalGroup,
                        originalGroup.X + offsetX,
                        originalGroup.Y + offsetY);

                    Aspose.Slides.IGroupShape clonedGroup = clonedShape as Aspose.Slides.IGroupShape;
                    if (clonedGroup != null && clonedGroup.FillFormat != null)
                    {
                        clonedGroup.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        clonedGroup.FillFormat.SolidFillColor.Color = Color.LightBlue;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported formats or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}