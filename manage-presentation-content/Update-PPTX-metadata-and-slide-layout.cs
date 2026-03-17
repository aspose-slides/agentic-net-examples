using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Update document properties (metadata)
                IDocumentProperties properties = presentation.DocumentProperties;
                properties.Title = "Updated Presentation Title";
                properties.Subject = "Updated Subject";
                properties.Author = "John Doe";

                // Retrieve and display metadata
                Console.WriteLine("Title: " + properties.Title);
                Console.WriteLine("Subject: " + properties.Subject);
                Console.WriteLine("Author: " + properties.Author);
                Console.WriteLine("Created: " + properties.CreatedTime);

                // Iterate through slides to get layout and content details
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    Console.WriteLine("Slide " + (index + 1) + " Name: " + slide.Name);

                    // Access the layout slide using the correct interface
                    ILayoutSlide layoutSlide = slide.LayoutSlide;
                    if (layoutSlide != null)
                    {
                        Console.WriteLine("  Layout Type: " + layoutSlide.LayoutType);
                        Console.WriteLine("  Layout Name: " + layoutSlide.Name);
                    }
                }

                // Save the updated presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}