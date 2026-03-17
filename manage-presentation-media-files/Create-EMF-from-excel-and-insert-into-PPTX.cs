using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the EMF file generated from an Excel worksheet
            string emfPath = "worksheet.emf";
            byte[] emfData = File.ReadAllBytes(emfPath);

            // Create OLE embedded data info for the EMF file
            IOleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(emfData, "emf");

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an OLE object frame that contains the EMF data
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                    0,
                    0,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    embeddedData);

                // Display the OLE object as an image rather than an icon
                oleObjectFrame.IsObjectIcon = false;

                // Save the presentation
                presentation.Save("EmbeddedEmfPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}