using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Output directory for converted files
        string outputDir = "Converted";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // List of target formats to test
        string[] formatNames = new string[]
        {
            "Ppt", "Pdf", "Xps", "Pptx", "Ppsx", "Tiff", "Odp", "Pptm",
            "Ppsm", "Potx", "Potm", "Html", "Swf", "Otp", "Pps",
            "Pot", "Fodp", "Gif", "Html5", "Md", "Xml"
        };

        foreach (string formatName in formatNames)
        {
            try
            {
                // Parse the enum value from the name
                SaveFormat format = (SaveFormat)Enum.Parse(typeof(SaveFormat), formatName);
                // Determine a simple file extension
                string extension = formatName.ToLower();
                if (extension == "html5") extension = "html";
                if (extension == "md") extension = "md";
                if (extension == "xml") extension = "xml";
                if (extension == "ppt") extension = "ppt";
                if (extension == "pptx") extension = "pptx";
                if (extension == "pptm") extension = "pptm";
                if (extension == "ppsx") extension = "ppsx";
                if (extension == "pps") extension = "pps";
                if (extension == "potx") extension = "potx";
                if (extension == "potm") extension = "potm";
                if (extension == "pot") extension = "pot";
                if (extension == "odp") extension = "odp";
                if (extension == "otp") extension = "otp";
                if (extension == "fodp") extension = "fodp";
                if (extension == "tiff") extension = "tiff";
                if (extension == "gif") extension = "gif";
                if (extension == "swf") extension = "swf";

                string outputPath = Path.Combine(outputDir, $"output.{extension}");

                // Save using the appropriate format
                presentation.Save(outputPath, format);

                Console.WriteLine($"Successfully saved as {formatName} to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save as {formatName}: {ex.Message}");
            }
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}