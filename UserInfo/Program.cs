using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var userInfo = GetUserData();
            ShowUserData(userInfo);
        }

        public static void ShowUserData((string name, string lastname, int age, bool hasPet, int petCount, string[] petNames, string[] favColors) UserData)
        {
            Console.WriteLine("Имя пользователя: {0}", UserData.name);
            Console.WriteLine("Фамилия пользователя: {0}", UserData.lastname);
            Console.WriteLine("Возраст пользователя: {0}", UserData.age);

            if (UserData.hasPet == true)
            {
                Console.WriteLine("Наличие питомца: да");
                Console.WriteLine("Количество питомцев: {0}", UserData.petCount);

                for (int i = 0; i < UserData.petNames.Length; i++)
                {
                    Console.WriteLine("Имя питомца номер {0} - {1}", i + 1, UserData.petNames[i]);
                }
            }
            else
            {
                Console.WriteLine("Наличие питомца: нет");
            }

            for (int i = 0; i < UserData.favColors.Length; i++)
            {
                Console.WriteLine("Любимый цвет номер {0} - {1}", i + 1, UserData.favColors[i]);
            }
        }
        public static (string name, string lastname, int age, bool hasPet, int petCount, string[] petNames, string[] favColors) GetUserData()
        {
            var name = EnterData("имя пользователя");
            var lastname = EnterData("фамилию пользователя");
            int age = EnterNumber("возраст пользователя");

            Console.WriteLine("Наличие питомца. Укажите да или нет.");
            bool hasPet = false;
            string petAnswer = Console.ReadLine().ToUpper();
            if (petAnswer == "Да".ToUpper())
            {
                hasPet = true;
            }

            int petCount = 0;
            if (hasPet == true)
            {
                petCount = EnterNumber("количество питомцев");
            }

            string[] petNames = SetArray(petCount, "кличку питомца");

            int favColorsNumber = EnterNumber("количество любимых цветов");

            string[] favColors = SetArray(favColorsNumber, "любимый цвет");

            (string name, string lastname, int age, bool hasPet, int petCount, string[] petNames, string[] favColors) UserData;

            UserData.name = name;
            UserData.lastname = lastname;
            UserData.age = age;
            UserData.hasPet = hasPet;
            UserData.petCount = petCount;
            UserData.petNames = petNames;
            UserData.favColors = favColors;

            return UserData;
        }

        private static string[] SetArray(int arraySize, string text)
        {

            string[] result = new string[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                var arrayValue = EnterData(text);
                result[i] = arrayValue;
            }
            return result;
        }

        private static int EnterNumber(string text)
        {
            int age;
            bool isCorrectNumber;
            do
            {
                Console.Write("Введите {0}: ", text);
                string input = Console.ReadLine();
                isCorrectNumber = CheckData(input, out age);
            }
            while (isCorrectNumber == false);
            return age;
        }

        private static string EnterData(string text)
        {
            string name;
            bool condition;
            do
            {
                Console.Write("Введите {0}: ", text);
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    condition = false;
                }
                else
                {
                    condition = true;
                }
            }
            while (condition == false);
            return name;
        }

        public static bool CheckData(string number, out int corrnumber)
        {
            bool result = false;
            int x = 0;
            if (int.TryParse(number, out int intnumber))
            {
                if (intnumber > 0)
                {
                    x = intnumber;
                    result = true;
                }
            }
            else
            {
                x = 0;
                result = false;
            }
            corrnumber = x;
            return result;
        }
    }
}
