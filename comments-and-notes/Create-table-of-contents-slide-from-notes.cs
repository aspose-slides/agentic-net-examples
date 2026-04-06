using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Insert a new empty slide at the beginning to serve as TOC
                Aspose.Slides.ISlide tocSlide = pres.Slides.InsertEmptySlide(0, pres.Slides[0].LayoutSlide);

                // Define table columns: Slide number and Title
                double[] cols = new double[] { 100, 400 };
                int slideCount = pres.Slides.Count;
                double[] rows = new double[slideCount + 1];
                rows[0] = 30; // Header row height
                for (int i = 1; i <= slideCount; i++) rows[i] = 20; // Content rows height

                // Add table to the TOC slide
                Aspose.Slides.ITable tocTable = tocSlide.Shapes.AddTable(50, 50, cols, rows);

                // Header cells
                tocTable[0, 0].TextFrame.Text = "Slide";
                tocTable[0, 1].TextFrame.Text = "Title";

                // Populate table with slide numbers and notes titles
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    Aspose.Slides.INotesSlide notes = slide.NotesSlideManager.NotesSlide;
                    string title = "";
                    if (notes != null && notes.NotesTextFrame != null)
                    {
                        title = notes.NotesTextFrame.Text;
                    }

                    tocTable[i + 1, 0].TextFrame.Text = (i + 1).ToString();
                    tocTable[i + 1, 1].TextFrame.Text = title;
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex) when (ex is NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}