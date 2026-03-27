using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace InsertExternalFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external file to embed (e.g., a PDF)
            string externalFilePath = "sample.pdf";

            // Verify that the external file exists
            if (!File.Exists(externalFilePath))
            {
                Console.WriteLine("The file '" + externalFilePath + "' was not found.");
                return;
            }

            // Read the external file into a byte array
            byte[] externalFileData = File.ReadAllBytes(externalFilePath);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Create OLE embedded data info (use the correct namespace)
                IOleEmbeddedDataInfo oleDataInfo = new OleEmbeddedDataInfo(externalFileData, "pdf");

                // Add an OLE object frame that embeds the external file
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                    50f,   // X position
                    50f,   // Y position
                    400f,  // Width
                    300f,  // Height
                    oleDataInfo);

                // Add a rectangle shape that will contain a hyperlink
                IShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    500f, // X position
                    50f,  // Y position
                    150f, // Width
                    50f); // Height

                // Cast the shape to AutoShape to work with text
                IAutoShape autoShape = (IAutoShape)shape;
                autoShape.AddTextFrame("Visit Aspose");

                // Access the first portion of the text frame
                ITextFrame textFrame = autoShape.TextFrame;
                IPortion portion = textFrame.Paragraphs[0].Portions[0];

                // Use HyperlinkManager to set an external hyperlink (no IsExternal property)
                IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Save the presentation (must include Aspose.Slides.Export namespace)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation created successfully.");
        }
    }
}