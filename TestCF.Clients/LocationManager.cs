using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace PFWServiceApplication
{
    /// <summary>
    /// Location Manager is a utlity class that reads all JSON files from a given set of paths
    /// and stores the mapping into a dictionary
    /// </summary>

    public class PFWLocationManager 
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        const string file_type = "*.txt";
        List<string> location_list = new List<string>();

        public PFWLocationManager() { }

        public PFWLocationManager(string path)
        {
            location_list.Add(path);
        }


        public void add_path(string location_path)
        {
            location_list.Add(location_path);
        }

        public void remove_path(string location_path)
        {
            if (location_list.Contains(location_path))
            {
                location_list.Remove(location_path);
            }
            else
            {
                Console.WriteLine("Error: Path to be remove not found.");
            }
        }

        /// <summary>
        /// parse all JSON files for the given list of locations and store their content in the map
        /// </summary>
        public Dictionary<string, string> parse()
        {
            //possible user error
            //1. no file                    catched
            //2. incorrect file format      catched
            //3. multiple files            if there's key conflit, throw
            try
            {
                foreach (string path in location_list)
                {
                    string[] files = System.IO.Directory.GetFiles(path, file_type, System.IO.SearchOption.AllDirectories);
                    if (files == null || files.Length == 0)
                    {
                        //no file exists
                        Console.WriteLine("missing config path file, PFWLocationManager");
                        throw new NullReferenceException("Config JSON files does not exist");
                    }

                    foreach (string file in files)
                    {
                        JObject JSON_object = JObject.Parse(File.ReadAllText(file));
                        Dictionary<string, object> JSON_dict = JSON_object.ToObject<Dictionary<string, object>>();
                        var keyset = JSON_dict.Keys;
                        foreach (string key in keyset)
                        {
                            object value = JSON_dict[key];
                            if (value.GetType() == typeof(string))
                            {
                                map[key] = (string)value;
                            }
                            else
                            {
                                //wrong format
                                Console.WriteLine("Config file content corrupted, PFWLocationManager");
                                throw new IOException("Parsing failed");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("JSON file parsing failed. " + e.Message);
            }
            return map;
        }

        //private void JSON_Parser_Helper(Dictionary<string, object> JSON_dict, Dictionary<string, string> result)
        //{   
        //    //add try catch
        //    var keyset = JSON_dict.Keys;
        //    foreach (string key in keyset)
        //    {
        //        object value = JSON_dict[key];
        //        if (value.GetType() == typeof(Dictionary<string, object>))
        //        {
        //            result[key] = value.ToString();
        //            JSON_Parser_Helper((Dictionary<string, object>)value, result);
        //        }
        //        else
        //        {
        //            result[key] = value.ToString();
        //        }
        //    }
        //}

        public Dictionary<string, string> getMap()
        {
            return map;
        }

        public string getSetting(string key)
        {
            return map[key];
        }

        public string GetSetting(string key)
        {
            return map[key];
        }
    }
}
