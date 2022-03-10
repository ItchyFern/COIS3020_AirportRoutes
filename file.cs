/*
A vertex v in a directed graph G is called a sink if:

- all other vertices of G have an edge that points to v, and
- no vertex in G, including v itself, has an edge that points from v. 
Given the (partial) definition of an adjacency matrix below, complete the C# method Sink which returns true if the given vertex v (name) 
is both found and a sink; false otherwise.  Note that E[i,j] = -1 when the edge from i to j does not exist.  State the worst-case time 
complexity of your Sink method using the big-Oh notation where n is the number of vertices.
*/
class DirectedGraph
{
        public string[ ] V { set; get; }               // Vertex list
        public int[,] E { set; get; }                    // Adjacency matrix
        public int NumVertices { set; get; }
        public int MaxNumVertices { set; get; }
        // FindVertex
        // Returns the index of the given vertex (if found); otherwise returns -1
        private int FindVertex (string name)  { 
            
         }
        public bool Sink (string name)  { 
            // get index
            int index = FindVertex(name);
            // check if vertex exists
            if (index != -1) {
                // cycle through rows
                for (int row = 0; row < E.GetLength(0); row++){
                    // if row is vertex row check that each value is -1
                    if (row == index) {
                        // cycle through columns
                        for (int col = 0; col < E.GetLength(1); col++){
                            // if any edge is coming from this vertex, return false
                            if (E[row, col] != -1){
                                return false;
                            }
                        }
                    } 
                    // if its not the vertex row, check that the row contains a connection to the vertex
                    else {
                        if (E[row, index] == -1){
                            return false;
                        }

                    }
                }
                // if it goes through all the rows without returning false, return true
                return true;
            }
            return false;
        }
}

// Consider the  (partial) definition of a skip list below.  Complete the C# method HeightRatio which returns the 
// ratio of number of nodes in the skip list of height k over the number of nodes in the skip list of height k+1. 
// What would you expect this ratio to be?  Include error checks as part of your answer.
class SkipList
{
    private Node head;
    private int maxHeight;    // Maximum height among non-header nodes
    private class Node {
        public char item;
        public int height;
        public Node[ ] next; 
    }
    public async float HeightRatio (int k) { 
        // k / k+1
        // check if k+1 is outside of max height or k is less than 0
        if (k+1 > maxHeight | k > 0){
            return -1;
        }
        // initialize counters for items at k and k+1
        int kCounter = 0;
        int kPlusOneCounter = 0;
        //loop through all the items at the lowest level and add up occurrences of correct heights
        Node n = head.next[0];
        while (n != null) {
            if (n.height == k){kCounter++;}
            if (n.height == k+1) {kPlusOneCounter++;}
            n = n.next[0];
        }
        // if the divisor is 0 (the count of kPlusOne) then return -1 as an error so no divide by 0 error occurs
        if (kPlusOneCounter == 0) {
            return -1;
        }
        return kCounter/kPlusOneCounter;

    }
}
/*
Suppose each node in a binary tree is augmented with the number of nodes in its right subtree.  
Complete the C# method Size which returns the total number of nodes in the binary tree.   Assume 
the following (partial) definitions for Node and BinaryTree.  Note: Even though the class Node is 
private and nested inside BinaryTree, its data members are available to Size.
*/
class BinaryTree {
    private class Node {
            public float item;
            public int numRight;
            public Node left, right;
    }
    private Node root;
    public int Size ( ) {
        // create counter
        int total_count = 0;
        // create navigating node and set it to root
        Node n = root;
        while (n != null) {
            // add one for the node you just entered
            total_count++;
            // add the right subtree
            total_count += n.numRight;
            // move to left node
            n = n.left;
        }
        return total_count;
    }
}