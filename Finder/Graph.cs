using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    public class Graph
    {

        #region Fields
        public delegate void Paint(int number, Color color);

        public enum Color
        {
            White,
            Red,
            Black,
            Nullina
        };

        Hashtable tops;                             //вершины
        Dictionary<int, List<int>> ribs;            //ребра
        Paint paint;
        #endregion

        #region Сonstructor
        public Graph(Paint paint)
        {
            tops = new Hashtable();
            ribs = new Dictionary<int, List<int>>();
            this.paint = paint;
        }
        #endregion

        #region ActionsWithTops
        //добавление вершин в коллекцию hashtable
        public void AddVertex(int number, Color color = Color.White)
        {
            tops.Add(number, color);
        }

        //установить цвет для всех вершин
        public void SetColorAllTops(Color color)
        {
            foreach (int item in AllTops())
                SetColor(item, color);
        }

        //изменить или установить цвет
        public void SetColor(int number, Color color)
        {
            //если в таблице вершин уже
            if (!tops.ContainsKey(number))
                return;
            //если такой цвет уже есть, то завершим метод
            if ((Color)tops[number] == color)
                return;
            tops[number] = color;
            paint(number, color);
        }

        //возврат цвета вершины по ключу
        public Color GetColor(int number)
        {
            if (!tops.Contains(number))
                return Color.Nullina;           //если данный ключ отсутствует, то возвращаем пустой цвет из списка
            return (Color)tops[number];
        }

        //получить все вершины
        public IEnumerable<int> AllTops()
        {
            List<int> keys = new List<int>();
            foreach (int item in tops.Keys)
                keys.Add(item);
            foreach (int number in keys)
            {
                yield return number;
            }
        }
        #endregion

        #region ActionsWithRibs

        //а, b - вершины ребра
        //
        public void AddRib(int a, int b)
        {
            //проверка на наличие введенной вершины в списке вершин
            if (!tops.ContainsKey(a)) return;
            if (!tops.ContainsKey(b)) return;
            AddAdjacentTop(a, b);
            AddAdjacentTop(b, a);
        }

        //добавить смежную вершину
        //a - исходная вершина, которая через ребра имеет связь с другими вершинами
        // 1 - 1,2,3,0,5
        // 2 - 4,5,1,0
        // 3 - 8,9,2
        //...
        private void AddAdjacentTop(int a, int b)
        {
            //проверяем наличие ключа(вершины) в Dictionary. И если отсутствует, 
            //то создаем лист соответствия данной вершине смежных вершин, 
            //затем добавляем элемент
            if (!ribs.ContainsKey(a))
                ribs.Add(a, new List<int>());
            //проверяем наличие элемента(смежной вершины для исходной вершины) для ключа в List
            if (!ribs[a].Contains(b))
                ribs[a].Add(b);
        }

        //все смежные вершины
        public IEnumerable<int> AllAdjacmentTop(int number)
        {
            //проверяем наличие ключа в словаре
            if (!ribs.ContainsKey(number))
                yield break;
            //вернет нам список смежных вершин(List) для искомой вершины
            foreach (int item in ribs[number])
                yield return item;
        }

        #endregion
    }
}
