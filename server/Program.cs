using System;
using System.Threading;

namespace Sabotage {
    class Program {
        private static bool isRunning = false;

        static void Main(string[] args) {
            Console.Title = "Sabotage Server";
            isRunning = true;
            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(2, 25565);
        }

        // Execute the main server thread that polls for communications of players
        private static void MainThread() {
            Console.WriteLine("Main thread started at " + Constants.TICKS_PER_SEC + " ticks per second");

            DateTime nextLoop = DateTime.Now;

            while(isRunning) {
                while (nextLoop < DateTime.Now) {
                    GameLogic.Update();

                    nextLoop = nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if(nextLoop > DateTime.Now) {
                        Thread.Sleep(nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}