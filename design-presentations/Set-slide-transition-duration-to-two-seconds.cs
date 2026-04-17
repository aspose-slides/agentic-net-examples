using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load existing presentation if the file exists; otherwise create a new one
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Set transition duration to 2000 milliseconds (2 seconds) for each slide
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlideShowTransition transition = presentation.Slides[i].SlideShowTransition;
                    transition.Duration = 2000;
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException notSupEx)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + notSupEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL loading)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}