using System;

namespace Test
{
    public abstract class BaseTestFixture : IDisposable
    {
        protected BaseTestFixture()
        {
            PostCodeRecord = new AlgemeneGegevens();
            PcManagerTest = new AlgemeneGegevens();
            DB = new TestDatabase();
        }

        public void Dispose()
        {
            DB.Purge();
        }
        public static TestDatabase DB { get; set; }
        public AlgemeneGegevens PostCodeRecord { get; set; }
        public AlgemeneGegevens PcManagerTest { get; set; }
        public AlgemeneGegevens PcManagerReal { get; set; }
    }
}
