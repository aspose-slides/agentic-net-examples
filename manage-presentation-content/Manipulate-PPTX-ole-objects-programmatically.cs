using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace ManipulateOleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, OLE source file, icon, output presentation and extraction folder
            string inputPresentationPath = "input.pptx";
            string oleSourceFilePath = "sample.xlsx";
            string iconFilePath = "icon.png";
            string outputPresentationPath = "output.pptx";
            string extractionFolder = "Extracted";

            try
            {
                // Ensure extraction folder exists
                if (!Directory.Exists(extractionFolder))
                {
                    Directory.CreateDirectory(extractionFolder);
                }

                // Load the presentation
                using (Presentation pres = new Presentation(inputPresentationPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Read OLE source file bytes
                    byte[] oleFileBytes = File.ReadAllBytes(oleSourceFilePath);

                    // Create embedded data info (correct namespace Aspose.Slides.DOM.Ole)
                    IOleEmbeddedDataInfo oleDataInfo = new OleEmbeddedDataInfo(oleFileBytes, "xlsx");

                    // Add OLE object frame covering the whole slide
                    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, oleDataInfo);

                    // Set the object to be displayed as an icon
                    oleObjectFrame.IsObjectIcon = true;

                    // Substitute the icon picture
                    byte[] iconBytes = File.ReadAllBytes(iconFilePath);
                    using (MemoryStream iconStream = new MemoryStream(iconBytes))
                    {
                        IPPImage iconImage = pres.Images.AddImage(Aspose.Slides.Images.FromStream(iconStream));
                        oleObjectFrame.SubstitutePictureFormat.Picture.Image = iconImage;
                    }

                    // Set a custom title for the icon
                    oleObjectFrame.SubstitutePictureTitle = "Embedded Excel File";

                    // -----------------------------------------------------------------
                    // Extraction of all embedded OLE objects from the presentation
                    // -----------------------------------------------------------------
                    int fileIndex = 0;
                    foreach (ISlide sld in pres.Slides)
                    {
                        foreach (IShape shape in sld.Shapes)
                        {
                            if (shape is OleObjectFrame)
                            {
                                OleObjectFrame existingOle = shape as OleObjectFrame;
                                byte[] embeddedData = existingOle.EmbeddedData.EmbeddedFileData;
                                string fileExtension = existingOle.EmbeddedData.EmbeddedFileExtension;
                                string extractedFilePath = Path.Combine(extractionFolder, "Extracted_" + fileIndex + fileExtension);
                                using (FileStream fs = new FileStream(extractedFilePath, FileMode.Create, FileAccess.Write))
                                {
                                    fs.Write(embeddedData, 0, embeddedData.Length);
                                }
                                fileIndex++;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}