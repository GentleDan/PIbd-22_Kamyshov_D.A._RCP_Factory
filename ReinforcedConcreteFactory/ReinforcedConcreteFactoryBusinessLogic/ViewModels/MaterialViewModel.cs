using ReinforcedConcreteFactoryBusinessLogic.Attributes;

namespace ReinforcedConcreteFactoryBusinessLogic.ViewModels
{
    public class MaterialViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [Column(title: "Наименование материала", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string MaterialName { get; set; }
    }
}
