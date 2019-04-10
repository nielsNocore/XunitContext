﻿using System;
using Xunit;
using Xunit.Abstractions;

public class XunitLoggerSample : 
    IDisposable
{
    [Fact]
    public void Usage()
    {
        XunitLogger.WriteLine("From Test");

        ClassBeingTested.Method();

        var logs = XunitLogger.Logs;

        Assert.Contains("From Test", logs);
        Assert.Contains("From Trace", logs);
        Assert.Contains("From Console", logs);
    }

    public XunitLoggerSample(ITestOutputHelper testOutput)
    {
        XunitLogger.Register(testOutput);
    }

    public void Dispose()
    {
        XunitLogger.Flush();
    }
}