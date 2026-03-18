using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace OleEmbeddingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Load the Office file to embed (e.g., an Excel workbook)
                byte[] fileData = File.ReadAllBytes("sample.xlsx");

                // Create OLE embedded data info
                IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

                // Add an OLE object frame to the slide
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                    50f,    // X position
                    50f,    // Y position
                    400f,   // Width
                    300f,   // Height
                    dataInfo);

                // Optionally set additional properties (e.g., display as icon)
                oleObjectFrame.IsObjectIcon = false;

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}