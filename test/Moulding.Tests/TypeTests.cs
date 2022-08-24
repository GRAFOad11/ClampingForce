namespace Moulding.Tests
{
    public class TypeTests
    { 
        int counter = 0;
        public delegate string WriteMessage(string message);
        [Fact]
        public void WriteMessageDellegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("Hello!");
            Assert.Equal("Hello!", result);
            Assert.Equal(3, counter);
        }
        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }
        string ReturnMessage2(string message)
        {
            counter++;
            return message;
        }

        [Fact]
        public void GetMouldIdReturnsDiffrendObject()
        {
            var mould1 = GetMouldId("Casing");
            var mould2 = GetMouldId("Lens");
            Assert.Equal("Casing", mould1.Mould);
            Assert.Equal("Lens", mould2.Mould);
            Assert.Same(mould1, mould1);
            Assert.NotSame(mould1, mould2);
            Assert.False(Object.ReferenceEquals(mould1, mould2));
            Assert.False(ForceMemory.Equals(mould1, mould2));
        }
        private ForceMemory GetMouldId(string mould)
        {
            return new ForceMemory(mould);
        }
    }
}