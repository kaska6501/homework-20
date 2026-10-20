//***********************************************************
//* Домашнее задание по 20 лекции.                          *
//* Выполнила: Абдурахманова Х.Р., группа 2ИСП              *
//* Задание: Нахождение суммы элементов массива             *
//***********************************************************

using System;

namespace massivyZadanie
{
    internal class Program
    {
        static void HandleError(Exception ex) //вывод сообщения об ошибке
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        static void Checking() //вывод сообщения если пользователь неверно ввел значение
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Неподходящее значение!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Попробуйте еще раз: ");
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                int row = 10;
                int[] array = new int[row];
                string repeatAnswer;
                string answer;
                int minRange;
                int maxRange;
                Random rnd = new Random();
                long sum;
                int firstIndex;
                int secondIndex;
                Console.WriteLine("Здравствуйте!");
                do
                {
                    Console.WriteLine($"Размер массива - {row}, хотите заполнить его самостоятельно? \nЕсли да - введите  'да', иначе  - 'нет'");
                    answer = Console.ReadLine();
                    answer = answer.ToLower();

                    while (answer != "да" && answer != "нет") //если пользователь ввел вариант, непредусмотренный программой
                    {
                        Checking();
                        answer = Console.ReadLine();
                        answer = answer.ToLower();
                    }

                    if (answer == "да") //пользователь желает заполнить оставшиеся ячейки самостоятельно
                    {
                        for (int i = 0; i < array.Length; i++) //ввод массива пользователем через цикл
                        {
                            Console.Write($"Введите {i + 1} элемент массива: ");
                            string str = Console.ReadLine();
                            if (Int32.TryParse(str, out int resultConvert)) //ввел ли пользоваткль число
                            {
                                array[i] = resultConvert;
                            }
                            else
                            {
                                Checking();
                                i--;
                            }
                        }
                    }
                    else //пользователь не желает заполнять оставшиеся ячейки самостоятельно
                    {
                        Console.WriteLine("Хорошо, тогда это сделает генератор случайных чисел.");
                        Console.Write("Введите минимальное значение диапазона: ");
                        while (!Int32.TryParse(Console.ReadLine(), out minRange))
                        {
                            Checking();
                        }
                        Console.Write("Введите максимальное значение диапазона (не меньше минимального значения): ");
                        while (!Int32.TryParse(Console.ReadLine(), out maxRange) || maxRange < minRange) //подходит ли значение условию
                        {
                            Checking();
                        }
                        for (int i = 0; i < array.Length; i++) //программа вводит массив через генератор случайных чисел и выводит результат на экран
                        {
                            array[i] = rnd.Next(minRange, maxRange + 1);
                            Console.WriteLine($"Значение {i + 1} элемента массива = {array[i]}");
                        }
                    }

                    Console.Write("Введите порядковый номер первого элемента массива, сумму которого с другим элементом вы хотите найти: ");
                    while (!Int32.TryParse(Console.ReadLine(), out firstIndex) || firstIndex < 1 || firstIndex > row) //подходит ли значение условию
                    {
                        Checking();
                    }

                    Console.Write("Введите порядковый номер второго элемента массива, сумму которого с первым элементом вы хотите найти: ");
                    while (!Int32.TryParse(Console.ReadLine(), out secondIndex) || firstIndex < 1 || secondIndex > row) //подходит ли значение условию
                    {
                        Checking();
                    }

                    sum = array[firstIndex - 1] + array[secondIndex - 1];
                    Console.WriteLine($"Сумма = {sum}");

                    Console.WriteLine("Введите 'да' если хотите повторить программу, иначе - 'нет'. "); //многократное выполнение программы
                    repeatAnswer = Console.ReadLine();
                    repeatAnswer = repeatAnswer.ToLower();

                    while ((repeatAnswer != "да") && (repeatAnswer != "нет"))
                    {
                        Checking();
                        repeatAnswer = Console.ReadLine();
                        repeatAnswer = repeatAnswer.ToLower();
                    }
                    if (repeatAnswer == "нет") Console.Write("До свидания!");
                    else if (repeatAnswer == "да") Console.Clear();
                }
                while (repeatAnswer == "да");
                Console.ReadKey();
            }
            catch (FormatException fex)
            {
                HandleError(fex);
            }
            catch (StackOverflowException sofex)
            {
                HandleError(sofex);
            }
            catch (IndexOutOfRangeException ioorex)
            {
                HandleError(ioorex);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
