namespace FootBallData.Test.Tables
{
    public class DataTestBase
    {
        public FootBallContext Context { get; }

        public DataTestBase()
        {
            Context = new FootBallContext();
        }

        ~DataTestBase()
        {
            Context.Dispose();
        }
    }
}
