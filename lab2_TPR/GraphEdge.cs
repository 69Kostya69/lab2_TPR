/// <summary>
/// Ребро графа
/// </summary>
public class GraphEdge
{
    /// <summary>
    /// Связанная вершина
    /// </summary>
    public GraphVertex ConnectedVertex { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="connectedVertex">Связанная вершина</param>
    public GraphEdge(GraphVertex connectedVertex)
    {
        ConnectedVertex = connectedVertex;
    }
}