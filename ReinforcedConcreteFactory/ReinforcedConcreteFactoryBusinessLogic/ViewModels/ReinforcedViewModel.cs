using System.Collections.Generic;
using System.Runtime.Serialization;
using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class ReinforcedViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ReinforcedName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> ReinforcedMaterial { get; set; }
    }
}
