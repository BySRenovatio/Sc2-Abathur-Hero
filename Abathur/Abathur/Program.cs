using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoItX3Lib;

namespace Abathur
{
    class Program
    {
        static public int Xx = 1970;
        static public int Yy = 0;
        static public int mybase = 0;
        static public int gametime = 0;

        static public int playbuttonx = 200;
        static public int playbuttony = 920;
        static public int leavebuttonx = 220;
        static public int leavebuttony = 820;

        static public int z1X = 150;
        static public int z1Y = 900;
        static public int z2X = 120;
        static public int z2Y = 815;
        static public int z3X = 235;
        static public int z3Y = 945;
        static public int z4X = 200;
        static public int z4Y = 855;

        static public int xWorker = 650;
        static public int yWorker = 885;
        static public int xWorkerOff = 55;
        static public int xbRallyOvie = 50;
        static public int ybRallyOvie = 990;

        static public int xb1Roach = 745;
        static public int yb1Roach = 190;
        static public int xb1Evo1 = 970;
        static public int yb1Evo1 = 760;
        static public int xb1Evo2 = 1165;
        static public int yb1Evo2 = 760;
        static public int xb1Gas1 = 590;
        static public int yb1Gas1 = 190;
        static public int xb1Gas2 = 775;
        static public int yb1Gas2 = 820;

        static public int xb2Roach = 320;
        static public int yb2Roach = 445;
        static public int xb2Evo1 = 1225;
        static public int yb2Evo1 = 655;
        static public int xb2Evo2 = 1210;
        static public int yb2Evo2 = 495;
        static public int xb2Gas1 = 500;
        static public int yb2Gas1 = 444;
        static public int xb2Gas2 = 1240;
        static public int yb2Gas2 = 815;

        static public void au3_clickleft(int x, int y)
        {
            AutoItX3 au3 = new AutoItX3();
            au3.MouseClick("left", Xx + x, Yy + y, 1, 0);
            Thread.Sleep(200);
        }

        static public void au3_clickright(int x, int y)
        {
            AutoItX3 au3 = new AutoItX3();
            au3.MouseClick("right", Xx + x, Yy + y, 1, 0);
            Thread.Sleep(200);
        }

        static public long au3_PixelChecksum(int x1, int y1, int x2, int y2)
        {
            long myvalue = 0;

            AutoItX3 au3 = new AutoItX3();
            myvalue = (long)au3.PixelChecksum(Xx + x1, Yy + y1, Xx + x2, Yy + y2);

            Thread.Sleep(200);
            return myvalue;
        }

        static public void au3_MouseDrag(int x1, int y1, int x2, int y2)
        {
            AutoItX3 au3 = new AutoItX3();
            au3.MouseClickDrag("left", Xx + x1, Yy + y1, Xx + x2, Yy + y2, 0);
            Thread.Sleep(300);
        }

        static public void au3_Send(string s)
        {
            AutoItX3 au3 = new AutoItX3();
            au3.Send(s);
            Thread.Sleep(200);
        }

        static public void SayGlHf()
        {
            AutoItX3 au3 = new AutoItX3();

            au3.Send("{ENTER}");
            Thread.Sleep(100);

            au3.Send("Hey (glhf) :)");
            Thread.Sleep(100);

            au3.Send("{ENTER}");
            Thread.Sleep(100);
        }

        static public void Click_Play()
        {
            au3_clickleft(playbuttonx, playbuttony);
            Thread.Sleep(500);
        }

        static public void Click_Leave()
        {
            au3_clickleft(leavebuttonx, leavebuttony);
            Thread.Sleep(2000);
        }

        static public void MoveOvie()
        {
            if (mybase == 1)
            {
                au3_MouseDrag(1010, 155, 1165, 265);
                au3_clickright(xbRallyOvie, ybRallyOvie);
            }

            if (mybase == 2)
            {
                au3_MouseDrag(1015, 100, 1155, 215);
                au3_clickright(xbRallyOvie, ybRallyOvie);
            }

        }

        static public void BuildDrone()
        {
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");
        }

        static public void BuildOvie()
        {
            au3_Send("4");
            au3_Send("s");
            au3_Send("v");
            au3_clickright(xbRallyOvie, ybRallyOvie);
        }

        static public void PopGases()
        {
            au3_Send("4");
            au3_Send("4");

            if (mybase == 1)
                au3_MouseDrag(325, 290, 650, 715);

            if (mybase == 2)
                au3_MouseDrag(550, 495, 1100, 760);

            au3_Send("{SHIFTDOWN}");

            for (int i = 1; i <= 16; i++)
                au3_clickleft(xWorker + 6 * xWorkerOff, yWorker);

            au3_Send("{SHIFTUP}");

            if (mybase == 1)
                au3_clickright(xb1Gas1, yb1Gas1);

            if (mybase == 2)
                au3_clickright(xb2Gas1, yb2Gas1);

            au3_Send("{SHIFTDOWN}");

            for (int i = 1; i <= 4; i++)
                au3_clickleft(xWorker + 3 * xWorkerOff, yWorker);

            au3_Send("{SHIFTUP}");

            if (mybase == 1)
                au3_clickright(xb1Gas2, yb1Gas2);

            if (mybase == 2)
                au3_clickright(xb2Gas2, yb2Gas2);
        }

        static public void BuildRoach()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");

            au3_clickleft(650, 880);
            au3_Send("^9");

            Thread.Sleep(12000);

            if (mybase == 1)
            {
                au3_clickright(xb1Roach, yb1Roach);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("r");
                au3_clickleft(xb1Roach, yb1Roach);
            }

            if (mybase == 2)
            {
                au3_clickright(xb2Roach, yb2Roach);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("r");
                au3_clickleft(xb2Roach, yb2Roach);
            }
        }

        static public void BuildGas1()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");

            au3_clickleft(650, 880);
            au3_Send("^9");

            Thread.Sleep(12000);

            if (mybase == 1)
            {
                au3_clickright(xb1Gas1, yb1Gas1);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("e");
                au3_clickleft(xb1Gas1, yb1Gas1);
            }

            if (mybase == 2)
            {
                au3_clickright(xb2Gas1, yb2Gas1);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("e");
                au3_clickleft(xb2Gas1, yb2Gas1);
            }
        }

        static public void BuildGas2()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");

            au3_clickleft(650, 880);
            au3_Send("^9");

            Thread.Sleep(12000);

            if (mybase == 1)
            {
                au3_clickright(xb1Gas2, yb1Gas2);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("e");
                au3_clickleft(xb1Gas2, yb1Gas2);
            }

            if (mybase == 2)
            {
                au3_clickright(xb2Gas2, yb2Gas2);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("e");
                au3_clickleft(xb2Gas2, yb2Gas2);
            }
        }

        static public void BuildEvo1()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");

            au3_clickleft(650, 880);
            au3_Send("^9");

            Thread.Sleep(12000);

            if (mybase == 1)
            {
                au3_clickright(xb1Evo1, yb1Evo1);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("v");
                au3_clickleft(xb1Evo1, yb1Evo1);
                Thread.Sleep(2000);
                au3_clickleft(xb1Evo1, yb1Evo1);
                au3_Send("{SHIFTDOWN}");
                au3_Send("6");
                au3_Send("{SHIFTUP}");
            }

            if (mybase == 2)
            {
                au3_clickright(xb2Evo1, yb2Evo1);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("v");
                au3_clickleft(xb2Evo1, yb2Evo1);
                Thread.Sleep(2000);
                au3_clickleft(xb2Evo1, yb2Evo1);
                au3_Send("{SHIFTDOWN}");
                au3_Send("6");
                au3_Send("{SHIFTUP}");
            }
        }

        static public void BuildEvo2()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("s");
            au3_Send("d");

            au3_clickleft(650, 880);
            au3_Send("^9");

            Thread.Sleep(12000);

            if (mybase == 1)
            {
                au3_clickright(xb1Evo2, yb1Evo2);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("v");
                au3_clickleft(xb1Evo2, yb1Evo2);
                Thread.Sleep(2000);
                au3_clickleft(xb1Evo2, yb1Evo2);
                au3_Send("{SHIFTDOWN}");
                au3_Send("6");
                au3_Send("{SHIFTUP}");
            }

            if (mybase == 2)
            {
                au3_clickright(xb2Evo2, yb2Evo2);
                Thread.Sleep(3000);
                au3_Send("9");
                au3_Send("b");
                au3_Send("v");
                au3_clickleft(xb2Evo2, yb2Evo2);
                Thread.Sleep(2000);
                au3_clickleft(xb2Evo2, yb2Evo2);
                au3_Send("{SHIFTDOWN}");
                au3_Send("6");
                au3_Send("{SHIFTUP}");
            }
        }

        static public void UpgradeLair()
        {
            au3_Send("4");
            au3_Send("4");
            au3_Send("l");
        }

        static public void EvoUpgradeA()
        {
            au3_Send("6");
            au3_Send("a");
        }

        static public void EvoUpgradeC()
        {
            au3_Send("6");
            au3_Send("c");
        }

        static public void EvoUpgrade1()
        {
            au3_Send("6");
            au3_Send("t");
        }

        static public void EvoUpgrade2()
        {
            au3_Send("6");
            au3_Send("i");
        }

        static public void BuildQueens()
        {
            au3_Send("4");
            au3_Send("q");
            au3_Send("q");
        }

        static public void AMove()
        {
            int rX = 0;
            int rY = 0;
            int rr = 0;

            int offX = 0;
            int offY = 0;

            Random r = new Random();

            rX = r.Next(41) - 20;
            rY = r.Next(41) - 20;

            if (gametime < 60)
            {
                offX = 123;
                offY = 930;
            }

            if ((gametime >= 45) && (gametime < 80))
            {
                offX = z1X;
                offY = z1Y;
            }

            if ((gametime >= 80) && (gametime < 150))
            {
                offX = z2X;
                offY = z2Y;
            }

            if ((gametime >= 150) && (gametime < 200))
            {
                offX = z3X;
                offY = z3Y;
            }

            if (gametime >= 200)
            {
                offX = z4X;
                offY = z4Y;
            }

            au3_Send("{F3}");

            au3_Send("{SPACE}");
            au3_Send("{SPACE}");
            au3_Send("a");
            au3_clickleft(rX + offX, rY + offY);

            au3_Send("{F5}");
            au3_clickleft(910 + r.Next(401) - 200, 525 + 25 + r.Next(101));

            rr = r.Next(4);
            if (rr == 1)
            {
                au3_Send("{SPACE}");
                au3_Send("{SPACE}");
                au3_clickright(123, 930);
            }
        }

        static void Main(string[] args)
        {
            int sw = 0;
            long checkmenu = 0;

            while (true)
            {
                Click_Play();

                sw = 0;
                while (sw < 300)
                {
                    checkmenu = au3_PixelChecksum(300, 860, 325, 880);

                    if (checkmenu == 3695203902)
                        Game_Started();

                    Thread.Sleep(1000);
                    sw += 1;
                }

            }
        }

        static public void Game_Started()
        {
            long stillInGame = 0;
            long basePoz1 = 0;
            long basePoz2 = 0;

            SayGlHf();
            gametime = 0;

            while (true)
            {
                stillInGame = au3_PixelChecksum(390, 885, 400, 890);
                basePoz1 = au3_PixelChecksum(82, 933, 83, 934);
                basePoz2 = au3_PixelChecksum(107, 959, 108, 960);

                /// Console.WriteLine(Convert.ToString(stillInGame) + " " + Convert.ToString(basePoz1) + " " + Convert.ToString(basePoz2));

                if ((stillInGame == 12976129) || (basePoz1 == 195822017) || (basePoz2 == 195822017))
                {
                    Console.WriteLine(Convert.ToString(gametime));
                }
                else
                {
                    Thread.Sleep(18000);
                    au3_Send("{s}");
                    Thread.Sleep(18000);
                    Click_Leave();
                    return;
                }

                if (gametime == 0)
                {
                    basePoz1 = au3_PixelChecksum(82, 933, 83, 934);
                    basePoz2 = au3_PixelChecksum(107, 959, 108, 960);

                    if (basePoz1 == 195822017)
                    {
                        mybase = 1;

                        au3_clickleft(1040, 440);

                        au3_Send("^4");

                        au3_Send("4");
                        au3_Send("4");

                        au3_clickright(123, 930);
                    }

                    if (basePoz2 == 195822017)
                    {
                        mybase = 2;

                        au3_clickleft(900, 330);

                        au3_Send("^4");

                        au3_Send("4");
                        au3_Send("4");

                        au3_clickright(123, 930);
                    }

                    au3_clickleft(123, 930);
                    au3_Send("^{F3}");

                    au3_Send("4");
                    au3_Send("4");
                }

                if (gametime == 1)
                {
                    BuildDrone();
                }

                if (gametime == 2)
                    MoveOvie();

                if (gametime == 3)
                {
                    BuildOvie();
                }

                if (gametime == 5)
                {
                    BuildDrone();
                }

                if (gametime == 13)
                {
                    BuildDrone();
                    BuildDrone();
                    BuildDrone();
                    BuildDrone();
                }

                if (gametime == 19)
                {
                    BuildDrone();
                    BuildDrone();
                    BuildDrone();
                }

                if (gametime == 22)
                {
                    BuildGas1();
                    BuildGas2();
                    BuildOvie();
                    BuildOvie();
                    BuildOvie();
                    BuildOvie();
                    PopGases();
                }

                if (gametime == 28)
                {
                    BuildRoach();
                    BuildQueens();
                    BuildEvo1();
                    BuildEvo2();
                    BuildDrone();
                    BuildDrone();
                    BuildDrone();
                }

                if (gametime == 30)
                {
                    UpgradeLair();
                    BuildDrone();
                    BuildDrone();
                    BuildDrone();
                    EvoUpgrade1();
                }

                if (gametime == 40)
                {
                    EvoUpgradeA();
                }

                if (gametime == 60)
                {
                    EvoUpgrade2();
                    EvoUpgradeC();
                }

                if (gametime == 90)
                {
                    EvoUpgradeA();
                }

                if (gametime == 110)
                {
                    EvoUpgradeC();
                }

                if ((gametime >= 60) && (gametime % 10 == 0))
                    BuildQueens();

                if ((gametime >= 40) && (gametime % 20 == 0))
                {
                    au3_Send("{F6}");
                    BuildOvie();
                }
                    
                if (gametime >= 30)
                    AMove();
                else
                    Thread.Sleep(1000);

                gametime += 1;
            }
        }
    }
}
