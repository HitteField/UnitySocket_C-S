using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/// <summary>
/// 循环触发的定时器
/// </summary>
public class Clocker
{
    private Timer timer;
    private Action clockEvent;

    /// <summary>
    /// 设置定时器的时间间隔
    /// </summary>
    /// <param name="_interval">时间间隔（毫秒）</param>
    public Clocker(int _interval)
    {
        timer = new Timer(Tick, null, 0, _interval);
    }

    private void Tick(object state)
    {
        clockEvent?.Invoke();
    }

    /// <summary>
    /// 添加时钟事件订阅者
    /// </summary>
    /// <param name="clockCallback"></param>
    public void AddListener(Action clockCallback)
    {
        clockEvent += clockCallback;
    }

    /// <summary>
    /// 关闭定时器
    /// </summary>
    public void HaltClocker()
    {
        timer.Dispose();
    }
}

/// <summary>
/// 一次性定时器
/// </summary>
public class DisposableClocker
{
    private Timer timer;
    private Action action;
    /// <summary>
    /// 设置延时调用事件的订阅者
    /// </summary>
    /// <param name="clockCallback">订阅者</param>
    /// <param name="dueTime">延时</param>
    public DisposableClocker(Action clockCallback,int dueTime)
    {
        action = clockCallback;
        timer = new Timer(Tick, null, dueTime, Timeout.Infinite);
    }

    private void Tick(object state)
    {
        action?.Invoke();
        timer.Dispose();
    }
}