using System;

using System.Collections;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace CsharpLab1

{

    class Program

    {

        static void Main(string[] args)

        {

            int n = 0;

            while (true)
            {

                try

                {

                    Console.Write("Enter the number of houses: ");

                    n = int.Parse(Console.ReadLine());

                    break;

                }

                catch (System.FormatException e)
                {

                    Console.WriteLine(e.Message);

                }

            }

            int[] phones = new int[n];

            int[] cable = new int[n];



            getPhones(phones);



            for (int i = 0; i < n; i++)

            {

                countCableLength(phones, cable, i);

            }



            for (int i = 0; i < n; i++)

            {

                phones[i] = i + 1;

            }



            Array.Sort(cable, phones);

            output(phones, cable);



        }



        static void countCableLength(int[] phones, int[] cable, int curr)

        {

            cable[curr] = 0;

            for (int i = 0; i < phones.Length; i++)

            {

                cable[curr] += phones[i] * Math.Abs(curr - i);

            }

        }

        static void inputRandomly(int[] phones)

        {

            Random rand = new Random();

            for (int i = 0; i < phones.Length; i++)

            {

                phones[i] = rand.Next(0, 100);

                Console.WriteLine("House {0} - {1} phones", i + 1, phones[i]);

            }

        }

        static void inputManually(int[] phones)

        {

            for (int i = 0; i < phones.Length; i++)

            {



                while (true)

                {

                    try

                    {

                        Console.Write("Enter number of phones in {0} house: ", i + 1);

                        phones[i] = int.Parse(Console.ReadLine());

                        break;

                    }

                    catch (System.FormatException e)

                    {

                        Console.WriteLine(e.Message);

                    }

                }

            }

        }

        static void getPhones(int[] phones)

        {

            Console.Write("To input data manually enter \"i\" , to randomize enter any other character: ");

            char inp = char.Parse(Console.ReadLine());

            switch (inp)

            {

                case 'i':

                case 'I':

                    {

                        inputManually(phones);

                        break;

                    }

                default:

                    {

                        inputRandomly(phones);

                        break;

                    }

            }

        }

        static void output(int[] phones, int[] cable)

        {

            Console.WriteLine();

            for (int i = 0; i < phones.Length; i++)

            {

                Console.WriteLine("House {0} - Cable length {1}", phones[i], cable[i]);

            }



            Console.WriteLine("\nATC must be placed in house number {0} ", phones[0]);

            Console.ReadLine();

        }

    }

}