using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Load presentation with default load options (keep embedded objects)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = false;

            using (Presentation presentation = new Presentation("input.pptx", loadOptions))
            {
                // Iterate through slides and shapes to find OLE objects
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        OleObjectFrame oleFrame = shape as OleObjectFrame;
                        if (oleFrame != null)
                        {
                            // Read embedded OLE data
                            byte[] embeddedData = oleFrame.EmbeddedData.EmbeddedFileData;
                            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

                            // Example manipulation: replace the embedded data with the same content
                            IOleEmbeddedDataInfo newDataInfo = new OleEmbeddedDataInfo(embeddedData, fileExtension);
                            oleFrame.SetEmbeddedData(newDataInfo);
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}