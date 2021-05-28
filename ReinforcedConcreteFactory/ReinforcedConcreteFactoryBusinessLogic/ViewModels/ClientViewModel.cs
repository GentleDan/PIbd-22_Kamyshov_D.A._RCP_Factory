using System.Runtime.Serialization;
using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}
