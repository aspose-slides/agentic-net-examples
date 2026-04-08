using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides.Export;

public class DocumentPropertiesBackup
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Category { get; set; }
    public string Comments { get; set; }
    public string Company { get; set; }
    public DateTime CreatedTime { get; set; }
    public string LastSavedBy { get; set; }
    public DateTime LastSavedTime { get; set; }
    public string Keywords { get; set; }
    public string Manager { get; set; }
    public string ApplicationTemplate { get; set; }
    public string PresentationFormat { get; set; }
    public TimeSpan TotalEditingTime { get; set; }
}

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string backupPath = "properties_backup.json";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.IDocumentProperties props = presentation.DocumentProperties;

                DocumentPropertiesBackup backup = new DocumentPropertiesBackup
                {
                    Author = props.Author,
                    Title = props.Title,
                    Subject = props.Subject,
                    Category = props.Category,
                    Comments = props.Comments,
                    Company = props.Company,
                    CreatedTime = props.CreatedTime,
                    LastSavedBy = props.LastSavedBy,
                    LastSavedTime = props.LastSavedTime,
                    Keywords = props.Keywords,
                    Manager = props.Manager,
                    ApplicationTemplate = props.ApplicationTemplate,
                    PresentationFormat = props.PresentationFormat,
                    TotalEditingTime = props.TotalEditingTime
                };

                string json = JsonSerializer.Serialize(backup, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(backupPath, json);
                Console.WriteLine("Document properties backed up to " + backupPath);

                // Perform destructive changes (example: clear built-in properties)
                props.ClearBuiltInProperties();

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Modified presentation saved to " + outputPath);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported (PPTX).");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported (PPT).");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}