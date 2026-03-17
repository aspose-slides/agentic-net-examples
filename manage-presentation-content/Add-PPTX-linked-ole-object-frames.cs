using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LinkedOleObjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Define OLE object parameters
                float oleX = 50f;
                float oleY = 50f;
                float oleWidth = presentation.SlideSize.Size.Width - 100f;
                float oleHeight = presentation.SlideSize.Size.Height - 100f;
                string oleClassName = "Excel.Sheet";
                string oleFilePath = "sample.xlsx"; // Path to the external Excel file

                // Add a linked OLE object frame to the slide
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                    oleX,
                    oleY,
                    oleWidth,
                    oleHeight,
                    oleClassName,
                    oleFilePath);

                // Enable automatic update of the linked object
                oleObjectFrame.UpdateAutomatic = true;

                // Save the presentation
                presentation.Save("LinkedOleObject_out.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}