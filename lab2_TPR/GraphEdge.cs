public class GraphEdge
{
    public GraphVertex ConnectedVertex { get; }

    public GraphEdge(GraphVertex connectedVertex)
    {
        ConnectedVertex = connectedVertex;
    }
}