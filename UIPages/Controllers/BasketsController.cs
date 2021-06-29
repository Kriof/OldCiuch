using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Models.Api;
using UI.Services;
using UIPages.Data;
using UIPages.Models.Api;
using UIPages.Services;

namespace UIPages.Controllers
{
    public class BasketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBasketService _basketService;
        private readonly IItemsService _itemsService;

        public BasketsController(ApplicationDbContext context, IBasketService basketService,
            IItemsService itemsService)
        { 
            _context = context;
            _basketService = basketService;
            _itemsService = itemsService;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Basket.ToListAsync());
        }

        public async Task<IActionResult> AddToBasket(int itemId)
        {
            var basketId = GetBasketId();
            var item = await _itemsService.GetItem(itemId).ConfigureAwait(false);
            if (item == null)
                throw new Exception("Item does not exist");

            var basket = await _basketService.AddProductToBasket(item, basketId);
            return View(basket);
        }

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cartId = GetBasketId();

            var basket = await _context.Basket
                .FirstOrDefaultAsync(m => m.BasketId == cartId);

            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            return View();
        }
        public string GetBasketId()
        {
            var currentSession = SessionHelper.Get<string>(HttpContext.Session, Constants.Session.Name);
            if (currentSession == null)
            {
                var user = _context.Users.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(user.Email))
                {
                    SessionHelper.Set<string>(HttpContext.Session, Constants.Session.Name, user.Email);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    SessionHelper.Set<string>(HttpContext.Session, Constants.Session.Name, tempCartId.ToString());
                }
            }
            return SessionHelper.Get<string>(HttpContext.Session, Constants.Session.Name);
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasketId,ItemId,ItemName,Count,Price")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            return View(basket);
        }
    }
}
