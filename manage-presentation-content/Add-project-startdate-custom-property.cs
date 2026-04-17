using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationTemplateCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output file path
                string dataDir = "Data/";
                string outputPath = dataDir + "ProjectTemplate.pptx";

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access document properties
                IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Set built-in properties
                documentProperties.Title = "Project Presentation Template";
                documentProperties.Author = "Automation System";

                // Add custom properties for project metadata
                documentProperties["ProjectName"] = "New Project";
                documentProperties["ProjectId"] = 12345;
                documentProperties["StartDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation template created successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}