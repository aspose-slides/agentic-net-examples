using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyAutofit
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

                // Add a TextFrame to the shape
                shape.AddTextFrame(" ");

                // Access the TextFrame
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

                // Set Autofit type to Shape (shape will resize to fit text)
                textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

                // Access the first paragraph and portion
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = paragraph.Portions[0];

                // Set the text
                portion.Text = "AutoFit applied to this shape.";

                // Set black fill for the text
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

                // Define output path
                string outDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }
                string outPath = Path.Combine(outDir, "AutofitPresentation.pptx");

                // Save the presentation
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}