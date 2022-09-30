using System;
using System.IO;
using System.Collections;
using static System.Console;

namespace CodeChallenge
{
    class StockMarket
    {
        /*program will be provided with a list of Computershare’s market-opening stock prices from the beginning of each trading day of the last month.
         It will be formatted as a comma separated list of two decimal floats (pounds and pence), listed in chronological order from day 1 through to day 30 of the month. */
        
       
        public static ArrayList fileReader(string path)
        {
            //Method to read the text file and convert to ArrayList
            ArrayList prize = new ArrayList();
            try
            {
                FileStream aFile = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);

                string lines = sr.ReadLine();
                char[] spearator = { ',' };
                string[] num = lines.Split(spearator);
                foreach (string e in num)
                    prize.Add(Convert.ToDouble(e));
                //WriteLine(a);

                sr.Close();
                return prize;
            }
            catch (IOException e)
            {
                WriteLine("An IO exception has been throw!");
                WriteLine(e.ToString());
                return prize;
            }
        }

        public static void fileWriter(string data)
        {
            //Method to write output to file name OutputFile.txt
            string text = data;
           try
            {
                FileStream aFile = new FileStream("OutputFile.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                //Write data to file.
                sw.WriteLine(text);
                sw.Close();
            }
            catch(IOException ex)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(ex.ToString());
                ReadKey();
                return;
            }
        } 

        public static double maxPrice(ArrayList list)
        {
            //Method to find the maximum in ArrayList
            double maxPrice = 0.0;
            foreach (double i in list)
            {

                if (i > maxPrice)
                    maxPrice = i;
            }
            //If the maximum price is on the first day, the program looks for the next maximum price to sell
            if (maxPrice == (double)list[0])
            {
                
                do
                {
                    maxPrice = 0.0;
                    int a = 1;
                    for (int i = a; i < list.Count; i++)
                    {
                        if ((double)list[i] > maxPrice)
                        {
                            maxPrice = (double)list[i];
                        }
                    }
                    
                } while (maxPrice == (double)list[1]);
                return maxPrice;
            }else
                 return maxPrice;
        }

        public static double minPrice(ArrayList list, double maxPrice)
        {
            //Method to find minimum in ArrayList
            int s = list.IndexOf(maxPrice);
            double minPrice = (double)list[0];
            for (int i = 0; i <= s; i++)
            {
                if ((double)list[i] < minPrice)
                    minPrice = (double)list[i];
            }
            return minPrice;
        }
        static void Main(string[] args) {

            string path;
            
            WriteLine("Welcome in stock market – “buy low, sell high”");
            WriteLine("Please choose source:");
            WriteLine("1 - SampleDataSet-1");
            WriteLine("2 - SampleDataSet-2");
            WriteLine("3 - Provide path to txt file with formatted as a comma separated list of two decimal floats (pounds and pence), listed in chronological order from day 1 through to day 30 of the month.");
            int numChoose;
            try
            {
                do
            {
                numChoose = Convert.ToInt32(ReadLine());
               
                    
                    switch (numChoose)
                    {
                        case 1:
                            ArrayList priceList = new ArrayList();
                            priceList = fileReader("ChallengeSampleDataSet1.txt");
                            double max = maxPrice(priceList);
                            double min = minPrice(priceList, max);
                            WriteLine((priceList.IndexOf(min) + 1) + "(" + min + ")," + (priceList.IndexOf(max) + 1) + "(" + max + ")");
                            fileWriter((priceList.IndexOf(min) + 1) + "(" + min + ")," + (priceList.IndexOf(max) + 1) + "(" + max + ")");
                            ReadKey();
                            Environment.Exit(0);
                            break;
                        case 2:
                            ArrayList prizeList1 = new ArrayList();
                            priceList = fileReader("ChallengeSampleDataSet2.txt");
                            double max1 = maxPrice(priceList);
                            double min1 = minPrice(priceList, max1);
                            WriteLine((priceList.IndexOf(min1) + 1) + "(" + min1 + ")," + (priceList.IndexOf(max1) + 1) + "(" + max1 + ")");
                            fileWriter((priceList.IndexOf(min1) + 1) + "(" + min1 + ")," + (priceList.IndexOf(max1) + 1) + "(" + max1 + ")");
                            ReadKey();
                            Environment.Exit(0);
                            break;
                        case 3:
                            path = ReadLine();
                            ArrayList priceList2 = new ArrayList();
                            priceList = fileReader(@path);
                            double max2 = maxPrice(priceList);
                            double min2 = minPrice(priceList, max2);
                            WriteLine((priceList.IndexOf(min2) + 1) + "(" + min2 + ")," + (priceList.IndexOf(max2) + 1) + "(" + max2 + ")");
                            fileWriter((priceList.IndexOf(min2) + 1) + "(" + min2 + ")," + (priceList.IndexOf(max2) + 1) + "(" + max2 + ")");
                            ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            try
                            {
                                WriteLine("Wrong number please try again.");

                            }catch(FormatException ex)
                            {
                                WriteLine("Wrong format");
                            }
                            break;
                    }
               

            } while (numChoose != 1 || numChoose != 2 || numChoose != 3);

            }
            catch (FormatException e)
            {
                WriteLine("Wrong format");
                WriteLine(e.ToString());
            }

        }
    }
}
