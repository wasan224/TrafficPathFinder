using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficPathFinder
{
    public partial class Form1 : Form
    {
        // Graph object that holds the nodes and edges
        private Graph graph;

        // Dictionary to store the position of each node on the map
        private Dictionary<string, Point> nodePositions;

        // Constant for the radius of each node in the visualization
        private const int NodeRadius = 20;

        // Constructor for the form
        public Form1()
        {
            InitializeComponent();

            // Initialize the graph object
            graph = new Graph();

            // Initialize the node positions dictionary
            nodePositions = new Dictionary<string, Point>();

            // Load a sample graph with predefined nodes and edges
            LoadSampleGraph();
        }

        /// <summary>
        /// Handles the event when the "Add Node" button is clicked.
        /// </summary>
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            // Get the node name entered by the user
            string nodeName = txtNodeName.Text.Trim();

            // Ensure the node name is not empty
            if (!string.IsNullOrEmpty(nodeName))
            {
                // Check if the node does not already exist in the graph
                if (!graph.HasNode(nodeName))
                {
                    // Add the node to the graph
                    graph.AddNode(nodeName);

                    // Add the node to the source and destination dropdown menus
                    cmbSourceNode.Items.Add(nodeName);
                    cmbDestinationNode.Items.Add(nodeName);

                    // Display a message in the list box
                    lstDisplay.Items.Add($"Node Added: {nodeName}");

                    // Clear the text box
                    txtNodeName.Clear();

                    // Randomly position the node on the map
                    Random random = new Random();
                    Point position = new Point(
                        random.Next(NodeRadius, pnlMap.Width - NodeRadius),
                        random.Next(NodeRadius, pnlMap.Height - NodeRadius)
                    );

                    // Store the position of the node
                    nodePositions[nodeName] = position;

                    // Redraw the panel to display the new node
                    pnlMap.Invalidate();
                }
                else
                {
                    // Show an error message if the node already exists
                    MessageBox.Show("Node already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid node name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the event when the "Add Edge" button is clicked.
        /// </summary>
        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            // Get the source and destination node names
            string fromNode = txtFromNode.Text.Trim();
            string toNode = txtToNode.Text.Trim();

            // Try to parse the weight value and ensure it's positive
            if (int.TryParse(txtWeight.Text.Trim(), out int weight) && weight > 0)
            {
                // Check if both node names are valid
                if (!string.IsNullOrEmpty(fromNode) && !string.IsNullOrEmpty(toNode))
                {
                    // Ensure both nodes exist in the graph
                    if (graph.HasNode(fromNode) && graph.HasNode(toNode))
                    {
                        // Add the edge to the graph
                        graph.AddEdge(fromNode, toNode, weight);

                        // Display a message in the list box
                        lstDisplay.Items.Add($"Edge Added: {fromNode} -> {toNode} (Weight: {weight})");

                        // Clear the input fields
                        txtFromNode.Clear();
                        txtToNode.Clear();
                        txtWeight.Clear();

                        // Redraw the panel to display the new edge
                        pnlMap.Invalidate();
                    }
                    else
                    {
                        // Show an error message if either node doesn't exist
                        MessageBox.Show("Both nodes must exist in the graph!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Show an error message if the input is invalid
                    MessageBox.Show("Please enter valid node names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show an error message if the weight is invalid
                MessageBox.Show("Please enter a valid weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the event when the "Find Shortest Path" button is clicked.
        /// </summary>
        private void btnFindPath_Click(object sender, EventArgs e)
        {
            // Get the selected source and destination nodes
            string source = cmbSourceNode.SelectedItem?.ToString();
            string destination = cmbDestinationNode.SelectedItem?.ToString();

            // Ensure both nodes are selected
            if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(destination))
            {
                // Use the graph's shortest path algorithm
                var (path, cost) = graph.FindShortestPath(source, destination);

                // Display the results in the list box
                if (cost == int.MaxValue)
                {
                    lstDisplay.Items.Add("No path found!");
                }
                else
                {
                    lstDisplay.Items.Add($"Shortest Path: {string.Join(" -> ", path)}");
                    lstDisplay.Items.Add($"Total Cost: {cost}");

                    // Simulate the car animation on the path
                    SimulateCarMovement(path);
                }
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please select both source and destination nodes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the event when the "Clear Graph" button is clicked.
        /// </summary>
        // Event handler for "Clear Graph" button
        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            graph = new Graph(); // Reset the graph
            nodePositions.Clear(); // Clear node positions
            lstDisplay.Items.Clear(); // Clear the list display
            cmbSourceNode.Items.Clear(); // Clear source dropdown
            cmbDestinationNode.Items.Clear(); // Clear destination dropdown

            // Reset the selected item or text in ComboBoxes
            cmbSourceNode.SelectedItem = null;
            cmbSourceNode.Text = string.Empty;
            cmbDestinationNode.SelectedItem = null;
            cmbDestinationNode.Text = string.Empty;

            txtNodeName.Clear(); // Clear node name text box
            txtFromNode.Clear(); // Clear from node text box
            txtToNode.Clear(); // Clear to node text box
            txtWeight.Clear(); // Clear weight text box
            pnlMap.Invalidate(); // Redraw the panel
            MessageBox.Show("Graph cleared successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Paint event for the map panel to render nodes and edges.
        /// </summary>
        private void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw all edges
            foreach (var fromNode in graph.GetNodes())
            {
                if (nodePositions.ContainsKey(fromNode))
                {
                    foreach (var (toNode, weight) in graph.GetEdges(fromNode))
                    {
                        if (nodePositions.ContainsKey(toNode))
                        {
                            // Draw the edge line
                            Point fromPoint = nodePositions[fromNode];
                            Point toPoint = nodePositions[toNode];
                            g.DrawLine(Pens.Gray, fromPoint, toPoint);

                            // Draw the weight at the midpoint of the line
                            Point midPoint = new Point((fromPoint.X + toPoint.X) / 2, (fromPoint.Y + toPoint.Y) / 2);
                            g.DrawString(weight.ToString(), DefaultFont, Brushes.Black, midPoint);
                        }
                    }
                }
            }

            // Draw all nodes
            foreach (var node in nodePositions)
            {
                Point position = node.Value;

                // Draw the node as a filled circle
                g.FillEllipse(Brushes.LightBlue, position.X - NodeRadius, position.Y - NodeRadius, NodeRadius * 2, NodeRadius * 2);

                // Draw the border of the circle
                g.DrawEllipse(Pens.Black, position.X - NodeRadius, position.Y - NodeRadius, NodeRadius * 2, NodeRadius * 2);

                // Draw the node name
                g.DrawString(node.Key, DefaultFont, Brushes.Black, position.X - NodeRadius / 2, position.Y - NodeRadius / 2);
            }
        }

        /// <summary>
        /// Simulates car movement along the given path.
        /// </summary>
        private async void SimulateCarMovement(List<string> path)
        {
            if (path.Count < 2) return;

            // Loop through each segment of the path
            for (int i = 0; i < path.Count - 1; i++)
            {
                string fromNode = path[i];
                string toNode = path[i + 1];

                if (nodePositions.ContainsKey(fromNode) && nodePositions.ContainsKey(toNode))
                {
                    Point fromPoint = nodePositions[fromNode];
                    Point toPoint = nodePositions[toNode];

                    // Move the car smoothly along the edge
                    for (float t = 0; t <= 1; t += 0.05f)
                    {
                        int x = (int)(fromPoint.X + (toPoint.X - fromPoint.X) * t);
                        int y = (int)(fromPoint.Y + (toPoint.Y - fromPoint.Y) * t);

                        pnlMap.Refresh();

                        // Draw the car (red dot)
                        using (Graphics g = pnlMap.CreateGraphics())
                        {
                            g.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
                        }

                        await Task.Delay(50);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a sample graph with predefined nodes and edges.
        /// </summary>
        private void LoadSampleGraph()
        {
            graph.AddNode("UKH");
            graph.AddNode("Park Sami");
            graph.AddNode("Family Mall");
            graph.AddNode("Gulan Mall");

            graph.AddEdge("UKH", "Park Sami", 5);
            graph.AddEdge("Park Sami", "Family Mall", 3);
            graph.AddEdge("Family Mall", "Gulan Mall", 4);
            graph.AddEdge("UKH", "Gulan Mall", 10);

            nodePositions["UKH"] = new Point(100, 100);
            nodePositions["Park Sami"] = new Point(200, 100);
            nodePositions["Family Mall"] = new Point(200, 200);
            nodePositions["Gulan Mall"] = new Point(100, 200);

            cmbSourceNode.Items.AddRange(new string[] { "UKH", "Park Sami", "Family Mall", "Gulan Mall" });
            cmbDestinationNode.Items.AddRange(new string[] { "UKH", "Park Sami", "Family Mall", "Gulan Mall" });

            pnlMap.Invalidate();
        }
    }
}
