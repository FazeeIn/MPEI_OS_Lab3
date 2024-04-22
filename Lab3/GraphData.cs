using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.CodeDom;
using System.Drawing;
namespace Lab3
{
    static class GraphData
    {
        public static int[,] graph;

        public static List<List<int>> paths;
        public static List<int> shortestPath;

        public static int? v1, v2;
        public static int? e11, e12, e21, e22;

        public static int startV, endV;

        public delegate void ReRenderMessageHandler();
        public static event ReRenderMessageHandler MessageSent;

        public static void SendReRenderingMessage()
        {
            MessageSent?.Invoke();
        }

        static GraphData()
        {
           paths = new List<List<int>>();
           shortestPath = new List<int>();
           startV = 0;
           endV = 0;
        }

        public static void GraphInit(int m)
        {
            graph = new int[m,m];
        }

        public static void FindPaths() 
        {
            Refresh();
            var startPath = new List<int>() { startV };
            Stack<List<int>> allPaths = new Stack<List<int>>();
            allPaths.Push(startPath);

            while (allPaths.Count > 0)
            {
                var currPath = allPaths.Pop();
                var adjacentVertices = AdjacentVertices(currPath);
                if (adjacentVertices.Count == 0)
                    continue;
                else
                {
                    foreach (var item in adjacentVertices)
                    {
                        if (item == endV)
                        {
                            var copyCurrPath = new List<int>(currPath);
                            copyCurrPath.Add(item);
                            if (CheckPath(copyCurrPath))
                            {
                                if (shortestPath.Count > copyCurrPath.Count || shortestPath.Count == 0)
                                    shortestPath = copyCurrPath;
                                    paths.Add(copyCurrPath);
                                    SendReRenderingMessage();
                                    Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            var copyCurrPath = new List<int>(currPath.ToArray());
                            copyCurrPath.Add(item);
                            allPaths.Push(copyCurrPath); 
                        }
                    }
                }
            }
        }

        public static List<int> AdjacentVertices(List<int> arr)
        {
            var list = new List<int>();
            for (int i = 0; i < graph.GetLength(0); i++)
                if (!arr.Contains(i) && graph[arr[arr.Count-1], i] == 1)
                    list.Add(i);
            return list;
        }

        private static void Refresh()
        {
            paths.Clear();
            if (shortestPath != null) 
                shortestPath.Clear();
        }
        
        public static void RefreshAll()
        {
            paths.Clear();
            if (shortestPath != null)
                shortestPath.Clear();
            graph = null;
            v1 = null;
            v2 = null;
            e11 = null;
            e12 = null;
            e21 = null;
            e22 = null;
            startV = 0;
            endV = 0;
        }

        public static void PaintGraph(Graphics g, int Height, int Width)
        {
            Pen pen = new Pen(Color.Black,3);
            g.Clear(Color.DarkGray);
            ConnectAllVertices(g, Height, Width, pen);

            pen.Color = Color.Red;
            if (paths.Count > 0)
                PrintPath(g, Height, Width, pen, paths[paths.Count-1]);

            pen.Color = Color.LimeGreen;
            if (shortestPath.Count > 1)
            PrintPath(g,Height, Width, pen, shortestPath);

            pen.Color = Color.Black;
            DrawVertices(g, Height, Width);    
        }

        public static void DrawVertices(Graphics g, int Height, int Width)
        {
            int cx = Width / 2;
            int cy = Height / 2;
            int radius = 350;
            int n = GraphData.graph.GetLength(0);
            double angle = 2 * Math.PI / n;
            int circleDiam = 30;

            Pen pen = new Pen(Color.Black, 3);
            Brush EllipseBrush = new SolidBrush(Color.LightGray);
            Brush StringBrush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat() { 
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center 
            };

            Font font = new Font("Arial", 20, FontStyle.Regular);


            for (int i = 0; i < n; i++)
            {
                var x = (int)(cx + radius * Math.Cos(angle * i));
                var y = (int)(cy - radius * Math.Sin(angle * i));
                var rect = new Rectangle(x + circleDiam
                    , y - circleDiam
                    , circleDiam
                    , circleDiam);
                g.DrawEllipse(pen, rect);
                g.FillEllipse(EllipseBrush, rect);
                g.DrawString(i.ToString(), font, StringBrush, rect, format);
            }
        }

        public static void ConnectVertices(Graphics g, int Height, int Width, int first, int second, Pen pen)
        {
            int cx = Width / 2;
            int cy = Height / 2;
            int radius = 350;
            int n = GraphData.graph.GetLength(0);
            double angle = 2 * Math.PI / n;
            g.DrawLine(pen
                ,cx + (int)(radius * Math.Cos(first * angle)) + 45
                , cy - (int)(radius * Math.Sin(first * angle)) - 15
                , cx + (int)(radius * Math.Cos(second * angle)) + 45
                , cy - (int)(radius * Math.Sin(second * angle)) - 15);
        }

        public static void ConnectAllVertices(Graphics g, int Height, int Width, Pen pen)
        {
            int n = GraphData.graph.GetLength(0);
       
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    if (graph[i, j] == 1)
                        ConnectVertices(g, Height, Width, i, j, pen);
        }

        public static bool CheckPath(List<int> path)
        {
            if (!(path.Contains(v1.Value) || path.Contains(v2.Value)))
            {
                for (int i = 0; i < path.Count - 1; i++)
                    if ((path[i] == e11 && path[i + 1] == e12)
                        || path[i] == e21 && path[i + 1] == e22)
                        return false;
                return true;
            }

            return false;
        }

        public  static void PrintPath(Graphics g, int Height, int Width, Pen pen, List<int> path)
        {
            for (int i = 0; i < path.Count-1; i++)
                ConnectVertices(g, Height, Width, path[i], path[i+1],pen);
        }
    }
}
