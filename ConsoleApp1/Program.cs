using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        public static UchetDBEntities1 DB = new UchetDBEntities1();
        public static string[] maleNames = File.ReadAllLines("Names.txt", Encoding.UTF8);
        public static string[] maleSurnames = File.ReadAllLines("Surnames.txt", Encoding.UTF8);
        public static string[] logins = File.ReadAllLines("Logins.txt", Encoding.UTF8);
        public static int count;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("Сколько пользователей добавить?");

            try
            {
                int _count = Convert.ToInt32(Console.ReadLine());
                count = _count;
            }
            catch
            {
                Console.WriteLine("idi nahuy");
                return;
            }

            for(int i = 0; i < count; i++)
            {
                string generatedLogin = logins[rnd.Next(logins.GetUpperBound(0))];
                string generatedName = maleNames[rnd.Next(maleNames.GetUpperBound(0))];
                string generatedSurname = maleSurnames[rnd.Next(maleSurnames.GetUpperBound(0))];

                if (DB.Users.Where(u => u.Login == generatedLogin).FirstOrDefault() == null)
                {
                    Users newUser = new Users() { Login = generatedLogin, Password = "1111", FirstName = generatedName, LastName = generatedSurname, RoleId = 2, GroupID = rnd.Next(0, DB.Groups.Count() - 1) };
                    DB.Users.Add(newUser);

                    Console.WriteLine(i + ". Login = " + generatedLogin + " Name = " + generatedName + " Surname " + generatedSurname + "\n");
                }
                else
                {
                    Console.WriteLine("Пропущено");
                }
            }

            try
            {
                DB.SaveChanges();
                Console.WriteLine("ahuet");
            }
            catch
            {
                Console.WriteLine("nihuya");
            }

            Console.WriteLine("Gotovo");
        }
    }
}
