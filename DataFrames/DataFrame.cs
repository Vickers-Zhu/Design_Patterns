using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFrames
{
    public class Record
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Record()
        { }
        public Record(string name, string surname, string gender, int age)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Age = age;
        }
    }

    public class ListDataFrame : IEnumerable<Record>
    {
        List<Record> list;

        public double length
        {
            get
            {
                return list.Count;
            }
        }

        public ListDataFrame(List<Record> list)
        {
            this.list = list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Record> GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }

    public class FileDataFrameEnum : IEnumerator<Record>
    {
        List<Record> list;

        StreamReader sr;

        string filename;
        string obs;

        int position = -1;

        public FileDataFrameEnum(string filename)
        {
            this.filename = filename;
            sr = new StreamReader(filename);
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Record Current
        {
            get
            {
                try
                {
                    string[] record= obs.Split(',');
                    return new Record(record[0].Trim(), record[1].Trim(), record[2].Trim(), int.Parse(record[3]));
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return ((obs = sr.ReadLine()) != null);
        }

        public void Reset()
        {
            position = -1;
            sr = new StreamReader(filename);
        }

        public void Dispose()
        {
            sr.Close();
        }
    }

    public class FileDataFrame : IEnumerable<Record>
    {
        string filename;

        public FileDataFrame(string filename)
        {
            this.filename = filename;
        }

        public FileDataFrame(IEnumerable<Record> results, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Record obs in results)
                {
                    sw.WriteLine($"{obs.Name}, {obs.Surname}, {obs.Gender}, {obs.Age}");
                }
                sw.Close();
            }
        }

        public IEnumerator<Record> GetEnumerator()
        {
            return new FileDataFrameEnum(filename);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
