using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public static class PptxErrorCodes
{
    // Define constant identifiers for PPTX processing errors
    public const int FileNotFound = 1001;
    public const int UnsupportedFormat = 1002;
    public const int CorruptFile = 1003;
    public const int GeneralReadError = 1004;
}

public class Program
{
    public static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Presentation instance (initialized to null)
        Presentation presentation = null;

        try
        {
            // Attempt to load the presentation from the specified file
            presentation = new Presentation(inputPath);
        }
        // Catch specific exceptions before the generic read exception
        catch (PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Error: Unsupported format. Code: " + PptxErrorCodes.UnsupportedFormat);
            // Create a new empty presentation as a fallback
            presentation = new Presentation();
        }
        catch (PptCorruptFileException ex)
        {
            Console.WriteLine("Error: Corrupt file. Code: " + PptxErrorCodes.CorruptFile);
            // Create a new empty presentation as a fallback
            presentation = new Presentation();
        }
        catch (PptxReadException ex)
        {
            Console.WriteLine("Error: General read error. Code: " + PptxErrorCodes.GeneralReadError);
            // Create a new empty presentation as a fallback
            presentation = new Presentation();
        }
        finally
        {
            if (presentation != null)
            {
                // Ensure there is at least one slide
                if (presentation.Slides.Count == 0)
                {
                    // Add an empty slide using the default layout of the first slide (if any)
                    // If no layout is available, this line will be skipped safely
                    if (presentation.Slides.Count > 0)
                    {
                        presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
        }
    }
}