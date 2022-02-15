using System.Collections.Generic;

public class Graph
{
   
    public List<GraphVertex> Vertices { get; }

   
    public Graph()
    {
        Vertices = new List<GraphVertex>();
    }

   
    public void AddVertex(string vertexName)
    {
        Vertices.Add(new GraphVertex(vertexName));
    }

    
    public GraphVertex FindVertex(string vertexName)
    {
        foreach (var v in Vertices)
        {
            if (v.Name.Equals(vertexName))
            {
                return v;
            }
        }

        return null;
    }

   
    public void AddEdge(string vertexFrom, string vertexTo)
    {
        var v1 = FindVertex(vertexFrom);
        var v2 = FindVertex(vertexTo);
        if (v2 != null && v1 != null)
        {
            v1.AddEdge(new GraphEdge(v2));
        }
    }

    public void CteateFromMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            this.AddVertex($"{i}");
        }

        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
                if (matrix[i, j] == 1)
                {
                    this.AddEdge($"{i}", $"{j}");
                }
        }
    }
}