using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    class SearchInDepth
    {
        Graph graph;
        Stack<int> stack;

        public SearchInDepth(Graph graph)
        {
            this.graph = graph;
            stack = new Stack<int>();
        }
        //метод поиска в глубину
        public void ToSearchWay(int start)
        {
            stack.Push(start);                                          //добавляем первый элемент в Stack
            graph.SetColor(start, Graph.Color.Red);                     //устанавливаем красный цвет для добавленной вершины
            while (stack.Count > 0)
            {
                int top = stack.Pop();                                  //удаляем вершину из стэка
                graph.SetColor(top, Graph.Color.Black);                 //устанавливаем черный цвет для удаляемой вершины
                foreach (int a in graph.AllAdjacmentTop(top))           //проходимся по смежным вершинам
                {
                    if(graph.GetColor(a) == Graph.Color.White)
                    {
                        stack.Push(a);                                  //добавляем смежную вершину в стэк
                        graph.SetColor(a, Graph.Color.Red);
                    }
                }
            }
        }
    }
}
