using AutoMapper;
using Items.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private IItemsRepository _itemsRepository;
        private IMapper _mapper;

        public ItemController(IItemsRepository itemsRepository, IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }
        // GET: ItemController
        public ActionResult GetAllItems()
        {
            var items = _itemsRepository.GetAllItems();
            return Ok(items);
        }

        public ActionResult GetItem(int id)
        {
            var items = _itemsRepository.GetItemById(id);
            return Ok(items);
        }
    }
}
