using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file names
            string inputFileName = "input.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Extract raw text from the presentation
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    TextExtractionArrangingMode.Unarranged);

                StringBuilder builder = new StringBuilder();

                // Iterate through each slide's extracted text
                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    ISlideText slideText = presentationText.SlidesText[i];

                    // Append slide shape text
                    if (!string.IsNullOrEmpty(slideText.Text))
                    {
                        builder.AppendLine(slideText.Text);
                    }

                    // Append notes text if present
                    if (!string.IsNullOrEmpty(slideText.NotesText))
                    {
                        builder.AppendLine(slideText.NotesText);
                    }
                }

                // Write the collected text to a plain text file
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");
                File.WriteAllText(outputPath, builder.ToString());

                // Load the presentation and save it before exiting (no modifications made)
                using (Presentation pres = new Presentation(inputPath))
                {
                    pres.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Text extraction completed. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}