using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ClosestPair
    {
        struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }

        public void Main()
        {
            //var points = new List<Point>
            //{
            //    new Point(2,3),
            //    new Point(3,6),
            //    new Point(6,7),
            //    new Point(6,8),
            //    new Point(7,10),
            //    new Point(7,13),
            //}.ToArray();

            var points = new Point[]
            {
                new Point( 2, 3 ),
                new Point( 12, 30 ),
                new Point( 40, 50 ),
                new Point( 5, 1 ),
                new Point ( 12, 10 ),
                new Point( 3, 4 )
            }.OrderBy(c => c.X).ToArray();
            var midLength = points.Length / 2;
            var left = new Point[midLength];
            var right = new Point[midLength];

            Array.Copy(points, 0, left, 0, midLength);
            Array.Copy(points, midLength, right, 0, right.Length);

            var leftSmallest = FindSmallestDistance(left);
            var rightSmallest = FindSmallestDistance(right);

            double smallest = leftSmallest > rightSmallest ? rightSmallest : leftSmallest;


            var midpoint = points[midLength];

            var closeToMidPoint = new List<Point>();
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i].X <= midpoint.X && points[i].X >= midpoint.X - smallest)
                {
                    closeToMidPoint.Add(left[i]);
                }
            }

            for (int i = 0; i < right.Length; i++)
            {
                if (right[i].X >= midpoint.X && points[i].X <= midpoint.X + smallest)
                {
                    closeToMidPoint.Add(right[i]);
                }
            }

            closeToMidPoint = closeToMidPoint.OrderBy(c => c.Y).ToList();

            double lowestToMidPoint = double.MaxValue;

            var jmax = closeToMidPoint.Count > 7 ? 7 : closeToMidPoint.Count;

            for (int i = 0; i < closeToMidPoint.Count; i++)
            {
                for (int j = i + 1; j < jmax; j++)
                {
                    var dist = CalculateDistanceBetweenPoints(closeToMidPoint[i], closeToMidPoint[j]);

                    if (dist < lowestToMidPoint)
                        lowestToMidPoint = dist;
                }
            }


            Console.WriteLine(lowestToMidPoint + " Lowest to mid");
            Console.WriteLine(smallest + " Smallest");


        }

        private double FindSmallestDistance(Point[] points)
        {
            double min = double.MaxValue;

            if (points.Length > 3)
            {
                var midLength = points.Length / 2;
                var left = new Point[midLength];
                var right = new Point[midLength];

                Array.Copy(points, 0, left, 0, midLength);
                Array.Copy(points, midLength, right, 0, right.Length);

                var leftSmallest = FindSmallestDistance(left);
                var rightSmallest = FindSmallestDistance(right);

                if (leftSmallest < min)
                {
                    min = leftSmallest;
                }

                if (rightSmallest < min)
                {
                    min = rightSmallest;
                }

                return min;
            }

            double distance;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    distance = CalculateDistanceBetweenPoints(points[i], points[j]);
                    if (min > distance)
                    {
                        min = distance;
                    }
                }
            }
            return min;

        }


        private double CalculateDistanceBetweenPoints(Point point1, Point point2)
        {
            var body = Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2);

            return Math.Sqrt(body);
        }
    }
}
