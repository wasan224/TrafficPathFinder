using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficPathFinder
{
    public class Graph
    {
        // Stores the graph as an adjacency list where each node points to a list of connected nodes with their respective weights
        private readonly Dictionary<string, List<Tuple<string, int>>> adjacencyList;

        // Constructor initializes the adjacency list
        public Graph()
        {
            adjacencyList = new Dictionary<string, List<Tuple<string, int>>>();
        }

        // Checks if a node exists in the graph
        public bool HasNode(string node)
        {
            return adjacencyList.ContainsKey(node);
        }

        // Adds a new node to the graph
        public void AddNode(string node)
        {
            // If the node doesn't exist, add it to the adjacency list
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList[node] = new List<Tuple<string, int>>();
            }
            else
            {
                // If the node already exists, throw an exception
                throw new ArgumentException($"Node '{node}' already exists.");
            }
        }

        // Adds an edge (road) between two nodes with a specified weight
        public void AddEdge(string from, string to, int weight)
        {
            // Ensure both nodes exist before adding an edge
            if (!adjacencyList.ContainsKey(from) || !adjacencyList.ContainsKey(to))
            {
                throw new ArgumentException("Both nodes must exist before adding an edge.");
            }

            // Ensure the weight is positive
            if (weight <= 0)
            {
                throw new ArgumentException("Edge weight must be greater than zero.");
            }

            // Add the edge if it doesn't already exist
            if (!adjacencyList[from].Any(edge => edge.Item1 == to))
            {
                adjacencyList[from].Add(new Tuple<string, int>(to, weight));
            }

            // Since the graph is undirected, add the reverse edge as well
            if (!adjacencyList[to].Any(edge => edge.Item1 == from))
            {
                adjacencyList[to].Add(new Tuple<string, int>(from, weight));
            }
        }

        // Finds the shortest path between two nodes using Dijkstra's algorithm
        public (List<string> path, int cost) FindShortestPath(string start, string end)
        {
            // Ensure both nodes exist in the graph
            if (!HasNode(start) || !HasNode(end))
            {
                throw new ArgumentException("Both start and end nodes must exist in the graph.");
            }

            // Initialize distances to infinity and previous nodes as null
            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var unvisited = new HashSet<string>(adjacencyList.Keys);

            foreach (var node in adjacencyList.Keys)
            {
                distances[node] = int.MaxValue;
            }
            distances[start] = 0;

            // Process nodes until all are visited
            while (unvisited.Count > 0)
            {
                // Select the node with the smallest distance
                string currentNode = unvisited.OrderBy(n => distances[n]).First();
                unvisited.Remove(currentNode);

                // Stop if the destination is reached or no more accessible nodes
                if (currentNode == end || distances[currentNode] == int.MaxValue)
                {
                    break;
                }

                // Update distances for neighbors of the current node
                foreach (var (neighbor, weight) in adjacencyList[currentNode])
                {
                    int tentativeDistance = distances[currentNode] + weight;
                    if (tentativeDistance < distances[neighbor])
                    {
                        distances[neighbor] = tentativeDistance;
                        previousNodes[neighbor] = currentNode;
                    }
                }
            }

            // Reconstruct the shortest path
            var path = new List<string>();
            string current = end;

            while (previousNodes.ContainsKey(current))
            {
                path.Add(current);
                current = previousNodes[current];
            }
            path.Add(start);
            path.Reverse();

            int totalCost = distances[end];

            // If no path exists, return empty path and max cost
            return totalCost == int.MaxValue ? (new List<string>(), int.MaxValue) : (path, totalCost);
        }

        // Returns all nodes in the graph
        public IEnumerable<string> GetNodes()
        {
            return adjacencyList.Keys;
        }

        // Returns all edges (connections) for a specific node
        public IEnumerable<(string, int)> GetEdges(string node)
        {
            if (adjacencyList.ContainsKey(node))
            {
                return adjacencyList[node].Select(edge => (edge.Item1, edge.Item2));
            }
            throw new ArgumentException($"Node '{node}' does not exist.");
        }

        // Returns a string representation of the graph for debugging
        public string GetGraphDetails()
        {
            string details = "";

            foreach (var node in adjacencyList)
            {
                details += $"{node.Key}: ";
                foreach (var edge in node.Value)
                {
                    details += $"({edge.Item1}, {edge.Item2}) ";
                }
                details += "\n";
            }

            return details;
        }

        // Removes a node and all its associated edges
        public void RemoveNode(string node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                throw new ArgumentException($"Node '{node}' does not exist.");
            }

            adjacencyList.Remove(node);

            // Remove references to the node from all other nodes
            foreach (var edges in adjacencyList.Values)
            {
                edges.RemoveAll(edge => edge.Item1 == node);
            }
        }

        // Removes a specific edge between two nodes
        public void RemoveEdge(string from, string to)
        {
            if (!adjacencyList.ContainsKey(from) || !adjacencyList.ContainsKey(to))
            {
                throw new ArgumentException("Both nodes must exist before removing an edge.");
            }

            // Remove the edge from both nodes
            adjacencyList[from].RemoveAll(edge => edge.Item1 == to);
            adjacencyList[to].RemoveAll(edge => edge.Item1 == from);
        }
    }
}
