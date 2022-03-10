/*
Seth Hannah | sethhannah@trentu.ca
Fadi Naaman | fadinaaman@trentu.ca

COIS 3020 | Data Structures and Algorithms 2
Assignment 1

Program.cs
This file is a tester file to run the Airport Routes namespace, consisting of both RouteMap class and AirportNode class
*/

using System;

namespace AirportRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            RouteMap map = new RouteMap();
            
            AirportNode[] n = new AirportNode[13];

            n[0] = new AirportNode("Calgary International Airport", "YYC");
            n[1] = new AirportNode("Edmonton International Airport", "YEG");
            n[2] = new AirportNode("Fredericton International Airport", "YFC");
            n[3] = new AirportNode("Gander International Airport", "YQX");
            n[4] = new AirportNode("Halifax Stanfield International Airport", "YHZ");
            n[5] = new AirportNode("Greater Moncton Roméo LeBlanc International Airport", "YQM");
            n[6] = new AirportNode("Montréal-Trudeau International Airport", "YUL");
            n[7] = new AirportNode("Ottawa Macdonald-Cartier International Airport", "YOW");
            n[8] = new AirportNode("Québec/Jean Lesage International Airport", "YQB");
            n[9] = new AirportNode("St. John's International Airport", "YYT");
            n[10] = new AirportNode("Toronto Pearson International Airport", "YYZ");
            n[11] = new AirportNode("Vancouver International Airport", "YVR");
            n[12] = new AirportNode("Winnipeg International Airport", "YWG");

            foreach (AirportNode airport in n)
            {
                map.AddAirport(airport);
            }

            map.AddRoute(n[0], n[1]); // YYC -> YEG
            map.AddRoute(n[0], n[2]); // YYC -> YFC
            map.AddRoute(n[0], n[9]); // YYC -> YYT
            map.AddRoute(n[1], n[0]); // YEG -> YYC
            map.AddRoute(n[1], n[2]); // YEG -> YFC
            map.AddRoute(n[2], n[5]); // YFC -> YQM
            map.AddRoute(n[2], n[6]); // YFC -> YUL
            map.AddRoute(n[2], n[7]); // YFC -> YOW
            map.AddRoute(n[3], n[4]); // YQX -> YHZ
            map.AddRoute(n[3], n[6]); // YQX -> YUL
            map.AddRoute(n[3], n[12]); // YQX -> YWG
            map.AddRoute(n[3], n[10]); // YQX -> YYZ
            map.AddRoute(n[3], n[11]); // YQX -> YVR
            map.AddRoute(n[4], n[5]); // YHZ -> YQM
            map.AddRoute(n[4], n[3]); // YHZ -> YQX
            map.AddRoute(n[4], n[11]); // YHZ -> YVR
            map.AddRoute(n[5], n[4]); // YQM -> YHZ
            map.AddRoute(n[5], n[11]); // YQM -> YVR
            map.AddRoute(n[5], n[2]); // YQM -> YFC
            map.AddRoute(n[6], n[10]); // YUL -> YYZ
            map.AddRoute(n[6], n[12]); // YUL -> YWG
            map.AddRoute(n[6], n[8]); // YUL -> YQB
            map.AddRoute(n[7], n[0]); // YOW -> YYC
            map.AddRoute(n[7], n[2]); // YOW -> YFC
            map.AddRoute(n[7], n[8]); // YOW -> YQB
            map.AddRoute(n[8], n[9]); // YQB -> YYT
            map.AddRoute(n[8], n[7]); // YQB -> YOW
            map.AddRoute(n[8], n[6]); // YQB -> YUL
            map.AddRoute(n[8], n[3]); // YQB -> YQX
            map.AddRoute(n[9], n[0]); // YYT -> YYC
            map.AddRoute(n[9], n[8]); // YYT -> YQB
            map.AddRoute(n[10], n[5]); // YYZ -> YQM
            map.AddRoute(n[10], n[6]); // YYZ -> YUL
            map.AddRoute(n[10], n[12]); // YYZ -> YWG
            map.AddRoute(n[11], n[5]); // YVR -> YQM
            map.AddRoute(n[11], n[4]); // YVR -> YHZ
            map.AddRoute(n[11], n[3]); // YVR -> YQX
            map.AddRoute(n[11], n[10]); // YVR -> YYZ
            map.AddRoute(n[12], n[10]); // YWG -> YYZ
            map.AddRoute(n[12], n[11]); // YWG -> YVR
            map.AddRoute(n[12], n[3]); // YWG -> YQX

            Console.WriteLine(map.FormattedToString());


            // TESTING STUFF
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~TESTING OUTPUTS~~~~~~~~~~~~~~~~~~~~~");
            // Fastest Route testing
            Console.WriteLine("\nTEST 1 - Fastest Route");
            Console.WriteLine("Find fastest path between two airports that exist, YYC to YYZ");
            Console.WriteLine("Expected Output: Fastest path is: YYC -> YFC -> YUL -> YYZ");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FastestRoute(n[0], n[10]));

            Console.WriteLine("\nTEST 2 - Fastest Route");
            Console.WriteLine("Find fastest path between two airports where one does not exist, YYC to DNE (DNE is a airport that does not exist in the map)");
            Console.WriteLine("Expected Output: ");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FastestRoute(n[0], new AirportNode("Does Not Exist", "DNE")));

            Console.WriteLine("\nTEST 3 - Fastest Route");
            Console.WriteLine("Find fastest path between two airports that are the same, YYC to YYC");
            Console.WriteLine("Expected Output: Fastest path is: YYC");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FastestRoute(n[0], n[0]));

            // Add Airport testing
            Console.WriteLine("\nTEST 4 - Add Airport");
            Console.WriteLine("Add Airport that already exists");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddAirport(n[0]));

            Console.WriteLine("\nTEST 5 - Add Airport");
            Console.WriteLine("Add Airport that doesn't exists");
            Console.WriteLine("Expected Output: True");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddAirport(new AirportNode("Test", "YTV")));
            
            // Remove Airport Testing
            Console.WriteLine("\nTEST 6 - Remove Airport");
            Console.WriteLine("Remove Airport that doesn't exists");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveAirport(new AirportNode("DoesNotExist", "DNE")));

            Console.WriteLine("\nTEST 7 - Remove Airport");
            Console.WriteLine("Remove Airport that already exists");
            Console.WriteLine("Expected Output: True");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveAirport(map.FindAirport("YTV")));

            // Add Route Testing
            Console.WriteLine("\nTEST 8 - Add Route");
            Console.WriteLine("Add Route where Origin does not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddRoute(new AirportNode("DoesNotExist", "DNE"), n[0]));

            Console.WriteLine("\nTEST 9 - Add Route");
            Console.WriteLine("Add Route where Destination does not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddRoute(new AirportNode("DoesNotExist", "DNE"), n[0]));

            Console.WriteLine("\nTEST 10 - Add Route");
            Console.WriteLine("Add Route where Origin and Destination do not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddRoute(new AirportNode("DoesNotExist", "DNE"), new AirportNode("AlsoDoesNotExist", "ANE")));

            Console.WriteLine("\nTEST 11 - Add Route");
            Console.WriteLine("Add Route where both Origin and Destination exist");
            Console.WriteLine("Expected Output: True");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddRoute(n[0], n[10]));

            Console.WriteLine("\nTEST 12 - Add Route");
            Console.WriteLine("Add Route where both Origin and Destination exist but route already exists");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.AddRoute(n[0], n[10]));

            // Testing Remove Route
            Console.WriteLine("\nTEST 13 - Remove Route");
            Console.WriteLine("Remove Route where Origin does not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveRoute(new AirportNode("DoesNotExist", "DNE"), n[0]));

            Console.WriteLine("\nTEST 14 - Remove Route");
            Console.WriteLine("Remove Route where Destination does not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveRoute(new AirportNode("DoesNotExist", "DNE"), n[0]));

            Console.WriteLine("\nTEST 15 - Remove Route");
            Console.WriteLine("Remove Route where Origin and Destination do not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveRoute(new AirportNode("DoesNotExist", "DNE"), new AirportNode("AlsoDoesNotExist", "ANE")));

            Console.WriteLine("\nTEST 16 - Remove Route");
            Console.WriteLine("Remove Route where both Origin and Destination exist and route already exists");
            Console.WriteLine("Expected Output: True");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveRoute(n[0], n[10]));

            Console.WriteLine("\nTEST 17 - Remove Route");
            Console.WriteLine("Remove Route where both Origin and Destination exist but route does not exist");
            Console.WriteLine("Expected Output: False");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.RemoveRoute(n[0], n[10]));

            // Find Airport Test
            Console.WriteLine("\nTEST 18 - Find Airport");
            Console.WriteLine("Find airport that exists by its name. (Calgary International Airport)");
            Console.WriteLine("Expected Output: YYC | Calgary International Airport | Destinations: YEG, YFC, YYT");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FindAirport("Calgary International Airport"));

            Console.WriteLine("\nTEST 19 - Find Airport");
            Console.WriteLine("Find airport that exists by its code. (YYC)");
            Console.WriteLine("Expected Output: YYC | Calgary International Airport | Destinations: YEG, YFC, YYT");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FindAirport("YYC"));

            Console.WriteLine("\nTEST 20 - Find Airport");
            Console.WriteLine("Find airport that does not exist by its name (Airport that does not exist)");
            Console.WriteLine("Expected Output: ");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FindAirport("Airport that does not exist"));

            Console.WriteLine("\nTEST 21 - Find Airport");
            Console.WriteLine("Find airport that does not exist by its code (DNE)");
            Console.WriteLine("Expected Output: ");
            Console.Write("Actual Output: ");
            Console.WriteLine(map.FindAirport("DNE"));


        }
    }
}
