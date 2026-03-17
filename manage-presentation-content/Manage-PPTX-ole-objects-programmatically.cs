using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OleObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the source file to embed and the icon image
                string sourceFilePath = "sample.xlsx";
                string iconFilePath = "icon.png";

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Read the source file bytes
                    byte[] sourceBytes = File.ReadAllBytes(sourceFilePath);

                    // Create OLE embedded data info (correct namespace)
                    IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(sourceBytes, "xlsx");

                    // Add an OLE object frame to the slide
                    IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(50f, 50f, 300f, 200f, dataInfo);

                    // Set the object to be displayed as an icon
                    oleObject.IsObjectIcon = true;

                    // Read the icon image bytes
                    byte[] iconBytes = File.ReadAllBytes(iconFilePath);
                    using (MemoryStream ms = new MemoryStream(iconBytes))
                    {
                        // Add the image to the presentation's image collection
                        IPPImage image = pres.Images.AddImage(Aspose.Slides.Images.FromStream(ms));

                        // Set the substitute picture for the OLE object icon
                        oleObject.SubstitutePictureFormat.Picture.Image = image;
                    }

                    // Set a title for the OLE object icon
                    oleObject.SubstitutePictureTitle = "Embedded Excel File";

                    // Save the presentation
                    pres.Save("OleObjectWithIcon_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}