using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Path to the external file to be linked
            var linkedFilePath = "sample.xlsx";
            // ProgID for Excel OLE object
            var className = "Excel.Sheet";

            // Add a linked OLE object frame covering the entire slide
            var oleFrame = slide.Shapes.AddOleObjectFrame(
                0,
                0,
                presentation.SlideSize.Size.Width,
                presentation.SlideSize.Size.Height,
                className,
                linkedFilePath);

            // Display the OLE object as an icon
            oleFrame.IsObjectIcon = true;

            // Save the presentation
            presentation.Save("LinkedOleObject_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}