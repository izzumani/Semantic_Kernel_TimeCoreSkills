using Semantic_Kernel_CoreSkills;
#pragma warning disable SKEXP0050
using Microsoft.SemanticKernel;

using Microsoft.SemanticKernel.Plugins.Core;

public class Program

{
    private static Kernel _kernel;
    public static void Main(string[] args)
    {
        var (apiKey, orgId) = Settings.LoadFromSecrets();
        var builder = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion("gpt-3.5-turbo", apiKey, orgId, serviceId: "gpt35");

        builder.Plugins.AddFromType<TimePlugin>(pluginName: "time");

        _kernel =  builder.Build();
        InvokeTimePlugin();
        Console.ReadLine();
    }

    public static async void InvokeTimePlugin()
    {
        const string promptTemplate = @"
            Today is: {{time.date}}
            Current time is: {{time.time}}
            Answer to the following questions using JSON syntax, including the data used.
            Is it morning, afternoon, evening, or night (morning/afternoon/evening/night)?
            Is it weekend time (weekend/not weekend)?
";
        var results = await _kernel.InvokePromptAsync(promptTemplate);
        Console.WriteLine(results);
    }
}
