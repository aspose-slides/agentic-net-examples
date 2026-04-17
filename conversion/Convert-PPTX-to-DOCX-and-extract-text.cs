using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputDocxPath = "output.docx";

        // Verify that the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Attempt to convert to DOCX
        // NOTE: Aspose.Slides does not support DOCX output. This block demonstrates handling the unsupported format.
        try
        {
            // The following line is intentionally commented out because SaveFormat.Docx does not exist.
            // presentation.Save(outputDocxPath, Aspose.Slides.Export.SaveFormat.Docx);
            Console.WriteLine("DOCX conversion is not supported by Aspose.Slides.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("DOCX format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }

        // Save the original presentation (required by the task)
        try
        {
            string tempSavePath = "temp_saved.pptx";
            presentation.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        // Extract text from the presentation (since DOCX was not created)
        try
        {
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                inputPath,
                Aspose.Slides.TextExtractionArrangingMode.Unarranged);

            Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;
            foreach (Aspose.Slides.ISlideText slideText in slidesText)
            {
                Console.WriteLine(slideText.Text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error extracting text: " + ex.Message);
        }

        // Dispose of the presentation object
        if (presentation != null)
        {
            presentation.Dispose();
        }
    }
}