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
        string outputPath = "output.pptx";

        // Slide ID to retrieve
        uint slideId = 2;

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve slide by ID
            Aspose.Slides.IBaseSlide baseSlide = presentation.GetSlideById(slideId);
            Aspose.Slides.ISlide slide = baseSlide as Aspose.Slides.ISlide;
            if (slide == null)
            {
                Console.WriteLine("Slide with specified ID not found or is not a regular slide.");
                presentation.Dispose();
                return;
            }

            // Retrieve placeholder data from database (simulated)
            string titleText = string.Empty;
            string subtitleText = string.Empty;
            try
            {
                titleText = GetDataFromDatabase("Title");
                subtitleText = GetDataFromDatabase("Subtitle");
            }
            catch (Exception dbEx)
            {
                Console.WriteLine("Database error: " + dbEx.Message);
                // Continue with empty strings if needed
            }

            // Replace placeholder texts
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    string newText = null;
                    if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                    {
                        newText = titleText;
                    }
                    else if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Subtitle)
                    {
                        newText = subtitleText;
                    }

                    if (newText != null)
                    {
                        ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = newText;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Mock method to simulate database retrieval
    static string GetDataFromDatabase(string key)
    {
        // Replace with actual database access logic
        if (key == "Title")
            return "Quarterly Report";
        if (key == "Subtitle")
            return "Q1 2026";
        return string.Empty;
    }
}