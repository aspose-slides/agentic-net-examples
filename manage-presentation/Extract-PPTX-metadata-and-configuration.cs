using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMetadataExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access document properties
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Built‑in properties
                    Console.WriteLine("Author: " + docProps.Author);
                    Console.WriteLine("Title: " + docProps.Title);
                    Console.WriteLine("Subject: " + docProps.Subject);
                    Console.WriteLine("Category: " + docProps.Category);
                    Console.WriteLine("Comments: " + docProps.Comments);
                    Console.WriteLine("Created Time (UTC): " + docProps.CreatedTime);
                    Console.WriteLine("Last Saved By: " + docProps.LastSavedBy);
                    Console.WriteLine("Last Saved Time (UTC): " + docProps.LastSavedTime);
                    Console.WriteLine("Keywords: " + docProps.Keywords);
                    Console.WriteLine("Revision Number: " + docProps.RevisionNumber);
                    Console.WriteLine("Slides Count: " + docProps.Slides);
                    Console.WriteLine("Hidden Slides: " + docProps.HiddenSlides);
                    Console.WriteLine("Notes Slides: " + docProps.Notes);
                    Console.WriteLine("Words: " + docProps.Words);
                    Console.WriteLine("Paragraphs: " + docProps.Paragraphs);
                    Console.WriteLine("Multimedia Clips: " + docProps.MultimediaClips);
                    Console.WriteLine("Total Editing Time: " + docProps.TotalEditingTime);
                    Console.WriteLine("Scale Crop: " + docProps.ScaleCrop);
                    Console.WriteLine("Shared Document: " + docProps.SharedDoc);
                    Console.WriteLine("Hyperlink Base: " + docProps.HyperlinkBase);
                    Console.WriteLine("Hyperlinks Changed: " + docProps.HyperlinksChanged);
                    Console.WriteLine("Links Up To Date: " + docProps.LinksUpToDate);
                    Console.WriteLine("Application Template: " + docProps.ApplicationTemplate);
                    Console.WriteLine("Name Of Application: " + docProps.NameOfApplication);
                    Console.WriteLine("App Version: " + docProps.AppVersion);
                    Console.WriteLine("Content Status: " + docProps.ContentStatus);
                    Console.WriteLine("Content Type: " + docProps.ContentType);
                    Console.WriteLine("Presentation Format: " + docProps.PresentationFormat);
                    Console.WriteLine("Manager: " + docProps.Manager);
                    Console.WriteLine("Company: " + docProps.Company);

                    // Custom properties
                    int customCount = docProps.CountOfCustomProperties;
                    Console.WriteLine("\nCustom Properties Count: " + customCount);
                    for (int i = 0; i < customCount; i++)
                    {
                        string propName = docProps.GetCustomPropertyName(i);
                        object propValue = docProps[propName];
                        Console.WriteLine("Custom Property - Name: " + propName + ", Value: " + (propValue ?? "null"));
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}