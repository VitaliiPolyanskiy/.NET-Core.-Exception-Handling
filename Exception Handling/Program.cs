using System;

namespace Exception_Handling
{
    class Program
    {
        public static void ExcDemo1()
        {
            // Предоставим возможность обработать ошибку
            // С#-системе динамического управления

            int[] nums = new int[4];
            Console.WriteLine("Перед генерированием исключения.");
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums [ {0 ] : 1}", i, nums[i]);
            }
        }

        public static void ExcDemo2()
        {
            int[] nums = new int[4];
            try
            {
                Console.WriteLine("Перед генерированием исключения");
                for (int i = 0; i < 10; i++)
                {
                    nums[i] = i;
                    Console.WriteLine("nums [ {0 ] : 1}", i, nums[i]);
                }
                Console.WriteLine("Этот текст не отображается");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("стандартное сообщение: ");
                Console.WriteLine(ex); // Вызов ToString() 
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("TargetSite: " + ex.TargetSite);
            }
            Console.WriteLine("После catch-инструкции.");
        }

        public static void GenException()
        {
            int[] nums = new int[4];
            Console.WriteLine("Перед генерированием исключения.");
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
            }
            Console.WriteLine("Этот текст не будет отображаться.");
        }

        public static void ExcDemo3()
        {
            /*  Исключение может сгенерировать один метод, а
                перехватить — другой. */
            try
            {
                GenException();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Stack trace: " + ex.StackTrace);
            }
            Console.WriteLine("После catch-инструкции.");
        }

        public static void ExcDemo4()
        {
            // Деление на нуль.

            int[] numer = { 4, 8, 16, 32, 64, 128 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public static void ExcDemo5()
        {
            // Использование нескольких catch-инструкций

            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                    Console.WriteLine("{0", numer[i]);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public static void ExcDemo6()
        {
            // Перехват всех исключений.
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                }
                catch
                {
                    Console.WriteLine("Произошло некоторое исключение.");
                }
        }

        public static void ExcDemo7()
        {
            // Использование вложенного try-блока
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            try
            {
                for (int i = 0; i < numer.Length; i++)
                {
                    try
                    {
                        Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExcDemo8()
        {
            // Генерирование исключения вручную
            try
            {
                Console.WriteLine("До генерирования исключения.");
                throw new Exception("Генерирование исключения вручную");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("После try/catch-блока.");
        }

        public static void ReGenException()
        {
            // Повторное генерирование исключения
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw; // Генерируем исключение повторно
                }
            }
        }

        public static void ExcDemo9()
        {
            try
            {
                ReGenException();
            }
            catch (IndexOutOfRangeException ex)
            {
                // Перехватываем повторно сгенерированное исключение
                Console.WriteLine(ex.Message);
            }
        }

        public static void UseFinally(int what)
        {
            // Использование блока finally.
            int t;
            int[] nums = new int[2];
            Console.WriteLine("Получаем " + what);
            try
            {
                switch (what)
                {
                    case 0:
                        t = 10 / what; // Генерируем ошибку деления на нуль.
                        break;
                    case 1:
                        nums[4] = 4; // Генерируем ошибку индексирования массива.
                        break;
                    case 2:
                        throw new StackOverflowException(); // Генерируем ошибку переполнения стека.
                    case 3:
                        return; // Возврат из try-блока.
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                Console.WriteLine("По окончании try-блока.");
            }

        }

        public static void ExcDemo10()
        {
            for (int i = 0; i < 4; i++)
            {
                UseFinally(i);
                Console.WriteLine();
            }
        }

        static void CheckedDemo()
        {
            byte a, b;
            byte result;

            a = 127;
            b = 127;

            try
            {
                result = unchecked((byte)(a * b));
                Console.WriteLine("Непроверенный на переполнение результат: " + result);

                result = checked((byte)(a * b));
                Console.WriteLine("Проверенный на переполнение результат: " + result);
            }
            catch (OverflowException exc)
            {
                Console.WriteLine(exc);
            }

            try
            {
                unchecked
                {
                    a = 127;
                    b = 127;
                    result = (byte)(a * b);
                    Console.WriteLine("Непроверенный на переполнение результат: " + result);

                    a = 125;
                    b = 5;
                    result = (byte)(a * b);
                    Console.WriteLine("Непроверенный на переполнение результат: " + result);
                }

                checked
                {
                    a = 2;
                    b = 7;
                    result = (byte)(a * b);
                    Console.WriteLine("Проверенный на переполнение результат: " + result);

                    a = 127;
                    b = 127;
                    result = (byte)(a * b);
                    Console.WriteLine("Проверенный на переполнение результат: " + result);
                }
            }
            catch (OverflowException exc)
            {
                Console.WriteLine(exc);
            }
        }

        static void ExceptionFilters()
        {
            // Фильтры исключений позволяют обрабатывать исключения в зависимости от определенных условий.

            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                    throw new Exception("Исключение при работе метода!");
                }
                catch (Exception ex) when (denom[i] == 0)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (i >= denom.Length)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        static void Main(string[] args)
        {
            //ExcDemo1();
            ExcDemo2();
            ExcDemo3();
            ExcDemo4();
            ExcDemo5();
            ExcDemo6();
            ExcDemo7();
            ExcDemo8();
            ExcDemo9();
            ExcDemo10();
            CheckedDemo();
            ExceptionFilters();
        }
    }
}
