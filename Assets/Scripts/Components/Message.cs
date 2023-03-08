using Assets.Scripts.Entities;

namespace Assets.Scripts.Components
{
    public class Message : YComponent
    {
        public Entity Sender { get; private set; }
        public Entity Recipient { get; private set; }
        public string MessageType { get; private set; }
        public object Data { get; private set; }

        public Message(Entity sender, Entity recipient, string messageType, object data)
        {
            Sender = sender;
            Recipient = recipient;
            MessageType = messageType;
            Data = data;
        }
    }
}