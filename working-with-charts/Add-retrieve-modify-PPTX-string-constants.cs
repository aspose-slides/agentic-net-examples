using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access document properties
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Add a custom string property
                    docProps.SetCustomPropertyValue("MyConstant", "InitialValue");

                    // Retrieve the custom string property
                    string retrievedValue;
                    docProps.GetCustomPropertyValue("MyConstant", out retrievedValue);
                    Console.WriteLine("Retrieved custom property: " + retrievedValue);

                    // Modify the custom string property
                    docProps.SetCustomPropertyValue("MyConstant", "UpdatedValue");

                    // Verify the modification
                    string updatedValue;
                    docProps.GetCustomPropertyValue("MyConstant", out updatedValue);
                    Console.WriteLine("Updated custom property: " + updatedValue);

                    // Save the presentation
                    presentation.Save("StringConstantsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}