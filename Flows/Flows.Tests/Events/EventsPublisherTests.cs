using Flows.Primitives.Dependencies;
using Flows.Primitives.Events;
using Flows.Tests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace Flows.Tests.Events
{
    public class EventsPublisherTests
    {
        public EventsPublisherTests()
        {
            _handler = new Mock<IEventHandler<FakeEvent>>();            
            _resolver = new Mock<IResolver>();            
            _publisher = new EventPublisher(_resolver.Object);
        }

        private Mock<IEventHandler<FakeEvent>> _handler;        

        private Mock<IResolver> _resolver;
        IEventPublisher _publisher;

        [Fact]
        public async Task ThrowsArgumentNullException() => await Assert.ThrowsAsync<ArgumentNullException>(() => _publisher.PublishAsync(null as IEvent));

        [Fact]
        public async Task PublishAsync()
        {
            _resolver.Setup(x => x.ResolveAll<IEventHandler<FakeEvent>>()).Returns(new List<IEventHandler<FakeEvent>>() { _handler.Object });

            await _publisher.PublishAsync(new FakeEvent());

            _resolver.Verify(r => r.ResolveAll<IEventHandler<FakeEvent>>(), Times.Once);
            _handler.Verify(h => h.HandleAsync(It.IsAny<FakeEvent>()), Times.Once);
        }

        [Fact]
        public async Task PublishManyAsync()
        {
            _resolver.Setup(x => x.ResolveAll<IEventHandler<FakeEvent>>()).Returns(new List<IEventHandler<FakeEvent>>() { _handler.Object });

            await _publisher.PublishAsync(new FakeEvent[] { new FakeEvent() });

            _resolver.Verify(r => r.ResolveAll<IEventHandler<FakeEvent>>(), Times.Once);
            _handler.Verify(h => h.HandleAsync(It.IsAny<FakeEvent>()), Times.Once);
        }
    }
}
