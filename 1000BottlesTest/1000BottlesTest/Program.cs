using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;
using static System.Convert;

namespace _1000BottlesTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Global variable like number of prisoners and bottles

            int prisoner = 10;
            bool[] Bottle = new bool[1000];
            // Bottle[76] = true;  //Check if code working
            int v =0;

            //Method to find poisoned bottle
            int IndicesOfBottlesDrunk()
            {

                for (int j = 0; j < prisoner; j++)
                {

                    int a = (int)Math.Pow(2, j);
                    int[] IndexBottleDrunked = new int[1000];
                    int count = 0;

                    //Building of array numbers of bottle of wine
                    for (int i = a; i < Bottle.Length; i++)
                    {

                        if ((i / a) % 2 == 1)
                        {

                            IndexBottleDrunked[count] = i;
                            count++;

                        }

                    }
                    // Checking numbers of wine if are poisoned
                    bool IsPrisonerAliveAfter24Hours(int[] Index)
                    {
                        for (int index = 0; index < IndexBottleDrunked.Count(); index++)
                        {
                            if (Bottle[ToInt32(Index.GetValue(index))] == true)
                            {
                                
                                v = ToInt32(Index.GetValue(index));
                                return true;

                            }

                        }

                        return false;
                    }
                   
                    bool Alive = IsPrisonerAliveAfter24Hours(IndexBottleDrunked);
                    for (int index = 0; index < IndexBottleDrunked.Count(); index++)
                    {
                        if (Alive == true)
                        {

                            WriteLine("Prisoner die!! He was drinking " + $"Bottie nr: {v}");
                            return v;

                        }
                        
                    
                    }

                }
                WriteLine("All prisoners alive, no poisoned wine!!");
                return v;
                
            }

            IndicesOfBottlesDrunk();
            ReadKey();
        }

        
    }
}
