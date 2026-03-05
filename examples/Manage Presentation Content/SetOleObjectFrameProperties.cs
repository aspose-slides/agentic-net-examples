using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load an existing PPT presentation that contains a linked OLE object
        string inputPath = "LinkedOleObject.ppt";
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Cast the first shape on the slide to OleObjectFrame
        Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes[0] as Aspose.Slides.OleObjectFrame;

        if (oleFrame != null)
        {
            // Read linked OLE object properties
            Console.WriteLine("Is linked: " + oleFrame.IsObjectLink);
            Console.WriteLine("Relative path: " + oleFrame.LinkPathRelative);
            Console.WriteLine("Long path: " + oleFrame.LinkPathLong);
            Console.WriteLine("Update automatically: " + oleFrame.UpdateAutomatic);

            // Modify writable properties
            oleFrame.LinkPathLong = "C:\\NewFolder\\NewLinkedFile.xlsx";
            oleFrame.UpdateAutomatic = false;
        }

        // Save the modified presentation in PPT format
        string outputPath = "LinkedOleObject_modified.ppt";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}