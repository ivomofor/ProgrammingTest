using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProgrammingTest
{
    public class State
    {
        public void StateA()
            {
                 for (int i = 0; i < 10; i++)
                    Console.WriteLine($"Running first Thread: {i}");
            }
        
        public  void StateB()
        {
            for(int i = 0; i < 20; i++)
                Console.WriteLine($"Running ThreadAction2 {i}");
        }


        
    }

    public class Program
    {
        public static void Main()
        {
            //Object reference to ThreadActions method in the ThreadDemo class
            State StateObjA = new State();
            State StateObjB = new State();
            // Delegates to stand in for ThreadActions
            ThreadStart threadStateA = new ThreadStart(StateObjA.StateA);
            ThreadStart threadStateB = new ThreadStart(StateObjB.StateB);

            // Thread to run Delegate event 
            Thread tA = new Thread(threadStateA);
            Thread tB = new Thread(threadStateB);

            // Checking state of thread
            if (tA.ThreadState == ThreadState.Unstarted)
            {
                Console.WriteLine($"tA ThreadState: {tA.ThreadState}");
                tA.Start();
            }
            if(tA.ThreadState == ThreadState.Running)
                Console.WriteLine($"tA ThreadState: {tA.ThreadState}");

            tA.Suspend();
            Console.WriteLine($"tA ThreadState: {tA.ThreadState}");
            
            tB.Start();
            Console.WriteLine($"tB ThreadState: {tA.ThreadState}");

            if (tB.ThreadState == ThreadState.Running)
            {
                Console.WriteLine("Running Thread StateB...............");
                tA.Resume();
                tA.Join(); // executing thread tB to wait until the thread t1 finishes.

            }
            tB.Abort();
            Console.WriteLine($"tB ThreadState: {tB.ThreadState}");
        }
    }
}
