using Coherent.Project.Wpf.Template.Base.Redux.States;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers
{
    public interface IApplicationReducer
    {
        ApplicationState Reduce(ApplicationState previousState, IAction action);
    }
}