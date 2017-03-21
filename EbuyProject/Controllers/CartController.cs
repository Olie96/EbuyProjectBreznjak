using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ebuy.Model.Common;
using Ebuy.Service.Common;
using EbuyProject.ViewModels;
using System.Linq;

namespace EbuyProject.Controllers
{
    public class CartController : Controller
    {
        CartViewModel cart;
        UserViewModel user;
        public CartController(ICartService service, IUserService userService)
        {
            this.Service = service;
            this.userService = userService;
            cart = new CartViewModel();
            cart.Books = new List<BookViewModel>();
            cart.Cars = new List<CarViewModel>();
            cart.Musics = new List<MusicViewModel>();
            cart.Sports = new List<SportViewModel>();
            cart.Electronics = new List<ElectronicsViewModel>();
            user = new UserViewModel();

        }
        private readonly ICartService Service;
        private readonly IUserService userService;
        public async Task<ActionResult> Index()
        {  
            ViewBag.Cars = AutoMapper.Mapper.Map<List<CarViewModel>>(await Service.GetAllCarsAsync());
            ViewBag.Books = AutoMapper.Mapper.Map<List<BookViewModel>>(await Service.GetAllBooksAsync());
            ViewBag.Music = AutoMapper.Mapper.Map<List<MusicViewModel>>(await Service.GetAllMusicAsync());
            ViewBag.Sport = AutoMapper.Mapper.Map<List<SportViewModel>>(await Service.GetAllSportAsync());
            ViewBag.Electronic = AutoMapper.Mapper.Map<List<ElectronicsViewModel>>(await Service.GetAllElectronicAsync());
            ViewBag.User = (UserViewModel)Session["userSession"];
            return View(ViewBag);
        }

        //Car
        public async Task<ActionResult> AddCarToCart(int? id)
        {
            var returnedValue = (List<CarViewModel>)Session["carsSession"];
            if (returnedValue != null)
            {
                cart.Cars = (List<CarViewModel>)Session["carsSession"];
            }
            cart.Cars.Add(AutoMapper.Mapper.Map<CarViewModel>(await Service.GetCarAsync(id)));
            Session["carsSession"] = cart.Cars;
            return RedirectToAction("AddedToCart");
        }
        public ActionResult RemoveCarFromCart(int id)
        {
            cart.Cars = (List<CarViewModel>)Session["carsSession"];
            Session["carsSession"] = cart.Cars.Where(c => c.CarId != id).ToList();
            return View("RemovedFromCart");
        }

        //Books
        public async Task<ActionResult> AddBooksToCart(int? id)
        {
            var returnedValue = (List<BookViewModel>)Session["booksSession"];
            if (returnedValue != null)
            {
                cart.Books = (List<BookViewModel>)Session["booksSession"];
            }
            cart.Books.Add(AutoMapper.Mapper.Map<BookViewModel>(await Service.GetBooksAsync(id)));
            Session["booksSession"] = cart.Books;
            return RedirectToAction("AddedToCart");
        }
        public ActionResult RemoveBooksFromCart(int id)
        {
            cart.Books = (List<BookViewModel>)Session["booksSession"];
            Session["booksSession"] = cart.Books.Where(c => c.BookId != id).ToList();
            return View("RemovedFromCart");
        }

        //Music
        public async Task<ActionResult> AddMusicToCart(int? id)
        {
            var returnedValue = (List<MusicViewModel>)Session["musicSession"];
            if (returnedValue != null)
            {
                cart.Musics = (List<MusicViewModel>)Session["musicSession"];
            }
            cart.Musics.Add(AutoMapper.Mapper.Map<MusicViewModel>(await Service.GetMusicAsync(id)));
            Session["musicSession"] = cart.Musics;
            return RedirectToAction("AddedToCart");
        }
        public ActionResult RemoveMusicFromCart(int id)
        {
            cart.Musics = (List<MusicViewModel>)Session["musicSession"];
            Session["musicSession"] = cart.Musics.Where(c => c.MusicPartId != id).ToList();
            return View("RemovedFromCart");
        }

        //Sport
        public async Task<ActionResult> AddSportToCart(int? id)
        {
            var returnedValue = (List<SportViewModel>)Session["sportSession"];
            if (returnedValue != null)
            {
                cart.Sports = (List<SportViewModel>)Session["sportSession"];
            }
            cart.Sports.Add(AutoMapper.Mapper.Map<SportViewModel>(await Service.GetSportAsync(id)));
            Session["sportSession"] = cart.Sports;
            return RedirectToAction("AddedToCart");
        }
        public ActionResult RemoveSportFromCart(int id)
        {
            cart.Sports = (List<SportViewModel>)Session["sportSession"];
            Session["sportSession"] = cart.Sports.Where(c => c.SportItemId != id).ToList();
            return View("RemovedFromCart");
        }

        //Electronics
        public async Task<ActionResult> AddElectronicsToCart(int? id)
        {
            var returnedValue = (List<ElectronicsViewModel>)Session["electronicSession"];
            if (returnedValue != null)
            {
                cart.Electronics = (List<ElectronicsViewModel>)Session["ElectronicSession"];
            }
            cart.Electronics.Add(AutoMapper.Mapper.Map<ElectronicsViewModel>(await Service.GetElectronicAsync(id)));
            Session["ElectronicSession"] = cart.Electronics;
            return RedirectToAction("AddedToCart");
        }
        public ActionResult RemoveElectronicsFromCart(int id)
        {
            cart.Electronics = (List<ElectronicsViewModel>)Session["ElectronicSession"];
            Session["ElectronicSession"] = cart.Electronics.Where(c => c.ElectronicPartId != id).ToList();
            return View("RemovedFromCart");
        }

        //Cart
        public ActionResult AddedToCart()
        {
            return View();
        }
        public ActionResult GetCart()
        {
            cart = new CartViewModel();
            cart.Cars = new List<CarViewModel>();
            cart.Books = new List<BookViewModel>();
            cart.Musics = new List<MusicViewModel>();
            cart.Sports = new List<SportViewModel>();
            cart.Electronics = new List<ElectronicsViewModel>();
            cart.Cars = (List<CarViewModel>)Session["carsSession"];
            cart.Books = (List<BookViewModel>)Session["booksSession"];
            cart.Musics = (List<MusicViewModel>)Session["musicSession"];
            cart.Sports = (List<SportViewModel>)Session["sportSession"];
            cart.Electronics = (List<ElectronicsViewModel>)Session["electronicSession"];
            return View(cart);// gets items from the cart in memory and shows them to the user
        }
        public ActionResult Checkout()
        {
            user = (UserViewModel)Session["userSession"];
            return View(user);
        }
        //[HttpPost, ActionName("Checkout")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckoutConfirmed()
        {
            cart.Cars = (List<CarViewModel>)Session["carsSession"];
            cart.Books = (List<BookViewModel>)Session["booksSession"];
            cart.Musics = (List<MusicViewModel>)Session["musicSession"];
            cart.Sports = (List<SportViewModel>)Session["sportSession"];
            cart.Electronics = (List<ElectronicsViewModel>)Session["electronicSession"];
            user = (UserViewModel)Session["userSession"];
            cart.UserId = user.UserId;
            await Service.AddToCartAsync(AutoMapper.Mapper.Map<ICart>(cart));
            return RedirectToAction("CheckoutConfirmation");
        }
        public ActionResult CheckoutConfirmation()
        {
            return View();
        }

        //Categories
        public async Task<ActionResult> CarsCategory()
        {
            dynamic model = new ExpandoObject();
            model.Cars = AutoMapper.Mapper.Map<List<CarViewModel>>(await Service.GetAllCarsAsync());
            return View(model);
        }
        public async Task<ActionResult> BooksCategory()
        {
            dynamic model = new ExpandoObject();
            model.Books = AutoMapper.Mapper.Map<List<BookViewModel>>(await Service.GetAllBooksAsync());
            return View(model);
        }
        public async Task<ActionResult> ElectronicsCategory()
        {
            dynamic model = new ExpandoObject();
            model.Electronic = AutoMapper.Mapper.Map<List<ElectronicsViewModel>>(await Service.GetAllElectronicAsync());
            return View(model);
        }
        public async Task<ActionResult> SportCategory()
        {
            dynamic model = new ExpandoObject();
            model.Sport = AutoMapper.Mapper.Map<List<SportViewModel>>(await Service.GetAllSportAsync());
            return View(model);
        }
        public async Task<ActionResult> MusicCategory()
        {
            dynamic model = new ExpandoObject();
            model.Music = AutoMapper.Mapper.Map<List<MusicViewModel>>(await Service.GetAllMusicAsync());
            return View(model);
        }
    }
}