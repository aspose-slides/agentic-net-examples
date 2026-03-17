using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ControlSlideZoom
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Set zoom level for slide view (percentage)
                    presentation.ViewProperties.SlideViewProperties.Scale = 150; // 150%
                    // Set zoom level for notes view (optional)
                    presentation.ViewProperties.NotesViewProperties.Scale = 150;

                    // Save the presentation with the updated zoom settings
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}