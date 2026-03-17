using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access view properties and modify zoom levels
                Aspose.Slides.IViewProperties viewProperties = presentation.ViewProperties;
                viewProperties.SlideViewProperties.Scale = 150; // 150% zoom for slide view
                viewProperties.NotesViewProperties.Scale = 120; // 120% zoom for notes view

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}