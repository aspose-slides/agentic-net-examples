using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Modify normal view properties
        presentation.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
        presentation.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
        presentation.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
        presentation.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
        presentation.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

        // Modify slide and notes view zoom
        presentation.ViewProperties.SlideViewProperties.Scale = 100;
        presentation.ViewProperties.NotesViewProperties.Scale = 100;

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}