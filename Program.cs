using System;
using System.Collections.Generic;

namespace dictionaries_practices
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
                stocks.Add("GM", "General Motors");
                stocks.Add("CAT", "Caterpillar");
                stocks.Add("NSS", "Nashville Software School");
                stocks.Add("BNA", "Nashville");

            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>>();
                purchases.Add (new Dictionary<string, double>(){ {"GM", 230.21} });
                purchases.Add (new Dictionary<string, double>(){ {"GM", 580.98} });
                purchases.Add (new Dictionary<string, double>(){ {"GM", 406.34} });

                purchases.Add (new Dictionary<string, double>(){ {"CAT", 100.21} });
                purchases.Add (new Dictionary<string, double>(){ {"CAT", 130.98} });
                purchases.Add (new Dictionary<string, double>(){ {"CAT", 46.34} });

                purchases.Add (new Dictionary<string, double>(){ {"NSS", 20.21} });
                purchases.Add (new Dictionary<string, double>(){ {"NSS", 80.98} });
                purchases.Add (new Dictionary<string, double>(){ {"NSS", 6.34} });

                purchases.Add (new Dictionary<string, double>(){ {"BNA", 7230.21} });
                purchases.Add (new Dictionary<string, double>(){ {"BNA", 4580.98} });
                purchases.Add (new Dictionary<string, double>(){ {"BNA", 1406.34} });

            /*
            Define a new Dictionary to hold the aggregated purchase information.
            - The key should be a string that is the full company name.
            - The value will be the total valuation of each stock
            */
            Dictionary<string, double> stockReport = new Dictionary<string, double>();

            /*
            Iterate over the purchases and record the valuation
            for each stock.
            */
            foreach (Dictionary<string, double> purchase in purchases)
            {
                foreach (KeyValuePair<string, double> kvp in purchase)
                {
                    if (stockReport.ContainsKey(stocks[kvp.Key])){
                    stockReport[stocks[kvp.Key]] += kvp.Value;
                    } else {
                    stockReport[stocks[kvp.Key]] = kvp.Value;
                    }
                }
            }
            /* display each stock (4 total) with their value total */
            Console.WriteLine("-----");
            foreach(KeyValuePair<string, double> kvp in stockReport)
            {
                Console.WriteLine($"The position in {kvp.Key} is worth {kvp.Value}");
            }

            Console.WriteLine("-----PLANETS------");

            List<string> planetList = new List<string>(){"Mercury", "Venus", "Earth", "Mars", "Saturn", "Jupiter", "Neptune", "Uranus"};

            /*
            Create another list containing dictionaries. Each dictionary will hold the name of a spacecraft that we have launched, and the name of the planet that it has visited. If it visited more than one planet, just pick one.
            */

            List<Dictionary<string, string>> probes =
                new List<Dictionary<string, string>>();
                    probes.Add(new Dictionary<string, string>(){ {"Mercury", "Mariner 10"} });
                    probes.Add(new Dictionary<string, string>(){ {"Mercury", "Mariner 1"} });
                    probes.Add(new Dictionary<string, string>(){ {"Venus", "Venera 1"} });
                    probes.Add(new Dictionary<string, string>(){ {"Earth", "Pioneer 10"} });
                    probes.Add(new Dictionary<string, string>(){ {"Mars", "Mariner 6"} });
                    probes.Add(new Dictionary<string, string>(){ {"Jupiter", "Voyager 1"} });
                    probes.Add(new Dictionary<string, string>(){ {"Saturn", "Venera 1"} });
                    probes.Add(new Dictionary<string, string>(){ {"Uranus", "Voyager 2" } });
                    probes.Add(new Dictionary<string, string>(){ {"Neptune","Voyager 2"} });

            /*
            Iterate over planetList, and inside that loop, iterate over the list of dictionaries. Write to the console, for each planet, which satellites have visited which planet.
            */

            foreach (string planet in planetList) // iterate planets(list)
            {
                List<string> matchingProbes = new List<string>();

                foreach (Dictionary<string,string> probe in probes) // iterate probes(dictionary)
                {
                    /*
                    Does the current Dictionary contain the key of
                    the current planet? Investigate the ContainsKey()
                    method on a Dictionary.
                    If so, add the current spacecraft to `matchingProbes`.
                    */
                    if (probe.ContainsKey(planet)) {
                    matchingProbes.Add(probe[planet]);
                    }
                }
                string planetListString = string.Join(", ", matchingProbes); //string variable to join strings together
                Console.WriteLine($"{planet}: {planetListString}");
            }

        }
    }
}

