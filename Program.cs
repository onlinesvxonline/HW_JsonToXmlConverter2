using System;
using System.Text.Json;
using System.Xml;

class Program
{
    static void Main()
    {
        string jsonString = "{\"Name\": \"Денис\", \"LastName\": \"Чорноног\", \"Age\": 35, \"City\": \"Москва\"}";

        using (JsonDocument jsonDoc = JsonDocument.Parse(jsonString))
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(Console.Out))
            {
                xmlWriter.WriteStartElement("Root");

                foreach (JsonProperty property in jsonDoc.RootElement.EnumerateObject())
                {
                    xmlWriter.WriteStartElement(property.Name);
                    xmlWriter.WriteString(property.Value.ToString());
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }
    }
}