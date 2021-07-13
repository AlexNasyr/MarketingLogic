using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarketingLogic {
    class MLogic {
        public int[] R { get; set; }
        public MLogic(string path, string file_name) {

            List<(int, string)> rows = ReadFile(path, file_name);
            R = MessageRader(rows);
        }

        public int[] GetMedian(int width) {
            List<int> med = new List<int>();
            for (int i = 0; i < R.Length - width; i++) {
                int[] frame = R[i..(i + width)];
                Array.Sort(frame);
                med.Add(frame[width / 2]);
            }
            return med.ToArray();
        }

        private static int[] MessageRader(List<(int, string)> rows) {
            List<int> R = new List<int>();
            foreach (var row in rows) {
                int[] elements = row.Item2.Trim().Split().Select(x => int.Parse(x)).ToArray();
                int result = -1;
                switch (row.Item1) {
                    case 1:
                        result = (elements.Aggregate((x, y) => x + y)) % 255;
                        break;
                    case 2:
                        result = (elements.Aggregate((x, y) => x * y)) % 255;
                        break;
                    case 3:
                        result = elements.Max();
                        break;
                    case 4:
                        result = elements.Min();
                        break;
                }
                if (result > 0) {
                    R.Add(result);
                }
            }
            return R.ToArray();
        }
        private List<(int, string)> ReadFile(string path, string file) {
            List<(int, string)> rows = new List<(int, string)>();
            using (StreamReader reader = new StreamReader($"{path}{file}")) {
                string row;
                while ((row = reader.ReadLine()) != null) {
                    rows.Add((row[0] - '0', row[1..]));
                }
            }
            return rows;
        }
    }
}
