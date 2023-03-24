﻿using DevExpress.EasyTest.Framework;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

// To run functional tests for ASP.NET Web Forms and ASP.NET Core Blazor XAF Applications,
// install browser drivers: https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/.
//
// -For Google Chrome: download "chromedriver.exe" from https://chromedriver.chromium.org/downloads.
// -For Microsoft Edge: download "msedgedriver.exe" from https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/.
//
// Selenium requires a path to the downloaded driver. Add a folder with the driver to the system's PATH variable.
//
// Refer to the following article for more information: https://docs.devexpress.com/eXpressAppFramework/403852/

namespace Test23._1.Module.E2E.Tests;

public class Test231Tests : IDisposable {
    const string BlazorAppName = "Test23._1Blazor";
    const string WinAppName = "Test23._1Win";
    const string AppDBName = "Test23._1";
    EasyTestFixtureContext FixtureContext { get; } = new EasyTestFixtureContext();

	public Test231Tests() {
        FixtureContext.RegisterApplications(
            new BlazorApplicationOptions(BlazorAppName, string.Format(@"{0}\..\..\..\..\Test23._1.Blazor.Server", Environment.CurrentDirectory)),
            new WinApplicationOptions(WinAppName, string.Format(@"{0}\..\..\..\..\Test23._1.Win\bin\EasyTest\net6.0-windows\Test23._1.Win.exe", Environment.CurrentDirectory))
        );
        FixtureContext.RegisterDatabases(new DatabaseOptions(AppDBName, "Test23._1EasyTest", server: @"(localdb)\mssqllocaldb"));	           
	}
    public void Dispose() {
        FixtureContext.CloseRunningApplications();
    }
    [Theory]
    [InlineData(BlazorAppName)]
    public void TestBlazorApp(string applicationName) {
        FixtureContext.DropDB(AppDBName);
        var appContext = FixtureContext.CreateApplicationContext(applicationName);
        appContext.RunApplication();
        Assert.True(appContext.Navigate("My Details"));
        Assert.True(appContext.Navigate("Role"));
        Assert.True(appContext.Navigate("Users"));
        Assert.True(appContext.Navigate("Reports.Dashboards"));
        Assert.True(appContext.Navigate("Reports.Reports"));
        Assert.True(appContext.Navigate("State Machine.State Machine"));
    }
    [Theory]
    [InlineData(WinAppName)]
    public void TestWinApp(string applicationName) {
        FixtureContext.DropDB(AppDBName);
        var appContext = FixtureContext.CreateApplicationContext(applicationName);
        appContext.RunApplication();
        Assert.True(appContext.Navigate("My Details"));
        Assert.True(appContext.Navigate("Role"));
        Assert.True(appContext.Navigate("Users"));
        Assert.True(appContext.Navigate("Reports.Dashboards"));
        Assert.True(appContext.Navigate("KPI.Definition"));
        Assert.True(appContext.Navigate("KPI.Scorecard"));
        Assert.True(appContext.Navigate("Reports.Analysis"));
        Assert.True(appContext.Navigate("Reports.Reports"));
        Assert.True(appContext.Navigate("Scheduler Event"));
        Assert.True(appContext.Navigate("State Machine.State Machine"));
    }
}
