using System.Collections.Generic;

public class GraphVertex
{
    public string Name { get; }

    public List<GraphEdge> Edges { get; }

    public GraphVertex(string vertexName)
    {
        Name = vertexName;
        Edges = new List<GraphEdge>();
    }

   
    public void AddEdge(GraphEdge newEdge)
    {
        Edges.Add(newEdge);
    }

    public override string ToString() => Name;
}
