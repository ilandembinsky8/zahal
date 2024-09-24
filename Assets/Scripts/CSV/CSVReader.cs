using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CSV
{
    public class CSVReader
    {
        public List<Casualty> ReadCSVFile(string fileLoc)
        {
            List<Casualty> LastKinCasualties = new();
            StreamReader streamReader = new StreamReader(fileLoc);

            // "Discards" first line (titles)
            streamReader.ReadLine();
            bool continueReading = true;
            while (true)
            {
                string data_string = streamReader.ReadLine();
                if (data_string is null)
                {
                    break;
                }
                
                LastKinCasualties.Add(GetCasualtyByDataString(data_string));
                Debug.Log($"First On List is, LastName:{LastKinCasualties[0].LastName} First Name:{LastKinCasualties[0].FirstName} " +
                          $"Thanks for your service");
            }

            return LastKinCasualties;
        }

        Casualty GetCasualtyByDataString(string data_string)
        {
            Casualty LastKinCasualty = new();
            var data_values = data_string.Split(',');
            for (int i = 0; i < data_string.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        LastKinCasualty.LastName = data_values[i];
                        break;
                    case 1:
                        LastKinCasualty.LastName2 = data_values[i];
                        break;
                    case 2:
                        LastKinCasualty.FirstName = data_values[i];
                        break;
                    case 3:
                        LastKinCasualty.FirstName2 = data_values[i];
                        break;
                    case 4:
                        LastKinCasualty.NickName = data_values[i];
                        break;
                    case 5:
                        LastKinCasualty.Rank = data_values[i];
                        break;
                }
            }
            return LastKinCasualty;
        }
    }
}