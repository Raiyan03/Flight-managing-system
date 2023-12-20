using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace flightManager.Data
{
    // Class for handling data serialization operations
    public class DataSerialization
    {
        // Method to serialize data to JSON format and write to a file
        public void JsonSerialize(List<Reservation> data, string filePath)
        {
            // Convert the data to JSON format
            string json = JsonSerializer.Serialize(data);

            // Write the JSON data to the specified file
            File.WriteAllText(filePath, json);
        }

        // Method to deserialize data from a JSON file
        public List<Reservation> JsonDeserialize(string filePath)
        {
            // Declare a variable to hold the deserialized data
            List<Reservation> data = null;

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Get the length of the file
                long fileLength = new FileInfo(filePath).Length;

                // Check if the file is not empty
                if (fileLength > 0)
                {
                    // Read the JSON data from the file
                    string json = File.ReadAllText(filePath);

                    // Deserialize the JSON data into a list of Reservation objects
                    data = JsonSerializer.Deserialize<List<Reservation>>(json);
                }
                else
                {
                    // If the file is empty, initialize an empty list
                    data = new List<Reservation>();
                }
            }

            // Return the deserialized data
            return data;
        }
    }
}
