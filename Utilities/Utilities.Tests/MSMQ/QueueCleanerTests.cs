using System.Linq;
using System.Messaging;
using NUnit.Framework;
using Utilities.MSMQ;

namespace Utilities.Tests.MSMQ
{
    [TestFixture]
    public class QueueCleanerTests
    {
        [TearDown]
        public void CleanUp()
        {
            QueueCleaner.DeleteAllQueues();
        }

        [Test]
        public void GetAllQueues_NoQueuesExist_ReturnsEmptyList()
        {
            Assert.IsTrue(!QueueCleaner.GetAllQueues().Any());
        }

        [Test]
        public void GetAllQueues_QueuesExist_ReturnsListOfQueues()
        {
            CreateRandomNumberOfQueues();
            Assert.IsTrue(QueueCleaner.GetAllQueues().Any());
        }

        [Test]
        public void DeleteAllQueues_AllQueuesAreDeleted()
        {
            CreateRandomNumberOfQueues();
            Assert.IsTrue(QueueCleaner.GetAllQueues().Any());
            QueueCleaner.DeleteAllQueues();
            Assert.IsFalse(QueueCleaner.GetAllQueues().Any());
        }

        [Test]
        public void PurgeAllQueues_QueuesArePurged()
        {
            CreateRandomNumberOfQueues();
            Assert.IsTrue(QueueCleaner.GetAllQueues().Any());
            SendRandomMessageToAllQueues();

            QueueCleaner.PurgeAllQueues();

            var queues = QueueCleaner.GetAllQueues();
            foreach (var queue in queues)
                Assert.IsTrue(!queue.GetAllMessages().Any());
        }

        private static void SendRandomMessageToAllQueues()
        {
            foreach (var queue in QueueCleaner.GetAllQueues())
            {
                using (var transaction = new MessageQueueTransaction())
                {
                    transaction.Begin();
                    queue.Send(RandomUtil.GetRandomString(100), transaction);
                    transaction.Commit();
                }
            }
        }

        private static void CreateRandomNumberOfQueues()
        {
            for (int i = 0; i < RandomUtil.GetRandomNumber(2); i++)
                new MsmqConfigurator(RandomUtil.GetRandomString(15));
        }
    }
}
