using AutoMapper;
using Flows.Primitives;
using Flows.Primitives.Commands;
using Flows.Primitives.Dependencies;
using Flows.Primitives.Domain;
using Flows.Primitives.Events;
using Flows.Tests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Flows.Tests.Commands
{
    public class CommandTests
    {
        public CommandTests()
        {
            _handler = new Mock<ICommandHandler<FakeCommand>>();
            _resolver = new Mock<IResolver>();
            _publicsher = new Mock<IEventPublisher>();            
            _mapper = new Mock<IMapper>();            
            _store = new Mock<IStorage>();

            _sender = new CommandSender(_resolver.Object, _publicsher.Object, _store.Object, _mapper.Object);
        }

        private ICommandSender _sender;

        private Mock<IResolver> _resolver;
        private Mock<IEventPublisher> _publicsher;
        private Mock<ICommandHandler<FakeCommand>> _handler;
        private Mock<IStorage> _store;
        private Mock<IMapper> _mapper;
        
        [Fact]
        public async Task ThrowsArgumentNullException() => await Assert.ThrowsAsync<ArgumentNullException>(() => _sender.SendAsync<ICommand>(null));

        [Fact]
        public async Task ExecuteAsync()
        {                                   
            _resolver.Setup(x => x.Resolve<ICommandHandler<FakeCommand>>()).Returns(_handler.Object);
            
            await _sender.SendAsync(new FakeCommand()
            {
                UserId = 1,
                AggregateRootId = Guid.NewGuid()
            });

            _handler.Verify(h => h.ExecuteAsync(It.IsAny<FakeCommand>()), Times.Once);
        }

        [Fact]
        public async Task PublishAsync()
        {
            var command = new FakeCommand()
            {
                UserId = 1,
                AggregateRootId = Guid.NewGuid()
            };

            var @event = new FakeEvent();

            _resolver.Setup(x => x.Resolve<ICommandHandler<FakeCommand>>()).Returns(_handler.Object);
            _handler.Setup(h => h.ExecuteAsync(command)).ReturnsAsync(new CommandResponse()
            {
                Events = new List<FakeEvent>() { @event },
                Result = new object()
            });

            _mapper.Setup(m => m.Map(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<Type>())).Returns(@event);

            await _sender.SendAsync(command);

            _publicsher.Verify(p => p.PublishAsync(@event), Times.Once);

            Assert.Equal(command.Id, @event.CommandId);
            Assert.Equal(command.UserId, @event.UserId);
            Assert.Equal(command.AggregateRootId, @event.AggregateRootId);
        }

        [Fact]
        public async Task Storage() {
            var command = new FakeCommand() { 
                UserId = 1,
                AggregateRootId = Guid.NewGuid()
            };
            
            var @event = new FakeEvent();

            _resolver.Setup(x => x.Resolve<ICommandHandler<FakeCommand>>()).Returns(_handler.Object);

            _handler.Setup(h => h.ExecuteAsync(command)).ReturnsAsync(new CommandResponse()
            {
                Events = new List<FakeEvent>() { @event },
                Result = new object()
            });

            _mapper.Setup(m => m.Map(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<Type>())).Returns(@event);

            await _sender.SendAsync(command);

            _store.Verify(p => p.SaveAsync(It.Is<StoreData>(d => d.AggregateRootId == command.AggregateRootId 
                && d.Command == command)), Times.Once);
        }
    }
}
