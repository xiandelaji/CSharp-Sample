using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MultipleThreads
{
    public class Program
    {
    }
}

// Simple threading scenario: Start a static method running
// on a second thread.
public class ThreadExample
{
    // The ThreadProc method is called when the thread starts.
    // It loops ten times, writing to the console and yielding 
    // the rest of its time slice each time, and then ends.
    public static void Thread1()
    {
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("Thread<<1>>: {0}", i);
            // Yield the rest of the time slice.
            Thread.Sleep(500);
        }
    }

    public static void Thread2()
    {
        
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("Thread<<2>>: {0}", i);
            // Yield the rest of the time slice.
            Thread.Sleep(300);
        }
    }

    public static void Thread3()
    {
        
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("Thread<<3>>: {0}", i);
            // Yield the rest of the time slice.
            Thread.Sleep(100);
        }
    }


    public static void vMain()
    {
        Console.WriteLine("Main thread: Start a second thread.");
        // The constructor for the Thread class requires a ThreadStart 
        // delegate that represents the method to be executed on the 
        // thread. C# simplifies the creation of this delegate.
        Thread t1 = new Thread(new ThreadStart(Thread1));
        // Start ThreadProc. On a uniprocessor, the thread does not get 
        // any processor time until the main thread yields. Uncomment 
        // the Thread.Sleep that follows t.Start() to see the difference.
        t1.Start();
        //Thread.Sleep(0);

        Thread t2 = new Thread(new ThreadStart(Thread2));
        t2.Start();

        Thread t3 = new Thread(new ThreadStart(Thread3));
        t3.Start();
        
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine("Main Thread: {0}", i);
            Thread.Sleep(0);
        }

        Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
        t1.Join();
        t2.Join();
        t3.Join();
        Console.WriteLine("Main thread: ThreadProc.Join has returned. Press Enter to end program.");
        Console.ReadLine();
    }
}
