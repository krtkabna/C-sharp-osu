using System;
using System.Collections.Generic;

namespace Laba_Osi
{
    class Program
    {
        public abstract class Pair
        {
            protected int FirstPairElement { get; set; }
            protected int SeconPairElement { get; set; }

            public abstract Pair Substract(Pair value);
            public abstract Pair Add(Pair value);

        }

        public class Fractional : Pair
        {
            public int Integer
            {
                get
                {
                    return FirstPairElement;
                }
                set { FirstPairElement = value; }
            }

            public int Partitive
            {
                get
                {
                    return SeconPairElement;
                }
                set
                {
                    SeconPairElement = value;
                    if (SeconPairElement > 99)
                    {
                        SeconPairElement -= 100;
                        Integer += 1;
                    }
                    if (SeconPairElement < 0)
                    {
                        SeconPairElement += 100;
                        Integer -= 1;
                    }
                }
            }
            public override Pair Add(Pair value)
            {
                Fractional newValue = new Fractional();
                newValue.Integer = this.Integer + (value as Fractional).Integer;
                newValue.Partitive = this.Partitive + (value as Fractional).Partitive;
                return newValue;
            }

            public override Pair Substract(Pair value)
            {
                Fractional newValue = new Fractional();
                newValue.Integer = this.Integer - (value as Fractional).Integer;
                newValue.Partitive = this.Partitive - (value as Fractional).Partitive;
                return newValue;
            }

            public override string ToString() // Переопределение метода ToString у базового класса Object
            {
                return string.Format("{0}.{1}", this.Integer, this.Partitive);
            }
        }

        public class LongLong : Pair
        {
            public int First
            {
                get
                {
                    return FirstPairElement;
                }
                set { FirstPairElement = value; }
            }

            public int Second
            {
                get
                {
                    return SeconPairElement;
                }
                set
                {
                    SeconPairElement = value;
                    if (SeconPairElement > 999)
                    {
                        SeconPairElement -= 1000;
                        First += 1;
                    }
                    if (SeconPairElement < 0)
                    {
                        SeconPairElement += 1000;
                        First -= 1;
                    }
                }
            }
            public override Pair Add(Pair value)
            {
                LongLong newValue = new LongLong();
                newValue.First = this.First + (value as LongLong).First;
                newValue.Second = this.Second + (value as LongLong).Second;
                return newValue;
            }

            public override Pair Substract(Pair value)
            {
                LongLong newValue = new LongLong();
                newValue.First = this.First - (value as LongLong).First;
                newValue.Second = this.Second - (value as LongLong).Second;
                return newValue;
            }

            public override string ToString() // Переопределение метода ToString у базового класса Object
            {
                return string.Format("{0} {1}", this.First, this.Second);
            }
        }

        public class Series : List<Pair>
        {
            private int size;
            public Pair[] array;
            private int index = 0;

            public Series(int sizet)
            {
                size = sizet;
                array = new Pair[size];
            }

            public new Boolean Add(Pair x)
            {
                array[index] = x;
                index++;
                return true;
            }

            public int Length
            {
                get { return array.Length; }
            }

            public override string ToString() // Переопределение метода ToString у базового класса Object
            {
                String ebat_kopat = " ";
                for (int i = 0; i < Length; i++)
                {
                    ebat_kopat += string.Format(i + 1 + ". {0}" + "\n", this.array[i]);
                }
                return ebat_kopat;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Series))
                    return false;
                else
                    return ((Series)obj).array == this.array;
            }

            public static bool operator == (Series one, Series two)
            {
                if ((Object)one == null || (Object)two == null) { return false; }

                return one.Equals(two);
            }

            public static bool operator !=(Series one, Series two)
            {
                if ((Object)one == null || (Object)two == null) { return false; }

                return !one.Equals(two);
            }

            public override int GetHashCode()
            {
                try
                {
                    return Convert.ToInt32(this.array);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return -1;
                }
            }

            public Series DeepCopy()
            {
                Series obj = new Series(size);
                return obj;
            }

        }

        

        static void Main(string[] args)
        {
            Fractional firstFractional = new Fractional();
            Fractional secondFractional = new Fractional();
            firstFractional.Integer = 99;
            firstFractional.Partitive = 80;
            secondFractional.Integer = 1;
            secondFractional.Partitive = 19;

            LongLong firstLongLong = new LongLong();
            LongLong secondLongLong = new LongLong();
            firstLongLong.First = 999;
            firstLongLong.Second = 888; 
            secondLongLong.First = 0;
            secondLongLong.Second = 300;

            Series Steven = new Series(4);
            Steven.Add(firstFractional);
            Steven.Add(secondFractional);
            Steven.Add(firstLongLong);
            Steven.Add(secondLongLong);

            Console.WriteLine(Steven.ToString());


            Console.ReadKey();
            Console.WriteLine("Sum: {0} + {1} = {2}", firstFractional.ToString(), secondFractional.ToString(), (firstFractional.Add(secondFractional).ToString()));

            Console.WriteLine("Sum: {0} + {1} = {2}", firstLongLong.ToString(), secondLongLong.ToString(), (firstLongLong.Add(secondLongLong).ToString()));

            Console.WriteLine("P. S. In the university they call me \"osa\"");
        }
    }
}

