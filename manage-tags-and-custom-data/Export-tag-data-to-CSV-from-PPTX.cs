using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTagAndMetadataExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the input and output presentation files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access document properties
                    IDocumentProperties documentProperties = presentation.DocumentProperties;

                    // Add a custom property
                    documentProperties["MyCustomProperty"] = "Initial Value";

                    // Retrieve the custom property
                    object retrievedValue = documentProperties["MyCustomProperty"];
                    Console.WriteLine("Custom Property (initial): " + retrievedValue);

                    // Modify the custom property
                    documentProperties["MyCustomProperty"] = "Modified Value";

                    // Access the tag collection
                    ITagCollection tags = presentation.CustomData.Tags;

                    // Add a new tag
                    tags.Add("AuthorTag", "John Doe");

                    // Retrieve the tag value
                    string authorTagValue = tags["AuthorTag"];
                    Console.WriteLine("Tag (initial): " + authorTagValue);

                    // Modify the tag value
                    tags["AuthorTag"] = "Jane Smith";

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation processed and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}