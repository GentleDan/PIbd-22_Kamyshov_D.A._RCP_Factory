using ReinforcedConcreteFactoryBusinessLogic.Enums;
using ReinforcedConcreteFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace ReinforcedConcreteFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string MaterialFileName = "Material.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ReinforcedFileName = "Reinforced.xml";
        private readonly string StoreHouseFileName = "StoreHouse.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessageInfoFileName.xml";
        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<Reinforced> Reinforceds { get; set; }
        public List<StoreHouse> StoreHouses { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }
        private FileDataListSingleton()
        {
            Materials = LoadMaterials();
            Orders = LoadOrders();
            Reinforceds = LoadReinforceds();
            StoreHouses = LoadStoreHouses();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            MessageInfos = LoadMessageInfos();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveMaterials();
            SaveOrders();
            SaveReinforceds();
            SaveStoreHouses();
            SaveClients();
            SaveImplementers();
            SaveMessageInfos();
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
                    });
                }
            }
            return list;
        }
        private List<MessageInfo> LoadMessageInfos()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery")?.Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value,
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }
        private List<Material> LoadMaterials()
        {
            List<Material> list = new List<Material>();
            if (File.Exists(MaterialFileName))
            {
                XDocument xDocument = XDocument.Load(MaterialFileName);
                List<XElement> xElements = xDocument.Root.Elements("Material").ToList();
                foreach (XElement elem in xElements)
                {
                    list.Add(new Material
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MaterialName = elem.Element("MaterialName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            List<Order> list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                List<XElement> xElements = xDocument.Root.Elements("Order").ToList();
                foreach (XElement elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ReinforcedId = Convert.ToInt32(elem.Element("ReinforcedId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }

        private List<StoreHouse> LoadStoreHouses()
        {
            var list = new List<StoreHouse>();

            if (File.Exists(StoreHouseFileName))
            {
                XDocument xDocument = XDocument.Load(StoreHouseFileName);

                var xElements = xDocument.Root.Elements("StoreHouse").ToList();

                foreach (var storehouse in xElements)
                {
                    var sorehouseMaterials = new Dictionary<int, int>();

                    foreach (var material in storehouse.Element("StoreHouseMaterials").Elements("StoreHouseMaterial").ToList())
                    {
                        sorehouseMaterials.Add(Convert.ToInt32(material.Element("Key").Value), Convert.ToInt32(material.Element("Value").Value));
                    }

                    list.Add(new StoreHouse
                    {
                        Id = Convert.ToInt32(storehouse.Attribute("Id").Value),
                        StoreHouseName = storehouse.Element("StoreHouseName").Value,
                        NameOfResponsiblePerson = storehouse.Element("NameOfResponsiblePerson").Value,
                        DateCreate = Convert.ToDateTime(storehouse.Element("DateCreate").Value),
                        StoreHouseMaterials = sorehouseMaterials
                    });
                }
            }

            return list;
        }
        private List<Reinforced> LoadReinforceds()
        {
            List<Reinforced> list = new List<Reinforced>();
            if (File.Exists(ReinforcedFileName))
            {
                XDocument xDocument = XDocument.Load(ReinforcedFileName);
                List<XElement> xElements = xDocument.Root.Elements("Reinforced").ToList();
                foreach (XElement elem in xElements)
                {
                    Dictionary<int, int> reinfMater = new Dictionary<int, int>();
                    foreach (XElement material in
                   elem.Element("ReinforcedMaterials").Elements("ReinforcedMaterial").ToList())
                    {
                        reinfMater.Add(Convert.ToInt32(material.Element("Key").Value),
                       Convert.ToInt32(material.Element("Value").Value));
                    }
                    list.Add(new Reinforced
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ReinforcedName = elem.Element("ReinforcedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        ReinforcedMaterials = reinfMater
                    });
                }
            }
            return list;
        }
        private void SaveMaterials()
        {
            if (Materials != null)
            {
                XElement xElement = new XElement("Materials");
                foreach (Material material in Materials)
                {
                    xElement.Add(new XElement("Material",
                    new XAttribute("Id", material.Id),
                    new XElement("MaterialName", material.MaterialName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MaterialFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                XElement xElement = new XElement("Orders");
                foreach (Order order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ReinforcedId", order.ReinforcedId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveReinforceds()
        {
            if (Reinforceds != null)
            {
                XElement xElement = new XElement("Reinforceds");
                foreach (Reinforced reinforced in Reinforceds)
                {
                    XElement materialElement = new XElement("ReinforcedMaterials");
                    foreach (KeyValuePair<int, int> material in reinforced.ReinforcedMaterials)
                    {
                        materialElement.Add(new XElement("ReinforcedMaterial",
                        new XElement("Key", material.Key),
                        new XElement("Value", material.Value)));
                    }
                    xElement.Add(new XElement("Reinforced",
                     new XAttribute("Id", reinforced.Id),
                     new XElement("ReinforcedName", reinforced.ReinforcedName),
                     new XElement("Price", reinforced.Price),
                     materialElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ReinforcedFileName);
            }
        }

        private void SaveStoreHouses()
        {
            if (StoreHouses != null)
            {
                var xElement = new XElement("StoreHouses");

                foreach (var storehouse in StoreHouses)
                {
                    var materialElement = new XElement("StoreHouseMaterials");

                    foreach (var material in storehouse.StoreHouseMaterials)
                    {
                        materialElement.Add(new XElement("StoreHouseMaterial",
                            new XElement("Key", material.Key),
                            new XElement("Value", material.Value)));
                    }

                    xElement.Add(new XElement("StoreHouse",
                        new XAttribute("Id", storehouse.Id),
                        new XElement("StoreHouseName", storehouse.StoreHouseName),
                        new XElement("NameOfResponsiblePerson", storehouse.NameOfResponsiblePerson),
                        new XElement("DateCreate", storehouse.DateCreate.ToString()),
                        materialElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StoreHouseFileName);
            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveMessageInfos()
        {
            if (MessageInfos != null)
            {
                var xElement = new XElement("MessageInfos");
                foreach (var message in MessageInfos)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("MessageId", message.MessageId),
                    new XElement("ClientId", message.ClientId),
                    new XElement("SenderName", message.SenderName),
                    new XElement("DateDelivery", message.DateDelivery),
                    new XElement("Subject", message.Subject),
                    new XElement("Body", message.Body)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
    }
}
