using System;

namespace TFMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Rainbow School Teacher Management System");
            Console.WriteLine("----------------------------------------");
            StoreController.GetStoreStats();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) View All Teachers");
            Console.WriteLine("2) Add a new Teacher");
            Console.WriteLine("3) Filter Teachers");
            Console.WriteLine("4) Update Teacher");
            Console.WriteLine("5) Delete Teacher");
            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Teacher.GetAllTeachers();
                    return true;
                case "2":
                    Teacher.AddNewTeacher();
                    return true;
                case "3":
                    Teacher.FilterTeachers();
                    return true;
                case "4":
                    Teacher.UpdateTeacher();
                    return true;
                case "5":
                    Teacher.DeleteTeacher();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }
    }
}
