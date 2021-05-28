using System;
using System.Runtime.Serialization;
using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class MessageInfoViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public string MessageId { get; set; }
        [Column(title: "Отправитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string SenderName { get; set; }
        [Column(title: "Дата письма", width: 150, format:"dd/MM/yyyy")]
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 150)]
        [DataMember]
        public string Subject { get; set; }
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Body { get; set; }

    }
}
