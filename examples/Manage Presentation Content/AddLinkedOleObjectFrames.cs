using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddLinkedOleObjectFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Define the OLE object class name and the path to the linked file
            // Example: linking an Excel workbook
            string oleClassName = "Excel.Sheet";
            string linkedFilePath = @"C:\Temp\sample.xlsx";

            // Add a linked OLE object frame to the slide
            IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                50,    // X position (points)
                50,    // Y position (points)
                400,   // Width (points)
                300,   // Height (points)
                oleClassName,
                linkedFilePath);

            // Optional: display the OLE object as an icon
            oleObjectFrame.IsObjectIcon = false;

            // Save the presentation in PPT format
            string outputPath = Path.Combine(outDir, "LinkedOleObject.ppt");
            presentation.Save(outputPath, SaveFormat.Ppt);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}