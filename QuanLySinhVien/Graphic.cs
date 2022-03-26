using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QuanLySinhVien
{
    public class Graphic
    {
		public void testCharList()
        {
            for (int i = -254; i < 255; i++)
            {
				Console.WriteLine("{0} - {1}", i, (char)i);
            }
        }
        public void DrawForm()
        {
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			char x = ' ';
			//Left
            for (int i = 5; i <= 20; i++)
            {
				XY(10, i);
				Console.Write(x);
            }
			//Top
            for (int i = 10; i <= 90; i++)
            {
				XY(i, 5);
				Console.Write(x);
			}
            //Right
            for (int i = 5; i <= 20; i++)
            {
				XY(90, i);
				Console.Write(x);
			}
            //Bot
            for (int i = 10; i <= 90; i++)
            {
				XY(i, 20);
				Console.Write(x);
			}
        }
        public void XY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
