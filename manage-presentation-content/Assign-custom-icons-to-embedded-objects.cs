using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace OleObjectIconExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, embedded file, custom icon and output presentation
            string presentationPath = "input.pptx";
            string embeddedFilePath = "sample.xlsx";
            string iconFilePath = "icon.png";
            string outputPath = "output.pptx";

            // Verify that required files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }
            if (!File.Exists(embeddedFilePath))
            {
                Console.WriteLine("Embedded file not found: " + embeddedFilePath);
                return;
            }
            if (!File.Exists(iconFilePath))
            {
                Console.WriteLine("Icon file not found: " + iconFilePath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(presentationPath);
            ISlide slide = pres.Slides[0];

            // Read the embedded file data
            byte[] embeddedData = File.ReadAllBytes(embeddedFilePath);
            // Create OLE embedded data info (using file extension without dot)
            OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(embeddedData, "xlsx");

            // Add an OLE object frame to the slide
            IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(50f, 50f, 400f, 300f, dataInfo);

            // Set the object to be displayed as an icon
            oleObject.IsObjectIcon = true;

            // Read the custom icon image data
            byte[] iconData = File.ReadAllBytes(iconFilePath);
            // Add the icon image to the presentation's image collection
            IPPImage iconImage = pres.Images.AddImage(iconData);

            // Assign the custom icon image to the OLE object
            oleObject.SubstitutePictureFormat.Picture.Image = iconImage;

            // Set a custom title for the icon
            oleObject.SubstitutePictureTitle = "Embedded Excel Data";

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}