using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);
                shape.AddTextFrame("All these columns are forced to stay within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container.");
                Aspose.Slides.TextFrameFormat format = (Aspose.Slides.TextFrameFormat)shape.TextFrame.TextFrameFormat;
                format.ColumnCount = 2;
                format.ColumnSpacing = 20;
                string outputPath = "ColumnsDemo.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}