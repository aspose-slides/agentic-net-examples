using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Paths to the input presentation, output presentation, and new Excel file
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string newExcelPath = "newData.xlsx";

        // Verify that the required files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found: " + inputPath);
            return;
        }
        if (!File.Exists(newExcelPath))
        {
            Console.WriteLine("New Excel file not found: " + newExcelPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            // Collect shapes to be removed after iteration
            List<Aspose.Slides.IShape> shapesToRemove = new List<Aspose.Slides.IShape>();

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Cast shape to OleObjectFrame if possible
                Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;
                if (oleFrame != null)
                {
                    // Check if the embedded OLE object is an Excel worksheet
                    if (oleFrame.EmbeddedData != null &&
                        oleFrame.EmbeddedData.EmbeddedFileExtension.Equals("xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        // Rename the OLE object
                        oleFrame.ObjectName = "RenamedWorksheet";

                        // Replace the embedded Excel data with a new file
                        byte[] newExcelBytes = File.ReadAllBytes(newExcelPath);
                        Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo newDataInfo =
                            new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(newExcelBytes, "xlsx");
                        oleFrame.SetEmbeddedData(newDataInfo);

                        // Example: mark the OLE object for deletion (uncomment to delete)
                        // shapesToRemove.Add(oleFrame);
                    }
                }
            }

            // Remove any shapes that were marked for deletion
            foreach (Aspose.Slides.IShape shapeToRemove in shapesToRemove)
            {
                slide.Shapes.Remove(shapeToRemove);
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}