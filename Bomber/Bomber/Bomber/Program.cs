using Bomber;

var timesToRequest = 30000;

Console.WriteLine("Start " + DateTime.Now);
Bombs.MultipleGetRequests(timesToRequest);
Console.WriteLine("End " + DateTime.Now);