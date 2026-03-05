using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";
        // Path to the output PPTX file
        string outputPath = "output.pptx";

        // Open a file stream for reading the presentation
        FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);

        // Create load options and specify the format explicitly
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.LoadFormat = Aspose.Slides.LoadFormat.Pptx;

        // Load the presentation from the stream using the load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputStream, loadOptions);

        // Close the input stream (the presentation has already loaded the data)
        inputStream.Close();

        // Save the loaded presentation to a new file
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}