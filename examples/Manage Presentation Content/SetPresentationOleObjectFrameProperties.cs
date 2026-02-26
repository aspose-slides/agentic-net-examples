using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load an existing PPT presentation that contains a linked OLE object
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("LinkedOleObject.ppt");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Cast the first shape on the slide to OleObjectFrame
        Aspose.Slides.OleObjectFrame oleObjectFrame = slide.Shapes[0] as Aspose.Slides.OleObjectFrame;

        if (oleObjectFrame != null)
        {
            // Read linked OLE object properties
            Console.WriteLine("IsObjectLink: " + oleObjectFrame.IsObjectLink);
            Console.WriteLine("LinkPathRelative: " + oleObjectFrame.LinkPathRelative);
            Console.WriteLine("LinkPathLong (current): " + oleObjectFrame.LinkPathLong);
            Console.WriteLine("UpdateAutomatic (current): " + oleObjectFrame.UpdateAutomatic);

            // Modify writable properties
            oleObjectFrame.LinkPathLong = @"C:\NewFolder\NewLinkedFile.xlsx";
            oleObjectFrame.UpdateAutomatic = false;
        }

        // Save the modified presentation in PPT format
        presentation.Save("LinkedOleObject_modified.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}