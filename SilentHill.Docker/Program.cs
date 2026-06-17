var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

Console.WriteLine("===================================");
Console.WriteLine("  Silent Hill - Iniciando via Docker");
Console.WriteLine("===================================");
Console.WriteLine();

var psi = new System.Diagnostics.ProcessStartInfo
{
    FileName = "docker",
    Arguments = "compose up --build",
    UseShellExecute = false,
    RedirectStandardOutput = true,
    RedirectStandardError = true,
};

using var process = new System.Diagnostics.Process { StartInfo = psi };
process.Start();

var tasks = new[]
{
    Task.Run(() =>
    {
        while (!process.StandardOutput.EndOfStream)
        {
            var line = process.StandardOutput.ReadLine();
            if (line is not null) Console.WriteLine(line);
        }
    }),
    Task.Run(() =>
    {
        while (!process.StandardError.EndOfStream)
        {
            var line = process.StandardError.ReadLine();
            if (line is not null) Console.Error.WriteLine(line);
        }
    }),
};

await Task.WhenAny(Task.WhenAll(tasks), Task.Delay(-1, cts.Token));

if (!process.HasExited)
{
    Console.WriteLine("Parando containers...");
    var kill = new System.Diagnostics.Process
    {
        StartInfo = new System.Diagnostics.ProcessStartInfo
        {
            FileName = "docker",
            Arguments = "compose down",
            UseShellExecute = false
        }
    };
    kill.Start();
    kill.WaitForExit();
    process.Kill();
}

process.WaitForExit();
