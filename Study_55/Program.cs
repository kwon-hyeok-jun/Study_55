//using System;
//using System.Threading;

///// <summary>
///// 하나의 스레드는 하나의 작업자
///// </summary>
//class ThreadDemo
//{
//    static void Other()
//    {
//        Console.WriteLine("[?] 다른 작업자 일 실행");
//        Thread.Sleep(1000); // 1초 대기(지연)
//        Console.WriteLine("[?] 다른 작업자 일 종료");
//    }

//    static void Main()
//    {
//        Console.WriteLine("[1] 메인 작업자 일 시작");

//        // Thread 클래스와 ThreadStart 대리자로 새로운 스레드 생성
//        var other = new Thread(new ThreadStart(Other));
//        other.Start(); // 새로운 스레드 실행

//        Console.WriteLine("[2] 메인 작업자 일 종료");
//    }
//}


// 프로세스(Process): 하나의 프로그램 단위(프로젝트)
// 스레드(Thread): 프로세스안에서 실행하는 단위 프로그램(메서드)
using System;
using System.Diagnostics;
using System.Threading;

class ThreadPractice
{
    private static void Ide()
    {
        Thread.Sleep(3000); // 3초 딜레이 
        Console.WriteLine("[3] IDE: Visual Studio");
    }

    private static void Sql()
    {
        Thread.Sleep(3000); // 3초 딜레이 
        Console.WriteLine("[2] DBMS: SQL Server");
    }

    private static void Win()
    {
        Thread.Sleep(3000); // 3초 딜레이 
        Console.WriteLine("[1] OS: Windows Server");
    }

    static void Main()
    {
        //[1] 스레드
        ThreadStart ts1 = new ThreadStart(Win);
        ThreadStart ts2 = new ThreadStart(Sql);

        Thread t1 = new Thread(ts1);
        var t2 = new Thread(ts2);
        var t3 = new Thread(new ThreadStart(Ide))
        {
            Priority = ThreadPriority.Highest // 우선순위 높게 
        };

        t1.Start();
        t2.Start();
        t3.Start();

        //[2] 프로세스
        //Process.Start("Chrome.exe"); 
        Process.Start("Notepad.exe");  // 메모장 실행 
    }
}
