using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open the PPTX file as a stream
            FileStream inputStream = new FileStream("input.pptx", FileMode.Open, FileAccess.Read);
            // Initialize presentation from the stream
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputStream);
            // Close the input stream as it is no longer needed
            inputStream.Close();

            // Save the presentation to a new file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}