using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesVbaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string presentationPath = "input.pptm";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(presentationPath);

                // Obtain the VBA project object
                Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;

                // Example usage: check if the VBA project is password protected
                if (vbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("The VBA project is password protected.");
                }
                else
                {
                    Console.WriteLine("VBA Project Name: " + vbaProject.Name);
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
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