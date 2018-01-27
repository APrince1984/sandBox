using System;
using System.Messaging;

namespace Utilities.MSMQ
{
    public static class QueueCleaner
    {
        public static void PurgeAllQueues()
        {
            foreach (var queue in GetAllQueues())
                queue.Purge();
        }

        public static void DeleteAllQueues()
        {
            foreach (var queue in GetAllQueues())
                MessageQueue.Delete(queue.Path);
        }

        internal static MessageQueue[] GetAllQueues()
        {
            return MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
        }
    }
}
