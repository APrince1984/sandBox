using System.Linq;
using System.Messaging;
using NUnit.Framework;
using Utilities.MSMQ;

namespace Utilities.Tests.MSMQ
{
    [TestFixture]
    public class MsmqConfiguratorTests
    {
        [Test]
        public void MsmqConfigurator_QueueNameGiven_CreatesQueueIfNotExists()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            
            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void DeleteQueue_DeletesTheQueue()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void GetQueuePath_ReturnsTheQueuePath()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            Assert.IsNotNull(queue.GetQueuePath());

            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void SendMessageToQueue_QueueHasMessage()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            var message = RandomUtil.GetRandomString(100);
            queue.SendMessageToQueue(message);
            var messagesOnQueue = queue.GetMessagesFromQueue();
            Assert.IsNotNull(messagesOnQueue);
            Assert.IsTrue(messagesOnQueue.Any());
            Assert.AreEqual(1, messagesOnQueue.Count());
            Assert.AreEqual(message, messagesOnQueue[0].Body.ToString());

            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void GetMessagesFromQueue_NoMessages_ReturnsNothing()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            var messagesOnQueue = queue.GetMessagesFromQueue();
            Assert.IsTrue(!messagesOnQueue.Any());

            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void GetMessagesFromQueue_QueueHasMessages_ReturnsAllMessages()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            var numberOfMessages = SendRandomMessagesToQueue(queue);

            var messagesOnQueue = queue.GetMessagesFromQueue();
            Assert.AreEqual(numberOfMessages, messagesOnQueue.Count());

            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        [Test]
        public void PurgeQueue_RemovesAllMessagesFromQueue()
        {
            var queue = CreateAndTestMsmQueueWithQueueName();
            SendRandomMessagesToQueue(queue);
            queue.PurgeQueue();
            Assert.IsTrue(!queue.GetMessagesFromQueue().Any());

            // CleanUp
            DeleteAndTestMsmQueue(queue);
        }

        private static MsmqConfigurator CreateAndTestMsmQueueWithQueueName()
        {
            var queue = new MsmqConfigurator(RandomUtil.GetRandomString());
            Assert.IsTrue(MessageQueue.Exists(queue.GetQueuePath()));
            return queue;
        }

        private static void DeleteAndTestMsmQueue(MsmqConfigurator queue)
        {
            queue.DeleteQueue();
            Assert.IsTrue(!MessageQueue.Exists(queue.GetQueuePath()));
        }

        private static int SendRandomMessagesToQueue(MsmqConfigurator queue)
        {
            var numberOfMessages = RandomUtil.GetRandomNumber(2);
            for (var i = 0; i < numberOfMessages; i++)
                queue.SendMessageToQueue(RandomUtil.GetRandomString(50));

            return numberOfMessages;
        }
    }
}
