using System;
using System.Linq;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace GoogleSheetsGrades.bin
{
    class Program
    {

        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Students";
        static readonly string SpreadsheetId = "15iC0iaUH5AA6fbD9d15o0Abrfhl2bqajBNWurqOEP6Y";
        static readonly string sheet = "engenharia_de_software";
        static SheetsService service;


        static List<string> listOfGrades = new List<string>();
        static List<int> finalApprovalList = new List<int>();

        static void Main(string[] args)

        {

            GoogleCredential credential;
            using (var stream = new FileStream("clients_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            ReadEntries();
            UpdateEntry();

        }

        static void ReadEntries()
        {
            var range = $"{sheet}!A4:H27";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", row[1], row[2], row[3], row[4], row[5]);
                    int faltas = Convert.ToInt32(row[2]);
                    int p1 = Convert.ToInt32(row[3]);
                    int p2 = Convert.ToInt32(row[4]);
                    int p3 = Convert.ToInt32(row[5]);

                    int m = (p1 + p2 + p3) / 3;

                    if (m < 50)
                    {
                        Console.WriteLine("Reprovado por nota");
                        listOfGrades.Add("Reprovado por nota");
                        finalApprovalList.Add(0);
                    }
                    else if (faltas <= 15)
                    {
                        Console.WriteLine("Reprovado por falta");
                        listOfGrades.Add("Reprovado por falta");
                        finalApprovalList.Add(0);
                    }
                    else if (50 <= m && m < 70)
                    {
                        Console.WriteLine("Exame final");
                        listOfGrades.Add("Exame final");

                        int naf = 100 - m;

                        if (50 <= (m + naf) / 2) ;
                        {
                            finalApprovalList.Add(naf);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Aprovado");
                        listOfGrades.Add("Aprovado");
                        finalApprovalList.Add(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("No data was found.");
            }
        }

        static void UpdateEntry()
        {
            int i = 4;
            int a = 4;
            foreach (var situacao in listOfGrades)
            {
                var range = $"{sheet}!G{i}";
                i++;
                var valueRange = new ValueRange();
                var objectList = new List<object>() { situacao };
                valueRange.Values = new List<IList<object>> { objectList };

                var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var updateResponse = updateRequest.Execute();
            }

            foreach (var nota in finalApprovalList)
            {
                var range = $"{sheet}!H{a}";
                a++;
                var valueRange = new ValueRange();
                var objectList = new List<object>() { nota };
                valueRange.Values = new List<IList<object>> { objectList };

                var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var updateResponse = updateRequest.Execute();
            }

        }
    }
}

