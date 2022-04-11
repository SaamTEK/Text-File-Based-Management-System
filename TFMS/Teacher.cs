using System;
using System.Collections.Generic;

namespace TFMS
{
    public static class Teacher
    {
        public static void AddNewTeacher()
        {
            string name = GetInput("\nEnter Teacher name");
            string id = GetInput("Enter ID");
            string cls = GetInput("Enter class");
            string sec = GetInput("Enter Section").ToUpper();

            string data = $"'{id}','{name}','{cls}'/'{sec}'";

            StoreController.SaveData(data);
            GetFormattedResponse("Teacher added successfully.");
        }

        public static void FilterTeachers() {
            string filter = GetInput("\nEnter filter parameter (ID, Name or Class/Section)");

            List<string> filteredList = StoreController.ReadData(filter);

            Console.WriteLine();
            Console.WriteLine("Result:");

            GetFormattedTableOutput(filteredList);
        }

        public static void GetAllTeachers()
        {
            List<string> teachers = StoreController.ReadAllData();

            GetFormattedTableOutput(teachers);
        }

        public static void UpdateTeacher()
        {
            Console.WriteLine();

            int index = GetIndexInput("Enter index of Teacher to update");

            

            string indexData = StoreController.GetDataAtIndex(index);

            Console.WriteLine("\nSelected Teacher: ");
            GetFormattedRow(indexData, true);
            Console.WriteLine();

            string[] splitData = indexData.Split(',');
            string newID = GetInput("Enter new ID", splitData[1]);
            string newName = GetInput("Enter new name", splitData[2]);
            string[] splitCS = splitData[3].Split('/');
            string newClass = GetInput("Enter new Class", splitCS[0]);
            string newSec = GetInput("Enter new Section", splitCS[1]).ToUpper();

            string newData = $"'{newID}','{newName}','{newClass}'/'{newSec}'";
            StoreController.UpdateData(newData, index);
            GetFormattedResponse($"Updated Teacher: {newData}");
        }

        public static void DeleteTeacher()
        {
            Console.WriteLine();

            int index = GetIndexInput("Enter index of Teacher to delete");

            /*do
            {
                index = Convert.ToInt32(GetInput("Enter index of Teacher to delete"));
                if(index >= StoreController.GetNumberOfRows())
                {
                    Console.WriteLine($"Please enter index within range (0 - {(StoreController.GetNumberOfRows() - 1)})");
                }
            } while (index >= StoreController.GetNumberOfRows());*/

            GetFormattedRow(StoreController.GetDataAtIndex(index), true);

            StoreController.DeleteData(index);
            GetFormattedResponse("Teacher deleted successfully.");
        }

        private static string GetInput(string Prompt)
        {
            string Result;
            do
            {
                Console.Write(Prompt + ": ");
                Result = Console.ReadLine();
                if (string.IsNullOrEmpty(Result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
                else if (Result.Contains(","))
                {
                    Console.WriteLine("Contains an invalid character. Try again.");
                }
            } while (string.IsNullOrEmpty(Result) | Result.Contains(","));
            return Result;
        }

        private static string GetInput(string Prompt, string PrevValue)
        {
            string Result;
            Console.Write(Prompt + ": ");
            Result = Console.ReadLine();
            if (string.IsNullOrEmpty(Result))
            {
                Console.WriteLine("Empty input, retaining previous value.");
                return PrevValue.Trim('\'');
            }
            else if (Result.Contains(","))
            {
                Console.WriteLine("Contains an invalid character. Try again.");
            }
            return Result;
        }

        private static int GetIndexInput(string Prompt)
        {
            int index;
            do
            {
                index = Convert.ToInt32(GetInput(Prompt));
                if (index >= StoreController.GetNumberOfRows() || index < 0)
                {
                    Console.WriteLine($"Please enter index within range (0 - {(StoreController.GetNumberOfRows() - 1)})");
                }
            } while (index >= StoreController.GetNumberOfRows() || index < 0);
            return index;
        }

        private static void GetFormattedTableOutput(List<string> data)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Index| ID        | Name                     |       Class/Sec");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (string item in data)
            {
                GetFormattedRow(item);
            }
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Press any key to return to main menu... ");
            Console.ReadKey();
        }

        private static void GetFormattedRow(string data)
        {
            // string[] splitData = data.Split(',');
            string[] splitData = GetFormatedItem(data.Split(','));
            Console.WriteLine(String.Format("{0,4} | {1,-9} | {2,-24} | {3,15}", splitData[0], splitData[1], splitData[2], splitData[3]));
        }

        private static void GetFormattedRow(string data, bool showBorder)
        {
            if (showBorder)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Index| ID        | Name                     |       Class/Sec");
                Console.WriteLine("-------------------------------------------------------------");
                string[] splitData = GetFormatedItem(data.Split(','));
                Console.WriteLine(String.Format("{0,4} | {1,-9} | {2,-24} | {3,15}", splitData[0], splitData[1], splitData[2], splitData[3]));
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        private static void GetFormattedResponse(string response)
        {
            Console.WriteLine();
            Console.Write(response);
            GetAllTeachers();
        }

        private static string[] GetFormatedItem(string[] item)
        {
            string[] itemObj = item;
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Contains("\'"))
                {
                    if(item[i].Contains("/"))
                    {
                        itemObj[i] = $"{item[i].Split('/')[0].Trim('\'')}/{item[i].Split('/')[1].Trim('\'')}";
                    }
                    itemObj[i] = item[i].Trim('\'');
                }
            }
            return itemObj;
        }
        
    }
}
