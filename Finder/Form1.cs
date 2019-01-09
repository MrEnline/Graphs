using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labels = new List<Label>();
            graphics = panel.CreateGraphics();                  //создание графики на панели
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Graph graph;
        List<Label> labels;
        Graphics graphics;
        int size = 8;

        //метод, которым управляет класс Graph через delegate в зависимости от цвета
        //данный метод устанавливает цвет метке
        public void SetColorLabel(int number, Graph.Color color)
        {
            Color setColor = this.BackColor;
            switch (color)
            {
                case Graph.Color.White: setColor = Color.White;
                    break;
                case Graph.Color.Red: setColor = Color.Red;
                    break;
                case Graph.Color.Black: setColor = Color.Black;
                    break;
                default:
                    break;
            }
            labels[number].BackColor = setColor;
            panel.Refresh();
            ConnectLabels();                        //соединяем линии
            Thread.Sleep(1500);                     //задержка на смену цвета на панели
        }

        #region LabelsGraph
        //создаем граф
        //
        private void CreateGraph1()
        {
            labels.Clear();
            panel.Controls.Clear();
            panel.Refresh();

            graph = new Graph(SetColorLabel);

            //добавляем вершины графа
            for (int i = 0; i < 13; i++)
            {
                graph.AddVertex(i);
            }

            //добавляем ребра графа
            graph.AddRib(0, 1);
            graph.AddRib(1, 2);
            graph.AddRib(2, 3);
            graph.AddRib(3, 4);
            graph.AddRib(4, 1);

            graph.AddRib(1, 6);
            graph.AddRib(6, 7);
            graph.AddRib(7, 8);
            graph.AddRib(8, 9);
            graph.AddRib(9, 10);
            graph.AddRib(10, 11);
            graph.AddRib(11, 12);
            graph.AddRib(12, 5);
            graph.AddRib(5, 1);
        }

        private void AddLabel(int number, int x, int y)
        {
            Label label = new Label();
            label.Text = number.ToString();
            label.Location = new Point(x, y);                   //класс положения метки (класс координат)   
            label.Size = new Size(30, 20);                      //размеры метки
            label.BorderStyle = BorderStyle.Fixed3D;
            label.TextAlign = ContentAlignment.MiddleCenter;    //выравнивание по центру метки текста
            label.ForeColor = Color.White;                      //цвет текста метки
            label.BackColor = Color.DarkGreen;                  //цвет фона метки
            Controls.Add(label);
            panel.Controls.Add(label);
            labels.Add(label);
        }

        public void ShowGraphLabels1()
        {
            AddLabel(0, 211, 500);
            AddLabel(1, 352, 384);
            AddLabel(2, 474, 274);
            AddLabel(3, 489, 459);
            AddLabel(4, 303, 542);
            AddLabel(5, 190, 385);
            AddLabel(6, 305, 224);
            AddLabel(7, 442, 91);
            AddLabel(8, 637, 353);
            AddLabel(9, 450, 629);
            AddLabel(10, 115, 581);
            AddLabel(11, 74, 267);
            AddLabel(12, 215, 87);
            ConnectLabels();
        }

        //соединяем вершины линиями между собой
        private void ConnectLabels()
        {
            foreach (int a in graph.AllTops())
                foreach (int b in graph.AllAdjacmentTop(a))
                    Connect(a, b);
        }

        private void Connect(int a, int b)
        {
            graphics.DrawLine(new Pen(Color.Red), CenterOf(labels[a]), CenterOf(labels[b]));
        }

        //возвращает координаты середины текущей метки
        private Point CenterOf(Label label)
        {
            return new Point(
                label.Location.X + label.Width / 2,
                label.Location.Y + label.Height / 2);
        }
        #endregion

        #region Chess board
        public void CreateGraph2()
        {
            labels.Clear();
            panel.Controls.Clear();
            panel.Refresh();

            graph = new Graph(SetColorLabel);               //при создании класса передаем метод делегату
            //создаем список вершин
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    graph.AddVertex(x + y * size);

            //создаем список ребер
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    for (int s = 0; s < 4; s++)
                    {
                        int nr = GetGraphRibs(x, y, s);                  //соседняя вершина для искомой
                        if (nr >= 0)
                            graph.AddRib(x + y * size, nr);
                    }
                }
            }
        }

        //метод возвращает смежную вершину для исходной
        private int GetGraphRibs(int x, int y, int step)
        {
            switch (step)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }

            if (x >= 0 && x < size && y >= 0 && y < size)
                return x + y * size;
            return -1;
        }

        private void ShowGraphLabels2()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    AddLabel(x + y * size, 40 + x * 80, 40 + y * 80);
                }
            }
            //соединим между собой метки
            ConnectLabels();
        }

        #endregion


        #region ButtonClickEvents
        private void button1_Click(object sender, EventArgs e)
        {
            CreateGraph1();
            ShowGraphLabels1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateGraph2();
            ShowGraphLabels2();
        }

        private void SearchInBreadth_Click(object sender, EventArgs e)
        {
            SearchInBreadth searchInBreadth = new SearchInBreadth(graph);
            searchInBreadth.ToSearchWay(0);
        }

        private void SearchInDeapth_Click(object sender, EventArgs e)
        {
            SearchInDepth searchInDepth = new SearchInDepth(graph);
            searchInDepth.ToSearchWay(0);
        }

        #endregion


    }
}

