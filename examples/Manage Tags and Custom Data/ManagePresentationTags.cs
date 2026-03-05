using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the tags collection
        Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

        // Add a tag using indexer
        tags["Author"] = "John Doe";

        // Add another tag using Add method
        tags.Add("Company", "Acme Corp");

        // Check if a tag exists
        bool hasTag = tags.Contains("Author");
        Console.WriteLine("Contains 'Author' tag: " + hasTag);

        // Retrieve a tag value
        string authorValue = tags["Author"];
        Console.WriteLine("Author tag value: " + authorValue);

        // Remove a tag
        tags.Remove("Company");

        // Save the presentation
        presentation.Save("TaggedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}