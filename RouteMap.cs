/*
Seth Hannah | sethhannah@trentu.ca
Fadi Naaman | fadinaaman@trentu.ca

COIS 3020 | Data Structures and Algorithms 2
Assignment 1

RouteMap.cs
This file is the RouteMap class. This class is used to build a graph of AirportNodes and interact with the nodes
An additional point of interest for this class is the FindFastest function. This function uses breadth first search
to find the fastest path from one node to another through the graph.
*/
using System;
using System.Collections.Generic;

namespace AirportRoutes{
    class RouteMap{
        private List<AirportNode> airports; //List of airport nodes.

        // property for airports list
        public List<AirportNode> Airports{
            get {
                return this.airports;
            }
            set {
                this.airports = value;
            }

        }
        public RouteMap() //RouteMap constructor. 5%
        {
            Airports = new List<AirportNode>();
        }
        public AirportNode FindAirport(string search) //Method to find airport by code or name.
        {
            // Look through each node in the list of nodes in the route map
            // if any name or code matches a node in the list of airport nodes then return the node
            // otherwise if none of the nodes have the code or name return null
            foreach(AirportNode airport in Airports)
            {
                // if the length of the search is equal to 3, assume the search is a code
                if (search.Length == 3) 
                {
                    if (airport.Code.Equals(search))
                    {
                        return airport;
                    }
                }
                // otherwise assume the search is for a name
                else
                {
                    if (airport.Name.Equals(search))
                    {
                        return airport;
                    }
                }
            }
            return null;
        }
        public bool AddAirport(AirportNode a) //Method to add airport node.
        {
            // if there is the airport in the list of airports, return false and don't add the airport
            if (Airports.Contains(a))
            {
                return false;
            }
            // if there is not the airport in the list of airports, return true and add the airport
            else
            {
                Airports.Add(a);
                return true;
            }
        }
        public bool RemoveAirport(AirportNode a) //Method to remove airport node. Node must exist. 5%
        {
            // if there is the airport in the list of airports, return true and remove the airport
            if (Airports.Contains(a))
            {
                Airports.Remove(a);
                return true;
            }
            // if there is not the airport in the list of airports, return false and don't the airport
            else
            {
               return false;
            }
        }
        public bool AddRoute(AirportNode origin, AirportNode dest)
        {
            
            // if both routes are in the destinations list add destination to origin
            // return the result of whether or not the AddDestination function worked
            if (Airports.Contains(origin) && Airports.Contains(dest))
            {
                return origin.AddDestination(dest);
            }
            // if both routes aren't in the destinations list, return false
            else
            {
                return false;
            }
        }
        public bool RemoveRoute (AirportNode origin, AirportNode dest)
        {
            // if both routes are in the destinations list remove destination from origin
            // return the result of whether or not the RemoveDestination function worked
            if (Airports.Contains(origin) && Airports.Contains(dest))
            {
                return origin.RemoveDestination(dest);
            }
            // if both routes aren't in the destinations list, return false
            else
            {
                return false;
            }
        }
        public string FastestRoute(AirportNode origin, AirportNode dest)
        {
            // if the origin and the destination are the same return origin string
            if (origin.Equals(dest))
            {
                return "Fastest path is: " + origin.Code;
            }
            // if either the origin or the dest are not in the list
            else if (!Airports.Contains(origin) || !Airports.Contains(dest))
            {
                return "";
            }
            else
            {
                // initialize the frontier queue and discovered set
                Queue<AirportNode> frontierQueue = new Queue<AirportNode>();
                Dictionary<AirportNode, AirportNode> discoveredSet = new Dictionary<AirportNode, AirportNode>();

                // add origin node to frontier queue and discovered set
                frontierQueue.Enqueue(origin);
                discoveredSet.Add(origin, null);

                // as long as there are items in the frontier queue continue to loop
                while (frontierQueue.Count > 0)
                {
                    AirportNode currentAirport = frontierQueue.Dequeue();
                    // Console.WriteLine("Visited: " + currentAirport.Code);

                    foreach (AirportNode destination in currentAirport.Destinations)
                    {
                        if (destination.Equals(dest))
                        {
                            discoveredSet.Add(destination, currentAirport);
                            
                            List<string> s = new List<string>();
                            AirportNode n = destination;
                            
                            while (n != null)
                            {
                                s.Add(n.Code);
                                n = discoveredSet[n];
                            }
                            s.Reverse();
                            return String.Format("Fastest path is: {0}", String.Join(" -> ", s));
                        }
                        else if (!discoveredSet.ContainsKey(destination))
                        {
                            frontierQueue.Enqueue(destination);
                            discoveredSet.Add(destination, currentAirport);
                        }
                    }
                }
            }
            return "";
        }
        public override string ToString()
        {
            return String.Join("\n", Airports);
        }
        public string FormattedToString()
        {
            List<string> airportsString = new List<string>();
            foreach (AirportNode airport in Airports){
                airportsString.Add(airport.FormattedToString());
            }
            return String.Join("\n", airportsString);
        }
    }
}