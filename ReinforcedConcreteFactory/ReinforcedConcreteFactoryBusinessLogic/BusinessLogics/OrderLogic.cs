﻿using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.Enums;
using ReinforcedConcreteFactoryBusinessLogic.Interfaces;
using ReinforcedConcreteFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ReinforcedConcreteFactoryBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IReinforcedStorage _reinforcedStorage;
        private readonly IStoreHouseStorage _storeHouseStorage;
        private readonly object locker = new object();
        public OrderLogic(IOrderStorage orderStorage, IReinforcedStorage reinforcedStorage, IStoreHouseStorage storeHouseStorage)
        {
            _orderStorage = orderStorage;
            _reinforcedStorage = reinforcedStorage;
            _storeHouseStorage = storeHouseStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ClientId = model.ClientId,
                ReinforcedId = model.ReinforcedId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id = model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
                {
                    throw new Exception("Заказ еще не принят");
                }
 
                var updateBindingModel = new OrderBindingModel
                {
                    Id = order.Id,
                    ReinforcedId = order.ReinforcedId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    ClientId = order.ClientId
                };

                if (!_storeHouseStorage.TakeFromStoreHouse(_reinforcedStorage.GetElement
                    (new ReinforcedBindingModel { Id = order.ReinforcedId }).ReinforcedMaterial, order.Count))
                {
                    updateBindingModel.Status = OrderStatus.Требуются_материалы;
                }
                else
                {
                    updateBindingModel.DateImplement = DateTime.Now;
                    updateBindingModel.Status = OrderStatus.Выполняется;
                    updateBindingModel.ImplementerId = model.ImplementerId;
                }

                _orderStorage.Update(updateBindingModel);
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ReinforcedId = order.ReinforcedId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ReinforcedId = order.ReinforcedId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
