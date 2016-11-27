using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   public static class AStar {
      private static Tile[,] Nodes { get { return MapManager.Instance.Map; } }

      public static event ChangeLists OnChangeLists = (ol, cl, p) => { };

      public delegate void ChangeLists(HashSet<Tile> openList, HashSet<Tile> closedList, Stack<Tile> finalPath);

      public static Stack<Tile> GetPath(Point start, Point goal, Func<Tile, bool> walkable) {

         var finalPath = new Stack<Tile>();
         var openList = new HashSet<Tile>();
         var closedList = new HashSet<Tile>();

         var startNode = Nodes[start.R, start.C];
         var goalNode = Nodes[goal.R, goal.C];

         int colsCnt = MapManager.Instance.Cols;
         int rowsCnt = MapManager.Instance.Rows;

         var currentNode = startNode;
         currentNode.EmptyValues();
         goalNode.EmptyValues();

         openList.Add(currentNode);

         while (openList.Any()) {
            for (int xdelta = -1; xdelta <= 1; xdelta++)
               for (int ydelta = -1; ydelta <= 1; ydelta++) {
                  if (xdelta == 0 && ydelta == 0)
                     continue;

                  int newx = (int)currentNode.Position.R + xdelta;
                  int newy = (int)currentNode.Position.C + ydelta;

                  if (newx < 0 || newy < 0 || newx >= colsCnt || newy >= rowsCnt)
                     continue;

                  var neighbor = Nodes[newx, newy];
                  if (!walkable(neighbor))
                     continue;

                  var gCost = 0;
                  if (xdelta == 0 || ydelta == 0)
                     gCost = 10;
                  else if (!IsConnectedDiagonally(neighbor, currentNode, walkable))
                     continue;
                  else
                     gCost = 14;

                  if (openList.Contains(neighbor)) {
                     if (neighbor.Parent.G > currentNode.G)
                        neighbor.SetValues(currentNode, goalNode, gCost);
                  }
                  else if (!closedList.Contains(neighbor)) {
                     openList.Add(neighbor);
                     neighbor.SetValues(currentNode, goalNode, gCost);
                  }
               }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (openList.Any())
               currentNode = openList.BestBy((x1, x2) => x1.F < x2.F);

            if (currentNode == goalNode)
               break;
         }

         if (currentNode == goalNode)
            while (currentNode != null && currentNode != startNode) {
               finalPath.Push(currentNode);
               currentNode = currentNode.Parent;
            }

         OnChangeLists(openList, closedList, finalPath);

         return finalPath;
      }

      private static bool IsConnectedDiagonally(Tile node1, Tile node2, Func<Tile, bool> walkable) {
         if (!walkable(Nodes[(int)node1.Position.R, (int)node2.Position.C]))
            return false;
         if (!walkable(Nodes[(int)node2.Position.R, (int)node1.Position.C]))
            return false;

         return true;
      }

      public static T BestBy<T>(this HashSet<T> hashSet, Func<T, T, bool> FirstIsBest) {
         T best = default(T);

         if (hashSet == null || hashSet.Count == 0)
            return best;

         best = hashSet.FirstOrDefault();
         foreach (var elem in hashSet)
            if (FirstIsBest(elem, best))
               best = elem;

         return best;
      }
   }
