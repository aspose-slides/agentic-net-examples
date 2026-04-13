using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Ensure there is at least one master slide
                if (presentation.Masters.Count > 0)
                {
                    // Get the first master slide
                    Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                    // Access the tag collection of the master slide's custom data
                    Aspose.Slides.ITagCollection tagCollection = masterSlide.CustomData.Tags;

                    // Add default tags
                    tagCollection.Add("Author", "Default Author");
                    tagCollection.Add("Company", "Default Company");
                    tagCollection.Add("Category", "Default Category");
                }

                // Save the presentation
                try
                {
                    presentation.Save("MasterTagExample_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file I/O)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}