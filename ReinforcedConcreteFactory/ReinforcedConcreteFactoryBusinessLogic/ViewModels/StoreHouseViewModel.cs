using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class StoreHouseViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название склада", width: 100)]
        public string StoreHouseName { get; set; }
        [DataMember]
        [Column(title: "ФИО ответственного", width: 100)]
        public string NameOfResponsiblePerson { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100, format:"dd/MM/yyyy")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> StoreHouseMaterials { get; set; }
    }
}
