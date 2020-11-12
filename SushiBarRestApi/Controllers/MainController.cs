using SushiBarBusinessLogic.BindingModels;
using SushiBarBusinessLogic.Interfaces;
using SushiBarBusinessLogic.ViewModels;
using SushiBarRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SushiBarBusinessLogic.BusinessLogic;

namespace SushiBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IDishLogic _dish;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IDishLogic dish, MainLogic main)
        {
            _order = order;
            _dish = dish;
            _main = main;
        }

        [HttpGet]
        public List<Dish> GetDishList() => _dish.Read(null)?.Select(rec =>
        Convert(rec)).ToList();

        [HttpGet]
        public Dish GetDish(int dishId) =>
        Convert(_dish.Read(new DishBindingModel
        { Id = dishId })?[0]);

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) =>
        _order.Read(new OrderBindingModel
        { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
        _main.CreateOrder(model);

        private Dish Convert(DishViewModel model)
        {
            if (model == null) return null;
            return new Dish
            {
                Id = model.Id,
                DishName = model.DishName,
                Price = model.Price
            };
        }
    }
}
