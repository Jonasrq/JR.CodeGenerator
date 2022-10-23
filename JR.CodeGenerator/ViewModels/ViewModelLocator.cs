using Microsoft.Extensions.DependencyInjection;

namespace JR.CodeGenerator.ViewModels;

public class ViewModelLocator
{
    public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
}
