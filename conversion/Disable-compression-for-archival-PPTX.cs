using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DisableCompressionForArchival
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input file path and output file path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: DisableCompressionForArchival <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access document properties
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Determine if the presentation is marked as archival via a custom property named "Archival"
                    bool isArchival = false;
                    if (docProps.ContainsCustomProperty("Archival"))
                    {
                        bool archivalValue;
                        docProps.GetCustomPropertyValue("Archival", out archivalValue);
                        isArchival = archivalValue;
                    }

                    // If archival, disable picture compression
                    if (isArchival)
                    {
                        foreach (ISlide slide in presentation.Slides)
                        {
                            foreach (IShape shape in slide.Shapes)
                            {
                                if (shape is IPictureFrame)
                                {
                                    IPictureFrame picture = (IPictureFrame)shape;
                                    // Disable compression (set compress flag to false)
                                    picture.PictureFormat.CompressImage(false, Aspose.Slides.Export.PicturesCompression.Dpi96);
                                }
                            }
                        }
                    }

                    // Save the presentation (ensure save before exit)
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network issues if URLs were used)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}