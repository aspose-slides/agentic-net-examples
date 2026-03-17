using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace AsposeSlidesBlobDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";
                string extractDir = "ExtractedOle";

                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    // Ensure extraction directory exists
                    if (!Directory.Exists(extractDir))
                    {
                        Directory.CreateDirectory(extractDir);
                    }

                    int fileIndex = 0;

                    // Extract embedded OLE objects
                    foreach (Aspose.Slides.ISlide slide in pres.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.OleObjectFrame)
                            {
                                Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;
                                byte[] embeddedBytes = oleFrame.EmbeddedData.EmbeddedFileData;
                                string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                                string outFile = Path.Combine(extractDir, "ole_" + fileIndex + extension);
                                using (FileStream fs = new FileStream(outFile, FileMode.Create, FileAccess.Write))
                                {
                                    fs.Write(embeddedBytes, 0, embeddedBytes.Length);
                                }
                                fileIndex++;
                            }
                        }
                    }

                    // Insert a new OLE object into the first slide
                    Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                    byte[] newOleBytes = File.ReadAllBytes("newfile.pdf");
                    Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo newOleInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(newOleBytes, "pdf");
                    Aspose.Slides.IOleObjectFrame newOleObject = firstSlide.Shapes.AddOleObjectFrame(50f, 50f, 200f, 200f, newOleInfo);
                    newOleObject.IsObjectIcon = true;

                    // Modify the first existing OLE object (replace its data)
                    foreach (Aspose.Slides.IShape shape in firstSlide.Shapes)
                    {
                        if (shape is Aspose.Slides.OleObjectFrame)
                        {
                            Aspose.Slides.OleObjectFrame oleToReplace = shape as Aspose.Slides.OleObjectFrame;
                            byte[] replacementBytes = File.ReadAllBytes("replace.docx");
                            Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo replacementInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(replacementBytes, "docx");
                            oleToReplace.SetEmbeddedData(replacementInfo);
                            oleToReplace.SubstitutePictureTitle = "Replaced Document";
                            break;
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}