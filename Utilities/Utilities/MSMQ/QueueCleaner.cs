using System;
using System.Messaging;

namespace Utilities.MSMQ
{
    public static class QueueCleaner
    {
        public static void PurgeAllQueues()
        {
            var queues = GetAllQueues();
            foreach (var queue in queues)
                queue.Purge();
        }

        public static void DeleteAllQueues()
        {
            var queues = GetAllQueues();
            foreach (var queue in queues)
                MessageQueue.Delete(queue.Path);
        }

        internal static MessageQueue[] GetAllQueues()
        {
            return MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
        }
    }
}
