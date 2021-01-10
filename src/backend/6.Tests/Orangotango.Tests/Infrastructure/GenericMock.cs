namespace Orangotango.Tests.Infrastructure
{
    public class GenericMock<TObject, TExpected>
    {
        public TObject Object { get; set; }

        public TExpected Expected { get; set; }
    }
}
