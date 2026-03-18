using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTagDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the custom data container
                    ICustomData customData = presentation.CustomData;

                    // Access the tags collection
                    ITagCollection tags = customData.Tags;

                    // Add a new tag
                    tags.Add("Project", "AsposeDemo");

                    // Retrieve the tag value
                    string projectValue = tags["Project"];
                    Console.WriteLine("Project tag value: " + projectValue);

                    // Update the tag value
                    tags["Project"] = "AsposeDemoUpdated";
                    Console.WriteLine("Updated Project tag value: " + tags["Project"]);

                    // Delete the tag
                    tags.Remove("Project");
                    Console.WriteLine("Tag 'Project' exists after removal: " + tags.Contains("Project"));

                    // Save the presentation before exiting
                    presentation.Save("TagDemo_out.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}