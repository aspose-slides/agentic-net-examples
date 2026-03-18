using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add an ActiveX control (CommandButton) to the slide using class name method
                // Parameters: x, y, width, height, class name, path (empty for embedded)
                Aspose.Slides.IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(100f, 100f, 120f, 30f, "Forms.CommandButton.1", "");

                // Optionally, set properties of the control if needed
                // The added OLE object can be accessed as a control via the slide's Controls collection
                // Example: set the name of the control
                Aspose.Slides.IControl control = slide.Controls[slide.Controls.Count - 1];
                control.Name = "MyActiveXButton";

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}