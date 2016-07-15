using System.Windows.Input;

namespace FJM_XF.ViewModels
{
    public interface ILocationViewModel
    {
        string Title { get; set; }
        string Description { get; }
        double Latitude { get; }
        double Longitude { get; }
        ICommand Command { get; }
    }
}