using System.IO;
using System.Messaging;

namespace Utilities.MSMQ
{
    public class MsmqConfigurator
    {
        #region Fields

        private readonly MessageQueue _messageQueue;

        #endregion

        #region Constructor

        public MsmqConfigurator(string name)
        {
            var queue = Path.Combine(@".\Private$\", name);
            CreateMessageQueueIfNeeded(Path.Combine(@".\Private$\", name));
            _messageQueue = new MessageQueue(queue)
            {
                Label = name
            };
        }

        #endregion

        #region Public Methods

        public void SendMessageToQueue(string message)
        {
            using (var transaction = new MessageQueueTransaction())
            {
                transaction.Begin();
                _messageQueue.Send(message, transaction);
                transaction.Commit();
            }
        }

        public Message[] GetMessagesFromQueue()
        {
            return _messageQueue.GetAllMessages();
        }

        public void PurgeQueue()
        {
            _messageQueue.Purge();
        }

        public void DeleteQueue()
        {
            MessageQueue.Delete(_messageQueue.Path);
        }

        public string GetQueuePath()
        {
            return _messageQueue.Path;
        }

        #endregion

        #region Private Methods

        private static void CreateMessageQueueIfNeeded(string queue)
        {
            if (!MessageQueue.Exists(queue))
                MessageQueue.Create(queue, true);
        }

        #endregion
    }
}
