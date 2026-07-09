using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                Aspose.Slides.ISlide srcSlide = pres.Slides[0];
                Aspose.Slides.ISlide destSlide;
                if (pres.Slides.Count > 1)
                {
                    destSlide = pres.Slides[1];
                }
                else
                {
                    Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                    destSlide = pres.Slides.AddEmptySlide(blankLayout);
                }

                Aspose.Slides.IShape srcShape = srcSlide.Shapes[0];
                Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(srcShape, srcShape.X, srcShape.Y, srcShape.Width, srcShape.Height);

                clonedShape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                clonedShape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                clonedShape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}