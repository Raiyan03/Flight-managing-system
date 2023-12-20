using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class DataSerialization
    {
        public void JsonSerialize(List<Reservation> data, string filePath)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        public List<Reservation> JsonDeserialize(string filePath)
        {
            List<Reservation> data = null;

            if (File.Exists(filePath))
            {
                long fileLength = new FileInfo(filePath).Length;
                if (fileLength > 0)
                {
                    string json = File.ReadAllText(filePath);
                    data = JsonSerializer.Deserialize<List<Reservation>>(json);
                }
                else
                {
                    data = new List<Reservation>();
                }
                
            }

            return data;
        }
    }
}

