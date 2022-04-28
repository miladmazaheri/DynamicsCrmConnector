// See https://aka.ms/new-console-template for more information
using DynamicsCrmConnector;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var functions = new CrmScenarios();

await functions.GetAccountNames(10);

Console.ReadKey();