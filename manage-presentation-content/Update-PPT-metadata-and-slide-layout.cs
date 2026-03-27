using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define the data directory (current directory)
        string dataDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;

        // Path to the template presentation
        string templatePath = dataDir + "Template.pptx";

        // Verify that the template file exists
        if (!File.Exists(templatePath))
        {
            Console.WriteLine("Template file not found: " + templatePath);
            return;
        }

        // Get template presentation info and read its document properties
        IPresentationInfo templateInfo = PresentationFactory.Instance.GetPresentationInfo(templatePath);
        IDocumentProperties templateProps = templateInfo.ReadDocumentProperties();

        // Update metadata in the template properties
        templateProps.Author = "Aspose.Slides Example";
        templateProps.Title = "Updated Presentation";
        templateProps.Category = "Demo";
        templateProps.Keywords = "Aspose, Slides, Metadata";
        templateProps.Company = "Aspose Ltd.";
        templateProps.Comments = "Updated using template properties";
        templateProps.ContentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        templateProps.Subject = "Metadata Update";

        // Define target presentation files
        string[] targetFiles = new string[]
        {
            dataDir + "Presentation1.pptx",
            dataDir + "Presentation2.pptx",
            dataDir + "Presentation3.pptx"
        };

        // Update each target presentation's properties using the template properties
        foreach (string targetPath in targetFiles)
        {
            if (!File.Exists(targetPath))
            {
                Console.WriteLine("Target file not found: " + targetPath);
                continue;
            }

            IPresentationInfo targetInfo = PresentationFactory.Instance.GetPresentationInfo(targetPath);
            targetInfo.UpdateDocumentProperties(templateProps);
            targetInfo.WriteBindedPresentation(targetPath);
        }

        // Retrieve and display metadata, layout, and content details for each target presentation
        foreach (string targetPath in targetFiles)
        {
            if (!File.Exists(targetPath))
            {
                continue;
            }

            // Load the presentation
            Presentation presentation = new Presentation(targetPath);

            // Access document properties
            IDocumentProperties docProps = presentation.DocumentProperties;
            Console.WriteLine("File: " + Path.GetFileName(targetPath));
            Console.WriteLine("Author: " + docProps.Author);
            Console.WriteLine("Title: " + docProps.Title);
            Console.WriteLine("Subject: " + docProps.Subject);
            Console.WriteLine("Slide Count: " + presentation.Slides.Count);

            // List layout slide names
            Console.WriteLine("Layout Slides:");
            foreach (ILayoutSlide layoutSlide in presentation.LayoutSlides)
            {
                Console.WriteLine("- " + layoutSlide.Name);
            }

            // Retrieve text from the first slide (if any)
            if (presentation.Slides.Count > 0)
            {
                ISlide firstSlide = presentation.Slides[0];
                foreach (IShape shape in firstSlide.Shapes)
                {
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null && !string.IsNullOrEmpty(autoShape.TextFrame.Text))
                    {
                        Console.WriteLine("First slide text: " + autoShape.TextFrame.Text);
                        break;
                    }
                }
            }

            // Save the presentation (required by rule)
            presentation.Save(targetPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}