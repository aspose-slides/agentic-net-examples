using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the source presentation, linked OLE file, and output presentation
        string inputPresentationPath = "Template.pptx";
        string linkedFilePath = "Data.xlsx";
        string outputPresentationPath = "LinkedOleObject.pptx";

        // Verify that the source presentation exists
        if (!File.Exists(inputPresentationPath))
        {
            Console.WriteLine("Source presentation not found: " + inputPresentationPath);
            return;
        }

        // Verify that the file to be linked exists
        if (!File.Exists(linkedFilePath))
        {
            Console.WriteLine("Linked OLE file not found: " + linkedFilePath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPresentationPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a linked OLE object frame (Excel) to the slide
        // Class name for Excel OLE objects is "Excel.Sheet"
        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(50f, 50f, 400f, 300f, "Excel.Sheet", linkedFilePath);

        // Set additional properties if needed
        oleFrame.IsObjectIcon = false;          // Show the full object, not an icon
        oleFrame.UpdateAutomatic = true;        // Update the linked object automatically

        // Save the modified presentation
        pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}