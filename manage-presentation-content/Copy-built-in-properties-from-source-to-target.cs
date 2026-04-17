using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CopyBuiltInProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: source presentation path and target presentation path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CopyBuiltInProperties <source.pptx> <target.pptx>");
                return;
            }

            string sourcePath = args[0];
            string targetPath = args[1];

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file does not exist: {sourcePath}");
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Load (or create) target presentation
                    Presentation targetPresentation;
                    if (File.Exists(targetPath))
                    {
                        targetPresentation = new Presentation(targetPath);
                    }
                    else
                    {
                        targetPresentation = new Presentation();
                    }

                    using (targetPresentation)
                    {
                        // Get document properties objects
                        IDocumentProperties sourceProps = sourcePresentation.DocumentProperties;
                        IDocumentProperties targetProps = targetPresentation.DocumentProperties;

                        // Copy built‑in properties (only writable ones)
                        targetProps.Author = sourceProps.Author;
                        targetProps.Title = sourceProps.Title;
                        targetProps.Subject = sourceProps.Subject;
                        targetProps.Category = sourceProps.Category;
                        targetProps.Comments = sourceProps.Comments;
                        targetProps.Company = sourceProps.Company;
                        targetProps.ContentStatus = sourceProps.ContentStatus;
                        targetProps.ContentType = sourceProps.ContentType;
                        targetProps.CreatedTime = sourceProps.CreatedTime;
                        targetProps.HyperlinkBase = sourceProps.HyperlinkBase;
                        targetProps.Keywords = sourceProps.Keywords;
                        targetProps.LastPrinted = sourceProps.LastPrinted;
                        targetProps.LastSavedBy = sourceProps.LastSavedBy;
                        targetProps.Manager = sourceProps.Manager;
                        targetProps.NameOfApplication = sourceProps.NameOfApplication;
                        targetProps.PresentationFormat = sourceProps.PresentationFormat;
                        targetProps.RevisionNumber = sourceProps.RevisionNumber;
                        targetProps.ScaleCrop = sourceProps.ScaleCrop;
                        targetProps.SharedDoc = sourceProps.SharedDoc;
                        targetProps.TotalEditingTime = sourceProps.TotalEditingTime;

                        // Save the target presentation
                        targetPresentation.Save(targetPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}