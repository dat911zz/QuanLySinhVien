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
			Console.BackgroundColor = ConsoleColor.Yellow;
			char x = ' ';
			//Left
            for (int i = 5; i <= 20; i++)
            {
				XY(15, i);
				Console.Write(x);
            }
			//Top
            for (int i = 15; i <= 80; i++)
            {
				XY(i, 5);
				Console.Write(x);
			}
            //Right
            for (int i = 5; i <= 20; i++)
            {
				XY(80, i);
				Console.Write(x);
			}
            //Bot
            for (int i = 15; i <= 80; i++)
            {
				XY(i, 20);
				Console.Write(x);
			}
        }
        public void loading()
        {
			char x = (char)176, z = (char)32;
			int y = 2;
			XY(1, 1);
			
			Console.Write("<!>Processing...");
			
			XY(1, 2);
			Console.Write("[");
			XY(27, 2);
			Console.Write("]");
			XY(2, 2);
			for (int i = 0; i < 25; i++)
			{
				Console.Write("" + x);
			}
            x += (char)2;
			XY(2, 2);
			for (int i = 1; i <= 25; i++)
			{
				//Loading nums
				//BGcolor(14);
				XY(17, 1);
				//cout << i * 4 << "%";
				Console.Write("{0} %", i * 4);
				//Loading
				//BGcolor(15);
				XY(y++, 2);
				//cout << x;
				Console.Write("" + x);
				//Sleep(50);
				Thread.Sleep(50);
			}
			//XY(0, 0);
			//cout << z;
			//XY(1, 1);
			//system("color 0a");
			//cout << "<!>Open file sucessfully!";
			//XY(0, 3);
			//BGcolor(14);
			//cout << "  Redirect in 3 seconds";
			//Sleep(1000);
			//XY(23, 3);
			//cout << ".";
			//Sleep(1000);
			//XY(25, 3);
			//cout << ".";
			//Sleep(1000);
			//XY(27, 3);
			//cout << "." << endl;
		}
        public void XY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
