using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Insert an ActiveX CommandButton control onto the slide
                // Parameters: x, y, width, height, class name, path (empty for embedded)
                Aspose.Slides.IOleObjectFrame activeXButton = slide.Shapes.AddOleObjectFrame(
                    100f,   // X position
                    100f,   // Y position
                    100f,   // Width
                    30f,    // Height
                    "Forms.CommandButton.1", // ActiveX class name
                    ""      // No external file path
                );

                // Optionally set a name for the control
                activeXButton.Name = "ActiveXButton";

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}