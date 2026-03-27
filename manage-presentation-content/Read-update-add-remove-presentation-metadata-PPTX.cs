using System;
using System.IO;
using Aspose.Slides.Export;

namespace PresentationPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = "Data\\";
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Template presentation path
            string templatePath = dataDir + "Template.pptx";
            if (!File.Exists(templatePath))
            {
                Console.WriteLine("Template file not found: " + templatePath);
                return;
            }

            // Read template properties and set new values
            Aspose.Slides.IPresentationInfo templateInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(templatePath);
            Aspose.Slides.IDocumentProperties templateProps = templateInfo.ReadDocumentProperties();
            templateProps.Author = "John Doe";
            templateProps.Title = "Sample Title";
            templateProps.Category = "Demo";
            templateProps.Keywords = "Aspose,Slides,Metadata";
            templateProps.Company = "Acme Corp";
            templateProps.Comments = "Updated via template";
            templateProps.ContentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            templateProps.Subject = "Presentation Subject";

            // Target presentations to update
            string[] targetFiles = new string[] { dataDir + "Doc1.pptx", dataDir + "Doc2.pptx", dataDir + "Doc3.pptx" };
            foreach (string targetPath in targetFiles)
            {
                if (!File.Exists(targetPath))
                {
                    Console.WriteLine("Target file not found, skipping: " + targetPath);
                    continue;
                }

                Aspose.Slides.IPresentationInfo targetInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(targetPath);
                targetInfo.UpdateDocumentProperties(templateProps);
                targetInfo.WriteBindedPresentation(targetPath);
            }

            // Create a new presentation and modify built‑in properties
            string newPresPath = dataDir + "NewPresentation.pptx";
            Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();
            Aspose.Slides.IDocumentProperties docProps = newPresentation.DocumentProperties;
            docProps.Author = "Alice Smith";
            docProps.Title = "New Presentation Title";
            docProps.Subject = "New Subject";
            docProps.Comments = "Created programmatically";

            // Add custom document properties
            docProps["CustomInt"] = 123;
            docProps["CustomString"] = "Custom Value";
            docProps["CustomDate"] = DateTime.Now;

            // Remove a custom property using its name
            string propertyName = docProps.GetCustomPropertyName(0);
            docProps.RemoveCustomProperty(propertyName);

            // Save the new presentation
            newPresentation.Save(newPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            newPresentation.Dispose();

            Console.WriteLine("Processing completed.");
        }
    }
}