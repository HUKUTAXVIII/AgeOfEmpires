﻿using System;

namespace AgeOfEmpires
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameWindow())
                game.Run();
        }
    }
}
