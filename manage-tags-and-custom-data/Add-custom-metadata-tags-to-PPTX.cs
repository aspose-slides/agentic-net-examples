using System;
using Aspose.Slides.Export;

namespace AddCustomMetadataTags
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing PPTX file
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Access the tag collection and add a custom tag
                    Aspose.Slides.ITagCollection tags = pres.CustomData.Tags;
                    tags.Add("MyTag", "My Tag Value");

                    // Save the presentation with the new tag
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}