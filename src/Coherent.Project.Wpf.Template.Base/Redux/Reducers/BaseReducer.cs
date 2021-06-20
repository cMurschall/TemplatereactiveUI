using System;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers
{
    /// <summary>
    /// Provides base functionality to return an immutable state.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class BaseReducer<TState> where TState : ICloneable
    {
        private readonly object _lock = new();

        /// <summary>
        /// Creates a clone of the current state and applies the provided update action.
        /// The updated action is returned.
        /// </summary>
        /// <param name="previousState">Previous state of the application state</param>
        /// <param name="update">Action to perform in order to update the state</param>
        /// <returns>New instance of the state with updated action applied</returns>
        protected TState UpdateClone(TState previousState, Action<TState> update)
        {
            lock (_lock)
            {
                var result = (TState)previousState.Clone();
                update(result);
                return result;
            }
        }
    }
}