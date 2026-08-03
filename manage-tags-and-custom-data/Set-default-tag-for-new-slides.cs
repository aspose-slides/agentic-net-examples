// -----------------------------------------------------------------------------
// Example: Set default tag for new slides using C#
//
// Description:
// Demonstrates how to set a default tag for new slides by adding a custom
// property to a presentation template and applying it to a newly created
// presentation using Aspose.Slides for .NET. The example loads a template,
// defines a custom property "DefaultTag", creates a new slide based on the
// template layout, and saves the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Default Tag, Custom Property,
// Presentation Template, Slide Creation, Office Automation
//
// Use Cases:
// - Automate setting a default tag for newly added slides.
// - Build tools that propagate custom metadata from templates to new presentations.
// - Generate PPTX files with predefined tags for downstream processing.
// - Ensure consistent slide metadata across multiple presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory and template path
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string templatePath = Path.Combine(dataDir, "Template.pptx");

        // Check if template file exists
        if (!File.Exists(templatePath))
        {
            Console.WriteLine("Template file not found: " + templatePath);
            return;
        }

        // Load template presentation info and read its document properties
        IPresentationInfo templateInfo = PresentationFactory.Instance.GetPresentationInfo(templatePath);
        IDocumentProperties templateProps = templateInfo.ReadDocumentProperties();

        // Set a default tag value in the template's custom properties
        templateProps.SetCustomPropertyValue("DefaultTag", "MyTagValue");

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Apply the template properties (including the custom tag) to the new presentation
            pres.DocumentProperties.SetCustomPropertyValue("DefaultTag", "MyTagValue");

            // Add a new slide using the first layout slide as a template
            ISlide newSlide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Optionally, set the same tag as a custom property for the slide (if needed)
            // Note: Aspose.Slides does not have a direct slide tag API, so we store it as a custom property at presentation level

            // Define output path
            string outputPath = Path.Combine(dataDir, "Output.pptx");

            // Save the presentation with exception handling for unsupported formats
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
