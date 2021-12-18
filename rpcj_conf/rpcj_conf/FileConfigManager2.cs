using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace FileConfigManager
{
    class FCM
    {
        char cfgmark = '=';

        /// <summary>
        /// Change the "=" mark to something else if needed only 1 character will be read
        /// </summary>
        /// <param name="mark">A character that separates the data name and the data itself</param>
        public void SetMark(char mark)
        {
            cfgmark = mark;
        }

        /// <summary>
        /// Reads all data from the file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <returns>The value of the data</returns>
        public void ReadAllData(string filename, out string[] data, out string[] value)
        {
            List<string> tmp = new List<string>();
            List<string> tmp2 = new List<string>();
            string tmpstr = null;
            string[] temp = new string[2];
            StreamReader sr = new StreamReader(filename, Encoding.Default);

            while (true)
            {
                tmpstr = sr.ReadLine();
                if (tmpstr == null) break;
                if (tmpstr[0] == '#') continue;

                if (!tmpstr.Contains(cfgmark.ToString())) continue;
                else
                {
                    temp = tmpstr.Split(cfgmark);
                    tmp.Add(temp[0].ToString());
                    tmp2.Add(temp[1].ToString());
                }
            }
            data = tmp.ToArray();
            value = tmp2.ToArray();
            sr.Close();
        }

        /// <summary>
        /// Reading Data from a file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns>The value of the data</returns>
        public string ReadData(string filename, string data)
        {
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            string line = null;
            while (true)
            {
                line = sr.ReadLine();
                if (line == null || line.Length <= 0) break;
                if (line[0] == '#') continue;

                if (!line.StartsWith(data + cfgmark)) continue;
                else if (line.StartsWith(data + cfgmark))
                {
                    sr.Close();
                    return line.Substring(data.Length + 1, line.Length - (data.Length + 1));
                }
            }
            sr.Close();
            return null;
        }

        /// <summary>
        /// Checks if the data exist
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns></returns>
        public bool CheckData(string filename, string data)
        {
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            string line = null;
            while (true)
            {
                line = sr.ReadLine();
                if (line == null || line.Length <= 0) break;
                if (!line.StartsWith(data)) continue;
                else if (line.StartsWith(data))
                {
                    sr.Close();
                    return true;
                }
            }
            sr.Close();
            return false;
        }

        /// <summary>
        /// Deleting the whole file, only use if you aren't using comments in original
        /// </summary>
        /// <param name="filename">The name of the file</param>
        public void DeleteData(string filename)
        {
            if (File.Exists(filename)) File.Delete(filename);
            File.Create(filename).Close();
        }

        /// <summary>
        /// Changing data without regenerating the whole file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The data needed to be changed</param>
        /// <param name="newval">The new value</param>
        public void ChangeData(string filename, string data, string newval)
        {
            string value = null;
            if (CheckData(filename, data) == true)
            {
                value = ReadData(filename, data);
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string tmp = sr.ReadToEnd().Replace("\n" + data + cfgmark + value, "\n" + data + cfgmark + newval);
                sr.Close();
                fs.Close();
                fs = new FileStream(filename, FileMode.Truncate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(tmp);
                sw.Close();
                fs.Close();
            }
            else WriteData(filename, data, newval);
        }

        /// <summary>
        /// Changing data with an array of string
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The data needed to be changed in array</param>
        /// <param name="newval">The new value in array</param>
        public void ChangeAllData(string filename, string[] data, string[] newval)
        {
            string value = null;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string tmp = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            for (int i = 0; i < data.Length; i++)
            {
                if (CheckData(filename, data[i]) == true)
                {
                    value = ReadData(filename, data[i]);
                    tmp = tmp.Replace("\n" + data[i] + cfgmark + value, "\n" + data[i] + cfgmark + newval[i]);
                }
                else
                    WriteData(filename, data[i], newval[i]);
            }
            fs = new FileStream(filename, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(tmp);
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Add new data if it isn't exist, need to be programmed before
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data needed to be added</param>
        /// <param name="value">The value</param>
        public void WriteData(string filename, string data, string value)
        {
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(data + cfgmark + value);
            sw.Close();
            fs.Close();
        }
    }
}