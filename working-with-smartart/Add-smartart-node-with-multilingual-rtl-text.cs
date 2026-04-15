using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set default text language to Arabic (right‑to‑left)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "ar-SA";

            // Create a new presentation with the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);
            try
            {
                // Add a SmartArt diagram (Basic Cycle layout) to the first slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                    10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

                // Enable right‑to‑left rendering for the SmartArt diagram
                smartArt.IsReversed = true;

                // Add a new node to the SmartArt diagram
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

                // Set multilingual text (English, Hebrew, Arabic) on the node
                node.TextFrame.Text = "Hello שלום مرحبا";

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other exception: ex.Message
            }
            finally
            {
                // Ensure the presentation is properly disposed
                presentation.Dispose();
            }
        }
    }
}