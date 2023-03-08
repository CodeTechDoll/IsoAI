using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using System.Collections.Generic;

namespace Assets.Scripts.Systems
{
    public class MessageSystem : BaseSystem
    {
        private readonly Dictionary<string, List<MessageableComponent>> messageHandlers = new Dictionary<string, List<MessageableComponent>>();
        private readonly Queue<Message> messageQueue = new Queue<Message>();

        public void SendMessage(Entity sender, Entity recipient, string messageType, object data)
        {
            var message = new Message(sender, recipient, messageType, data);
            EnqueueMessage(message);
        }

        protected override bool MatchesEntity(Entity entity)
        {
            return entity.HasComponent<MessageableComponent>();
        }

        protected void EnqueueMessage(Message message)
        {
            messageQueue.Enqueue(message);
        }

        public override void Update()
        {
            while (messageQueue.Count > 0)
            {
                var message = messageQueue.Dequeue();
                if (messageHandlers.TryGetValue(message.MessageType, out var handlers))
                {
                    foreach (var handler in handlers)
                    {
                        handler.ReceiveMessage(message.Sender, message.MessageType, message.Data);
                    }
                }
            }
        }

        protected override void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<MessageableComponent>())
            {
                var component = entity.GetComponent<MessageableComponent>();
                foreach (var messageType in component.GetHandledMessageTypes())
                {
                    if (!messageHandlers.TryGetValue(messageType, out var handlers))
                    {
                        handlers = new List<MessageableComponent>();
                        messageHandlers[messageType] = handlers;
                    }
                    handlers.Add(component);
                }
            }
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            if (entity.HasComponent<MessageableComponent>())
            {
                var component = entity.GetComponent<MessageableComponent>();
                foreach (var messageType in component.GetHandledMessageTypes())
                {
                    if (messageHandlers.TryGetValue(messageType, out var handlers))
                    {
                        _ = handlers.Remove(component);
                    }
                }
            }
        }

        private interface IReceiver
        {
            IEnumerable<string> GetHandledMessageTypes();
        }
    }
}