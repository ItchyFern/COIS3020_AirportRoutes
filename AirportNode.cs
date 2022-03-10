/*
Seth Hannah | sethhannah@trentu.ca
Fadi Naaman | fadinaaman@trentu.ca

COIS 3020 | Data Structures and Algorithms 2
Assignment 1

AirportNode.cs
This file is the AirportNode class. This class holds the basic information for airport nodes. It allows nodes to have both a name, a code
and a list of destinations which are other AirportNode class objects. 
*/
using System;
using System.Collections.Generic;
namespace AirportRoutes
{
    class AirportNode
    {

        // private variables initialized
        private string name;
        private string code;
        private List<AirportNode> destinations;

        //property for name field.
        public string Name 
        {
            get {return this.name;} 
            set {this.name = value;}
        } 
        //property for code field.
        public string Code 
        {
            get {return this.code;} 
            set {this.code = value;}
        } 
        //property for list of destinations.
        public List<AirportNode> Destinations 
        {
            get {return this.destinations;} 
            set {this.destinations = value;}
        } 

        //constructor 5%
        public AirportNode(string name, string code) 
        {
            this.Name = name;
            this.Code = code;
            this.Destinations = new List<AirportNode>();
        }

        //method to add destination. 5%
        public bool AddDestination (AirportNode destAirport) 
        {
            // if the destination airport is current airport or
            // if the destinations list for this airport node contains the destination that is to be added
            // then do not add the destination, and return false
            if (Destinations.Contains(destAirport) || destAirport.Equals(this))
            {
                return false;
            }
            // if the destination list for this airport node does not contain the destination that is to be added
            // then add the destination to the destination list and return true (Success!)
            else
            {
                Destinations.Add(destAirport);
                return true;
            }
        }
        public bool RemoveDestination (AirportNode destAirport) //method to remove destination. 5%
        {
            // if the destination list contains the destination that is to be removed
            // remove the destination and return true
            if (Destinations.Contains(destAirport))
            {
                Destinations.Remove(destAirport);
                return true;
            }
            // if the destination list does not contain the destination that is to be removed
            // return false and do not try to remove the destination
            else
            {
                return false;
            }

        }
        public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
        {
            List<string> destinationCodes = new List<string>();
            foreach (AirportNode destination in this.Destinations)
            {
                destinationCodes.Add(destination.Code);
            }
            return String.Format("{0} | {1} | Destinations: {2}", this.Code, this.Name, String.Join(", ", destinationCodes));
        }
        public string FormattedToString() {
            {
            List<string> destinationCodes = new List<string>();
            foreach (AirportNode destination in this.Destinations)
            {
                destinationCodes.Add(destination.Code);
            }
            return String.Format("{0, 55} | {1} | Destinations: {2}", this.Name, this.Code, String.Join(", ", destinationCodes));
        }
        }
    }
}