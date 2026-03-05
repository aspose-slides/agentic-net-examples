using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string sourcePath = "sample.pptx";

            // Get presentation information without loading the full presentation
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourcePath);

            // Display some basic information
            Console.WriteLine("Load Format: " + presentationInfo.LoadFormat);
            Console.WriteLine("Is Encrypted: " + presentationInfo.IsEncrypted);
            Console.WriteLine("Is Password Protected: " + presentationInfo.IsPasswordProtected);
            Console.WriteLine("Is Write Protected: " + presentationInfo.IsWriteProtected);

            // Load the presentation to be able to save it (required by the rule)
            using (Presentation pres = new Presentation(sourcePath))
            {
                // Save the presentation (can be the same file or a new one)
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved successfully.");
        }
    }
}