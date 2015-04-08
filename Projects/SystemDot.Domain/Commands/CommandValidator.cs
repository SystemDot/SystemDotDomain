using System.Threading.Tasks;

namespace SystemDot.Domain.Commands
{
    using SystemDot.ThreadMarshalling;

    public abstract class CommandValidator<TCommand> : IAsyncCommandHandler<TCommand>
    {
        private readonly IAsyncCommandHandler<TCommand> inner;
        private readonly ICommandValidationPresenter<TCommand> validationPresenter;
        private readonly IMainThreadMarshaller mainThreadMarshaller;
        
        protected CommandValidator(
            IAsyncCommandHandler<TCommand> inner,
            ICommandValidationPresenter<TCommand> validationPresenter, 
            IMainThreadMarshaller mainThreadMarshaller)
        {
            this.inner = inner;
            this.validationPresenter = validationPresenter;
            this.mainThreadMarshaller = mainThreadMarshaller;
        }

        public async Task Handle(TCommand command)
        {
            var validationState = new CommandValidationState<TCommand>();

            await ValidateAsync(command, validationState);

            if (validationState.IsValid)
            {
                await inner.Handle(command);
            }

            mainThreadMarshaller.RunOnMainThread(() => validationPresenter.Present(validationState));
        }

        protected abstract Task ValidateAsync(TCommand command, CommandValidationState<TCommand> validationState);
    }
}