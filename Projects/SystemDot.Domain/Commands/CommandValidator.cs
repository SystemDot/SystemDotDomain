using System.Threading.Tasks;
using SystemDot.Domain.Events;

namespace SystemDot.Domain.Commands
{
    public abstract class CommandValidator<TCommand, TValidationFailedEvent> : IAsyncCommandHandler<TCommand>
        where TValidationFailedEvent : ValidationFailed, new()
    {
        readonly IEventBus eventBus;
        readonly IAsyncCommandHandler<TCommand> inner;

        protected CommandValidator(
            IEventBus eventBus, 
            IAsyncCommandHandler<TCommand> inner)
        {
            this.eventBus = eventBus;
            this.inner = inner;
        }

        public async Task Handle(TCommand command)
        {
            ValidationFailed failureEvent = new TValidationFailedEvent();

            await ValidateAsync(command, failureEvent);

            if (failureEvent.IsEmpty())
                await inner.Handle(command);
            else
                eventBus.PublishEvent(failureEvent);
        }

        protected abstract Task ValidateAsync(TCommand command, ValidationFailed failureEvent);
    }

    public abstract class CommandValidator<TCommand> : IAsyncCommandHandler<TCommand>
    {
        private readonly IAsyncCommandHandler<TCommand> inner;
        private readonly ICommandValidationPresenter<TCommand> validationPresenter;

        protected CommandValidator(
            IAsyncCommandHandler<TCommand> inner,
            ICommandValidationPresenter<TCommand> validationPresenter)
        {
            this.inner = inner;
            this.validationPresenter = validationPresenter;
        }

        public async Task Handle(TCommand command)
        {
            var validationState = new CommandValidationState<TCommand>();

            await ValidateAsync(command, validationState);

            if (validationState.IsValid)
            {
                await inner.Handle(command);
            }

            validationPresenter.Present(validationState);
        }

        protected abstract Task ValidateAsync(TCommand command, CommandValidationState<TCommand> validationState);
    }
}