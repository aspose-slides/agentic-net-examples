using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagEventDemo
{
    class Program
    {
        // Define delegate for tag change events
        public delegate void TagChangedHandler(string tagName, string tagValue);
        // Events for tag addition and removal
        public static event TagChangedHandler TagAdded;
        public static event TagChangedHandler TagRemoved;

        static void Main(string[] args)
        {
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                // If input does not exist, create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Subscribe to events
                    TagAdded += OnTagAdded;
                    TagRemoved += OnTagRemoved;

                    // Access tag collection
                    ITagCollection tags = pres.CustomData.Tags;

                    // Add a tag (triggers TagAdded event)
                    tags.Add("Author", "John Doe");
                    TagAdded?.Invoke("Author", "John Doe");

                    // Remove the tag (triggers TagRemoved event)
                    tags.Remove("Author");
                    TagRemoved?.Invoke("Author", null);

                    // Save presentation before exit
                    try
                    {
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                    catch (Exception ex)
                    {
                        // Handle format not supported exception
                        // Format not supported
                        Console.WriteLine("Error saving presentation: " + ex.Message);
                    }
                }
            }
            else
            {
                // Load existing presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Subscribe to events
                    TagAdded += OnTagAdded;
                    TagRemoved += OnTagRemoved;

                    ITagCollection tags = pres.CustomData.Tags;

                    // Example: add a new tag
                    tags.Add("Reviewed", "True");
                    TagAdded?.Invoke("Reviewed", "True");

                    // Example: remove an existing tag if present
                    if (tags.Contains("Author"))
                    {
                        tags.Remove("Author");
                        TagRemoved?.Invoke("Author", null);
                    }

                    // Save presentation before exit
                    try
                    {
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                    catch (Exception ex)
                    {
                        // Handle format not supported exception
                        // Format not supported
                        Console.WriteLine("Error saving presentation: " + ex.Message);
                    }
                }
            }
        }

        // Event handler for tag addition
        private static void OnTagAdded(string tagName, string tagValue)
        {
            Console.WriteLine($"Tag added: {tagName} = {tagValue}");
        }

        // Event handler for tag removal
        private static void OnTagRemoved(string tagName, string tagValue)
        {
            Console.WriteLine($"Tag removed: {tagName}");
        }
    }
}