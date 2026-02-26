using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the presentation and the file to embed
        string presentationPath = "EmbeddedFilePresentation.pptx";
        string outputPath = "EmbeddedFilePresentation.ppt";
        string oleFilePath = "sample.xlsx";

        // Create a new presentation (contains one empty slide)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an OLE object frame that embeds the Excel file.
        // "Excel.Sheet" is the ProgID for Excel files.
        Aspose.Slides.IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(
            50,    // X position
            50,    // Y position
            400,   // Width
            300,   // Height
            "Excel.Sheet", // ProgID of the OLE object
            oleFilePath    // Path to the file to embed
        );

        // Save the presentation in PPT format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Clean up resources
        presentation.Dispose();
    }
}