using Flows.Primitives.Dependencies;
using Flows.Primitives.Exceptions;
using Flows.Primitives.Query;
using Flows.Tests.Fakes;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Flows.Tests.Queries
{
    public class QueryProcessorTests
    {
        public QueryProcessorTests()
        {
            _handler = new Mock<IQueryHandler<FakeQuery, object>>();
            _resolver = new Mock<IResolver>();
            _processor = new QueryProcessor(_resolver.Object);
        }

        private Mock<IResolver> _resolver;
        private IQueryProcessor _processor;
        private Mock<IQueryHandler<FakeQuery, object>> _handler;

        [Fact]
        public async Task ThrowsArgumentNullException() => await Assert.ThrowsAsync<ArgumentNullException>(() => _processor.ProcessAync<IQuery<object>, object>(null as IQuery<object>));

        [Fact]
        public async Task ThrowsHandlerNotFoundException() => await Assert.ThrowsAsync<HandlerNotFoundException>(() => _processor.ProcessAync<FakeQuery, object>(new FakeQuery()));

        [Fact]
        public async Task ProcessAync()
        {
            _resolver.Setup(x => x.Resolve<IQueryHandler<FakeQuery, object>>()).Returns(_handler.Object);

            await _processor.ProcessAync<FakeQuery, object>(new FakeQuery());

            _resolver.Verify(r => r.Resolve<IQueryHandler<FakeQuery, object>>(), Times.Once);
            _handler.Verify(h => h.HandleAsync(It.IsAny<FakeQuery>()), Times.Once);
        }
    }
}
