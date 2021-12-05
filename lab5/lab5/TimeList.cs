using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace lab5
{
    [Serializable]
    public class TimeList
    {
        private List<TimeItem> timeItems = new List<TimeItem>();
        public void Add(TimeItem item)
        {
            timeItems.Add(item);
        }
        public void Save(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, timeItems);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Save to file " + filename + " failed");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finished saving");
            }
        }
        public void Load(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    timeItems = formatter.Deserialize(fs) as List<TimeItem>;
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finished loading");
            }
        }
        public override string ToString()
        {
            string str = "";
            foreach (var item in timeItems)
            {
                str += item.ToString();
            }
            return str;
        }
    }
}
