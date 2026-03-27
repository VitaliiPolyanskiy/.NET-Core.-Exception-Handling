using System;
using System.Text;

namespace Exception_Handling
{
    class Program
    {
        public static void ExcDemo1()
        {
            // Надамо можливість обробити помилку
            // системі динамічного керування C#

            int[] nums = new int[4];
            Console.WriteLine("Перед генерацією винятку.");
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
                Console.WriteLine("Перед генерацією винятку");
                for (int i = 0; i < 10; i++)
                {
                    nums[i] = i;
                    Console.WriteLine("nums [ {0 ] : 1}", i, nums[i]);
                }
                Console.WriteLine("Цей текст не відображається");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("стандартне повідомлення: ");
                Console.WriteLine(ex); // Виклик ToString() 
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("TargetSite: " + ex.TargetSite);
            }
            Console.WriteLine("Після інструкції catch.");
        }

        public static void GenException()
        {
            int[] nums = new int[4];
            Console.WriteLine("Перед генерацією винятку.");
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
            }
            Console.WriteLine("Цей текст не буде відображатися.");
        }

        public static void ExcDemo3()
        {
            /*  Виняток може згенерувати один метод,
                а перехопити — інший. */
            try
            {
                GenException();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Stack trace: " + ex.Message);
            }
            Console.WriteLine("Після інструкції catch.");
        }

        public static void ExcDemo4()
        {
            // Ділення на нуль.

            int[] numer = { 4, 8, 16, 32, 64, 128 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ExcDemo5()
        {
            // Використання кількох інструкцій catch

            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
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
        }

        public static void ExcDemo6()
        {
            // Перехоплення всіх винятків.
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
                }
                catch
                {
                    Console.WriteLine("Сталося певне виключення.");
                }
            }
        }

        public static void ExcDemo7()
        {
            // Використання вкладеного try-блоку
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            try
            {
                for (int i = 0; i < numer.Length; i++)
                {
                    try
                    {
                        Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
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
            // Генерування винятку вручну
            try
            {
                Console.WriteLine("До генерації винятку.");
                throw new Exception("Генерування винятку вручну");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Після блоку try/catch.");
        }

        public static void ReGenException()
        {
            // Повторне генерування винятку
            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw; // Генеруємо виняток повторно
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
                // Перехоплюємо повторно згенерований виняток
                Console.WriteLine(ex.Message);
            }
        }

        public static void UseFinally(int what)
        {
            // Використання блоку finally.
            int t;
            int[] nums = new int[2];
            Console.WriteLine("Отримуємо " + what);
            try
            {
                switch (what)
                {
                    case 0:
                        t = 10 / what; // Генеруємо помилку ділення на нуль.
                        break;
                    case 1:
                        nums[4] = 4; // Генеруємо помилку індексування масиву.
                        break;
                    case 2:
                        throw new StackOverflowException(); // Генеруємо помилку переповнення стека.
                    case 3:
                        return; // Повернення з блоку try.
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
                Console.WriteLine("Після завершення блоку try.");
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
                Console.WriteLine("Неперевірений на переповнення результат: " + result);

                result = checked((byte)(a * b));
                Console.WriteLine("Перевірений на переповнення результат: " + result);
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
                    Console.WriteLine("Неперевірений на переповнення результат: " + result);

                    a = 125;
                    b = 5;
                    result = (byte)(a * b);
                    Console.WriteLine("Неперевірений на переповнення результат: " + result);
                }

                checked
                {
                    a = 2;
                    b = 7;
                    result = (byte)(a * b);
                    Console.WriteLine("Перевірений на переповнення результат: " + result);

                    a = 127;
                    b = 127;
                    result = (byte)(a * b);
                    Console.WriteLine("Перевірений на переповнення результат: " + result);
                }
            }
            catch (OverflowException exc)
            {
                Console.WriteLine(exc);
            }
        }

        static void ExceptionFilters()
        {
            // Фільтри винятків дозволяють обробляти винятки залежно від певних умов.

            int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] denom = { 2, 0, 4, 4, 0, 8 };
            for (int i = 0; i < numer.Length; i++)
                try
                {
                    Console.WriteLine(numer[i] + " / " + denom[i] + " дорівнює " + numer[i] / denom[i]);
                    throw new Exception("Виняток під час роботи методу!");
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
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
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