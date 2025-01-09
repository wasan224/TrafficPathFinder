namespace TrafficPathFinder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes the resources being used.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources should be disposed.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                // Dispose of the components.
                components.Dispose();
            }
            // Call the base class Dispose method.
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Initializes the components and sets up the UI for the application.
        /// </summary>
        private void InitializeComponent()
        {
            // Label for node name input
            this.lblNodeName = new System.Windows.Forms.Label();

            // Text box for entering node name
            this.txtNodeName = new System.Windows.Forms.TextBox();

            // Button to add a new node
            this.btnAddNode = new System.Windows.Forms.Button();

            // Label for the "From Node" field
            this.lblFromNode = new System.Windows.Forms.Label();

            // Text box for entering the source node name when adding an edge
            this.txtFromNode = new System.Windows.Forms.TextBox();

            // Label for the "To Node" field
            this.lblToNode = new System.Windows.Forms.Label();

            // Text box for entering the destination node name when adding an edge
            this.txtToNode = new System.Windows.Forms.TextBox();

            // Label for the edge weight
            this.lblWeight = new System.Windows.Forms.Label();

            // Text box for entering the weight of the edge
            this.txtWeight = new System.Windows.Forms.TextBox();

            // Button to add a new edge between two nodes
            this.btnAddEdge = new System.Windows.Forms.Button();

            // List box for displaying graph updates and path information
            this.lstDisplay = new System.Windows.Forms.ListBox();

            // Label for source node dropdown
            this.lblSourceNode = new System.Windows.Forms.Label();

            // Dropdown for selecting the source node in the shortest path calculation
            this.cmbSourceNode = new System.Windows.Forms.ComboBox();

            // Label for destination node dropdown
            this.lblDestinationNode = new System.Windows.Forms.Label();

            // Dropdown for selecting the destination node in the shortest path calculation
            this.cmbDestinationNode = new System.Windows.Forms.ComboBox();

            // Button to calculate and display the shortest path
            this.btnFindPath = new System.Windows.Forms.Button();

            // Button to clear the graph and reset the UI
            this.btnClearGraph = new System.Windows.Forms.Button();

            // Panel to visually display the nodes and edges on a map
            this.pnlMap = new System.Windows.Forms.Panel();

            // Suspend the layout while initializing the components
            this.SuspendLayout();

            // Set properties for the Node Name label
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(12, 20);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(93, 20);
            this.lblNodeName.TabIndex = 0;
            this.lblNodeName.Text = "Node Name:";

            // Set properties for the Node Name text box
            this.txtNodeName.Location = new System.Drawing.Point(110, 17);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(125, 27);
            this.txtNodeName.TabIndex = 1;

            // Set properties for the Add Node button
            this.btnAddNode.Location = new System.Drawing.Point(257, 17);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(94, 29);
            this.btnAddNode.TabIndex = 2;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);

            // Set properties for the "From Node" label
            this.lblFromNode.AutoSize = true;
            this.lblFromNode.Location = new System.Drawing.Point(533, 20);
            this.lblFromNode.Name = "lblFromNode";
            this.lblFromNode.Size = new System.Drawing.Size(87, 20);
            this.lblFromNode.TabIndex = 3;
            this.lblFromNode.Text = "From Node:";

            // Set properties for the "From Node" text box
            this.txtFromNode.Location = new System.Drawing.Point(633, 17);
            this.txtFromNode.Name = "txtFromNode";
            this.txtFromNode.Size = new System.Drawing.Size(125, 27);
            this.txtFromNode.TabIndex = 4;

            // Set properties for the "To Node" label
            this.lblToNode.AutoSize = true;
            this.lblToNode.Location = new System.Drawing.Point(533, 62);
            this.lblToNode.Name = "lblToNode";
            this.lblToNode.Size = new System.Drawing.Size(69, 20);
            this.lblToNode.TabIndex = 5;
            this.lblToNode.Text = "To Node:";

            // Set properties for the "To Node" text box
            this.txtToNode.Location = new System.Drawing.Point(633, 59);
            this.txtToNode.Name = "txtToNode";
            this.txtToNode.Size = new System.Drawing.Size(125, 27);
            this.txtToNode.TabIndex = 6;

            // Set properties for the Weight label
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(533, 103);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(59, 20);
            this.lblWeight.TabIndex = 7;
            this.lblWeight.Text = "Weight:";

            // Set properties for the Weight text box
            this.txtWeight.Location = new System.Drawing.Point(633, 100);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(125, 27);
            this.txtWeight.TabIndex = 8;

            // Set properties for the Add Edge button
            this.btnAddEdge.Location = new System.Drawing.Point(533, 145);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(225, 29);
            this.btnAddEdge.TabIndex = 9;
            this.btnAddEdge.Text = "Add Edge";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);

            // Set properties for the List Box
            this.lstDisplay.FormattingEnabled = true;
            this.lstDisplay.ItemHeight = 20;
            this.lstDisplay.Location = new System.Drawing.Point(12, 59);
            this.lstDisplay.Name = "lstDisplay";
            this.lstDisplay.Size = new System.Drawing.Size(500, 124);
            this.lstDisplay.TabIndex = 10;

            // Set properties for the Source Node label
            this.lblSourceNode.AutoSize = true;
            this.lblSourceNode.Location = new System.Drawing.Point(12, 200);
            this.lblSourceNode.Name = "lblSourceNode";
            this.lblSourceNode.Size = new System.Drawing.Size(98, 20);
            this.lblSourceNode.TabIndex = 11;
            this.lblSourceNode.Text = "Source Node:";

            // Set properties for the Source Node dropdown
            this.cmbSourceNode.FormattingEnabled = true;
            this.cmbSourceNode.Location = new System.Drawing.Point(120, 197);
            this.cmbSourceNode.Name = "cmbSourceNode";
            this.cmbSourceNode.Size = new System.Drawing.Size(150, 28);
            this.cmbSourceNode.TabIndex = 12;

            // Set properties for the Destination Node label
            this.lblDestinationNode.AutoSize = true;
            this.lblDestinationNode.Location = new System.Drawing.Point(300, 200);
            this.lblDestinationNode.Name = "lblDestinationNode";
            this.lblDestinationNode.Size = new System.Drawing.Size(129, 20);
            this.lblDestinationNode.TabIndex = 13;
            this.lblDestinationNode.Text = "Destination Node:";

            // Set properties for the Destination Node dropdown
            this.cmbDestinationNode.FormattingEnabled = true;
            this.cmbDestinationNode.Location = new System.Drawing.Point(450, 197);
            this.cmbDestinationNode.Name = "cmbDestinationNode";
            this.cmbDestinationNode.Size = new System.Drawing.Size(150, 28);
            this.cmbDestinationNode.TabIndex = 14;

            // Set properties for the Find Path button
            this.btnFindPath.Location = new System.Drawing.Point(620, 197);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(150, 29);
            this.btnFindPath.TabIndex = 15;
            this.btnFindPath.Text = "Find Shortest Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);

            // Set properties for the Clear Graph button
            this.btnClearGraph.Location = new System.Drawing.Point(620, 240);
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.Size = new System.Drawing.Size(150, 29);
            this.btnClearGraph.TabIndex = 16;
            this.btnClearGraph.Text = "Clear Graph";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Click += new System.EventHandler(this.btnClearGraph_Click);

            // Set properties for the Panel to display the map
            this.pnlMap.BackColor = System.Drawing.Color.White;
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Location = new System.Drawing.Point(12, 271);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(760, 300);
            this.pnlMap.TabIndex = 17;
            this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMap_Paint);

            // Set properties for the main form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 622);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.btnClearGraph);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.cmbDestinationNode);
            this.Controls.Add(this.lblDestinationNode);
            this.Controls.Add(this.cmbSourceNode);
            this.Controls.Add(this.lblSourceNode);
            this.Controls.Add(this.lstDisplay);
            this.Controls.Add(this.btnAddEdge);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtToNode);
            this.Controls.Add(this.lblToNode);
            this.Controls.Add(this.txtFromNode);
            this.Controls.Add(this.lblFromNode);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.lblNodeName);
            this.Name = "Form1";
            this.Text = "Traffic Path Finder";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Label lblFromNode;
        private System.Windows.Forms.TextBox txtFromNode;
        private System.Windows.Forms.Label lblToNode;
        private System.Windows.Forms.TextBox txtToNode;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.ListBox lstDisplay;
        private System.Windows.Forms.Label lblSourceNode;
        private System.Windows.Forms.ComboBox cmbSourceNode;
        private System.Windows.Forms.Label lblDestinationNode;
        private System.Windows.Forms.ComboBox cmbDestinationNode;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.Panel pnlMap;
    }
}
