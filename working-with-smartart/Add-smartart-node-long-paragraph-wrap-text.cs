using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smart = slide.Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes.AddNode();
            node.TextFrame.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            node.TextFrame.TextFrameFormat.WrapText = Aspose.Slides.NullableBool.True;
            presentation.Save("SmartArtWrapped.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}