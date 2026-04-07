using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace BatchConvertToXaml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing PPT files (first argument or current directory)
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Repository directory to store generated XAML files (second argument or subfolder)
            string repositoryDirectory;
            if (args.Length > 1 && !String.IsNullOrEmpty(args[1]))
            {
                repositoryDirectory = args[1];
            }
            else
            {
                repositoryDirectory = Path.Combine(Directory.GetCurrentDirectory(), "XamlRepo");
            }

            // Ensure repository directory exists
            if (!Directory.Exists(repositoryDirectory))
            {
                Directory.CreateDirectory(repositoryDirectory);
            }

            // Get all PPT and PPTX files in the input directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt*");

            foreach (string pptFilePath in pptFiles)
            {
                // Verify the file exists before processing
                if (!File.Exists(pptFilePath))
                {
                    continue;
                }

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptFilePath);

                    // Configure XAML export options
                    Aspose.Slides.Export.Xaml.XamlOptions xamlOptions = new Aspose.Slides.Export.Xaml.XamlOptions();
                    xamlOptions.ExportHiddenSlides = true;

                    // Save presentation as XAML (creates multiple .xaml files)
                    presentation.Save(xamlOptions);

                    // Determine the base name of the source file (without extension)
                    string baseFileName = Path.GetFileNameWithoutExtension(pptFilePath);
                    string sourceFolder = Path.GetDirectoryName(pptFilePath);

                    // Assume generated XAML files follow the pattern: BaseFileName_Slide*.xaml
                    string searchPattern = baseFileName + "_Slide*.xaml";
                    string[] generatedXamlFiles = Directory.GetFiles(sourceFolder, searchPattern);

                    // Create a subfolder in the repository for this presentation
                    string targetFolder = Path.Combine(repositoryDirectory, baseFileName);
                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    // Copy each generated XAML file to the repository
                    foreach (string sourceXamlPath in generatedXamlFiles)
                    {
                        string destinationXamlPath = Path.Combine(targetFolder, Path.GetFileName(sourceXamlPath));
                        File.Copy(sourceXamlPath, destinationXamlPath, true);
                    }

                    // Dispose the presentation object
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported – comment for developers
                    // The current file format cannot be converted to XAML.
                }
                catch (Exception)
                {
                    // General exception handling – comment for developers
                    // An unexpected error occurred while processing the file.
                }
            }
        }
    }
}