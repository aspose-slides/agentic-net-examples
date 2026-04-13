using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationFileName = "demo.pptm";
            string presentationPath = Path.Combine(Directory.GetCurrentDirectory(), presentationFileName);

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file does not exist: " + presentationPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
                // Check if VBA project is password protected before accessing macros
                if (presentation.VbaProject != null && presentation.VbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("The VBAProject is protected by a password.");
                }
                else
                {
                    Console.WriteLine("The VBAProject is not password protected.");
                    // Access or modify VBA macros here
                }

                // Save presentation before exit
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}