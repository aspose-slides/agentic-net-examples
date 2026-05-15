using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // List of presentation files to process
        string[] inputFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx" };

        foreach (string fileName in inputFiles)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                continue;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    // Verify each digital signature and log the result
                    if (presentation.DigitalSignatures.Count > 0)
                    {
                        foreach (Aspose.Slides.DigitalSignature signature in presentation.DigitalSignatures)
                        {
                            string result = signature.IsValid ? "VALID" : "INVALID";
                            Console.WriteLine($"{signature.Certificate.SubjectName.Name}, {signature.SignTime:yyyy-MM-dd HH:mm} -- {result}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No digital signatures found in {fileName}");
                    }

                    // Save the presentation before exiting (no changes made)
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Processed_" + fileName);
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"File format not supported: {filePath}");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
            }
        }
    }
}