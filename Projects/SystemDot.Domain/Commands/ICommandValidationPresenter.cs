namespace SystemDot.Domain.Commands
{
    public interface ICommandValidationPresenter<TCommand>
    {
        void Present(CommandValidationState<TCommand> validationState);
    }
}