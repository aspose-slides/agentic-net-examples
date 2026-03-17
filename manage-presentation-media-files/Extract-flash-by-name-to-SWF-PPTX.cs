using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace ExtractFlashObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Name of the flash object shape to extract
            string targetShapeName = "FlashObject1";

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            // Cast shape to OleObjectFrame
                            Aspose.Slides.OleObjectFrame oleObjectFrame = shape as Aspose.Slides.OleObjectFrame;
                            if (oleObjectFrame != null && oleObjectFrame.Name == targetShapeName)
                            {
                                // Get embedded OLE data
                                Aspose.Slides.IOleEmbeddedDataInfo embeddedInfo = oleObjectFrame.EmbeddedData;
                                if (embeddedInfo != null && string.Equals(embeddedInfo.EmbeddedFileExtension, "swf", StringComparison.OrdinalIgnoreCase))
                                {
                                    byte[] swfData = embeddedInfo.EmbeddedFileData;
                                    string outputFile = oleObjectFrame.Name + "." + embeddedInfo.EmbeddedFileExtension;
                                    // Write SWF data to disk
                                    using (FileStream fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                                    {
                                        fileStream.Write(swfData, 0, swfData.Length);
                                    }
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}