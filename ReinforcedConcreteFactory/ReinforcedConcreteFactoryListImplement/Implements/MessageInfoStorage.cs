using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.Interfaces;
using ReinforcedConcreteFactoryBusinessLogic.ViewModels;
using ReinforcedConcreteFactoryListImplement.Models;
using System;
using System.Collections.Generic;

namespace ReinforcedConcreteFactoryListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;

        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.MessageInfos)
            {
                result.Add(CreateModel(message));
            }
            return result;
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            int toSkip = model.ToSkip ?? 0;
            int toTake = model.ToTake ?? source.MessageInfos.Count;

            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
            {
                foreach (var messageInfo in source.MessageInfos)
                {
                    if (toSkip > 0) { toSkip--; continue; }
                    if (toTake > 0)
                    {
                        result.Add(CreateModel(messageInfo));
                        toTake--;
                    }
                }
                return result;
            }
            foreach (var messageInfo in source.MessageInfos)
            {
                if ((model.ClientId.HasValue && messageInfo.ClientId == model.ClientId) ||
                    (!model.ClientId.HasValue && messageInfo.DateDelivery.Date == model.DateDelivery.Date))
                {
                    if (toSkip > 0) { toSkip--; continue; }
                    if (toTake > 0)
                    {
                        result.Add(CreateModel(messageInfo));
                        toTake--;
                    }
                }
            }
            return result;
        }
            public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            source.MessageInfos.Add(CreateModel(model, new MessageInfo()));
        }
        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            messageInfo.ClientId = model.ClientId;
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.Subject = model.Subject;
            messageInfo.Body = model.Body;
            messageInfo.DateDelivery = model.DateDelivery;
            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                Body = messageInfo.Body,
                DateDelivery = messageInfo.DateDelivery,
                SenderName = messageInfo.SenderName,
                Subject = messageInfo.Subject
            };
        }
    }
}
