using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the source OLE file and the output presentation
            string sourceFilePath = "sample.xlsx";
            string outputPath = "output.pptx";

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Read the OLE file data
                byte[] oleData = File.ReadAllBytes(sourceFilePath);

                // Create embedded data info (extension without dot)
                Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xlsx");

                // Define position and size (in points)
                float x = 100f;
                float y = 100f;
                float width = pres.SlideSize.Size.Width / 2f;
                float height = pres.SlideSize.Size.Height / 2f;

                // Add the OLE object frame to the slide
                Aspose.Slides.IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(x, y, width, height, dataInfo);

                // Set the object to display as an icon with a title
                oleObject.IsObjectIcon = true;
                oleObject.SubstitutePictureTitle = "Excel Data";

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}