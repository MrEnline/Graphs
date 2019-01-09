using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    //поиск вширь
    class SearchInBreadth
    {
        Graph graph;
        Queue<int> queue;

        public SearchInBreadth(Graph graph)
        {
            this.graph = graph;
            queue = new Queue<int>();
        }

        //метод нахождения пути
        public void ToSearchWay(int start)
        {
            //устанавливаем белый цвет для всех вершин
            graph.SetColorAllTops(Graph.Color.White);
            queue.Clear();
            queue.Enqueue(start);                                       //добавляем в очередь начальную вершину
            graph.SetColor(start, Graph.Color.Red);                     //устанавливаем красный цвет для добавленной в очередь вершины
            while (queue.Count > 0)
            {
                int a = queue.Dequeue();
                graph.SetColor(a, Graph.Color.Black);                   //устанавливаем черный цвет для удаляемой из очереди вершины
                foreach (int b in graph.AllAdjacmentTop(a))             //проходимся по смежным вершинам для исходной
                {
                    if(graph.GetColor(b) == Graph.Color.White)          //если смежная вершина имеет белый цвет
                    {
                        queue.Enqueue(b);                               //добавляем в очередь
                        graph.SetColor(b, Graph.Color.Red);             //устанавливаем красный цвет для добавленной в очередь вершины
                    }
                }
            }
        }
    }
}
