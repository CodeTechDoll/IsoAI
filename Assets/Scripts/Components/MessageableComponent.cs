using Assets.Scripts.Entities;
using Assets.Scripts.Systems;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Components
{
    public class MessageableComponent : YComponent
    {
        [Inject]
        private readonly SystemManager systemManager;

        public virtual IEnumerable<string> GetHandledMessageTypes()
        {
            yield return "ExampleMessageType";
        }

        public MessageSystem GetMessageSystem()
        {
            return systemManager.GetSystem<MessageSystem>();
        }

        public void SendMessage(Entity recipient, string messageType, object data)
        {
            var messageSystem = GetMessageSystem();
            if (messageSystem != null)
            {
                messageSystem.SendMessage(Entity, recipient, messageType, data);
            }
        }

        public virtual void ReceiveMessage(Entity sender, string messageType, object data)
        {
            // Process the message data and perform any necessary actions
        }
    }
}