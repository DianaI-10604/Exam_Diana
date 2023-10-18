using Microsoft.VisualBasic;

namespace Экзамен_Диана
{
    class Program
    {
        static void Main()
        {
            School_Diary diary = new School_Diary();

            int exit = 0;
            while (exit != 1)
            {
                diary.InfoOutput(); //выводим информацию
                Console.Write("Нажмите Enter для перехода к основному меню. Если хотите выйти, напишите 1: ");
                string user_choice = Console.ReadLine();

                if (user_choice == "1")
                    exit = 1;
                else
                {
                    Console.Clear();
                }    
            }     
        }
    }

    class School_Diary
    {
        static int[,] marks = new int[7, 10]; //10 оценок по каждому предмету
        static string[] homework = new string[7]
        {
            "Стр 9-10 уч, упражнение 8",
            "Стр 11-12, 17-18, номера 23(а), 24(г)",
            "Не задано",
            "Читать параграфы 4-5, ответить на вопросы на стр 29-30",
            "Выписать формулу алкенов и выполнить дз в тетради",
            "Решить в задачи тетради",
            "Написать эссе на одну из тем, указанных в тетради"
        };
        //7 предметов и 7 домашних заданий
        //индекс этого массива = индексу массива subjects

        private int user_choice;
        static string[,] schedule = new string[5, 5]
        {
            {"Рус яз","Матем", "Рус яз","Матем","История"},
            {"Химия", "Химия", "Физ-ра", "Матем","История"},
            {"Химия", "Химия", "Матем", "Матем","История"},
            {"Химия", "Химия", "Физ-ра", "Физ-ра","Обществознание"},
            {"Химия", "Химия", "Физ-ра", "Физика","Химия"},
        };

        static string[] subjects = new string[] {"Русский язык", "Математика", "Физкультура", "История", "Химия", "Физика", "Обществознание" };

        static string[] dates = new string[5] { "16.10.23", "17.10.23", "18.10.23", "19.10.23", "20.10.23" };
        static string[] days = new string[5] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
        
        public void InfoOutput()
        {
            Console.WriteLine("Вы зашли в Мой Дневник! Выберите действие: \n");
            Console.Write("1.Посмотреть расписание за прошедшую неделю\n2.Показать оценки по предметам\n3.Показать домашнее задание: ");
            user_choice = Convert.ToInt32(Console.ReadLine());

            if (user_choice == 1)
            {
                Schedule(); //выводим расписание
            }
            else if (user_choice == 2)
            {
                Marks(marks); //покакзываем оценки по нужному предмету 
            }    
            else
            {
                Homework(); //выводим домашнее задание
            }  
        }

        public void Homework()
        {
            Console.WriteLine("Выберите предмет, по которому хотите узнать домашнее задание: ");
            Subjects_Output();

            user_choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(homework[user_choice - 1]); //вывод дз по указанному индексу

        }
        public void Schedule() //расписание
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(days[i]); //выводим день
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\t" + schedule[i, j] + " " + dates[j]); //выводим все предметы и дату
                }
                Console.WriteLine();
            }
        }

        public void Marks(int[,] marks)
        {
            Console.WriteLine( "Оценки: \n");
            Random rnd = new Random();
            for (int i = 0; i < 7;  i++) //предметы
            {
                Console.Write(subjects[i] + ": ");
                for (int j = 0; j < 10; j++) //оценки
                {
                    int mark = rnd.Next(2, 6);
                    marks[i, j] = mark; //записываем 10 оценок для каждого предмета
                                        //индекс этого массива = индексу массива subjects
                    Console.Write(marks[i, j] + " ");
                }
                Console.WriteLine();
            } //записали 

            Console.WriteLine( );
            Average_Mark(); //выводим среднюю оценку
        }

        public void Subjects_Output() //вывод предметов
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {subjects[i]}");
            } 
        }

        public void Average_Mark() //выбираем предмет для вывода средней оценки
        {
            Console.WriteLine("Выберите предмет для вывода среднего балла: ");

            Subjects_Output(); //вывод предметов
            user_choice = Convert.ToInt32(Console.ReadLine());

            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += marks[user_choice - 1, i];
            }
            Console.WriteLine($"Средний балл по предмету {subjects[user_choice - 1]} = {sum / 10}"); //10 - количество оценок
        }
    }
}
