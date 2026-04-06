using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomNotesLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Access the master notes slide
                IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
                if (masterNotesSlide != null)
                {
                    // Manage header and footer on the master notes slide
                    IMasterNotesSlideHeaderFooterManager masterHeaderFooter = masterNotesSlide.HeaderFooterManager;
                    masterHeaderFooter.SetHeaderAndChildHeadersVisibility(true);
                    masterHeaderFooter.SetFooterAndChildFootersVisibility(true);
                    masterHeaderFooter.SetHeaderAndChildHeadersText("Custom Header Text");
                    masterHeaderFooter.SetFooterAndChildFootersText("Custom Footer Text");
                }

                // Apply header and footer to each slide's notes slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    INotesSlide notesSlide = presentation.Slides[i].NotesSlideManager.NotesSlide;
                    if (notesSlide != null)
                    {
                        INotesSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;
                        if (!notesHeaderFooter.IsHeaderVisible)
                        {
                            notesHeaderFooter.SetHeaderVisibility(true);
                        }
                        if (!notesHeaderFooter.IsFooterVisible)
                        {
                            notesHeaderFooter.SetFooterVisibility(true);
                        }
                        notesHeaderFooter.SetHeaderText("Custom Header Text");
                        notesHeaderFooter.SetFooterText("Custom Footer Text");
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}