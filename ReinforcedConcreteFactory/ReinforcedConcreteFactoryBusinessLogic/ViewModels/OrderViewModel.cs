using ReinforcedConcreteFactoryBusinessLogic.Enums;
using System;
using System.Runtime.Serialization;
using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int ReinforcedId { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 100)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 100)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ReinforcedName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }

    }
}
