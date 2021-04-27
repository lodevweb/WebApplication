using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrouveTaPizza.Utils;


namespace TrouveTaPizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Pizza);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vmn)
        {
            try
            {
                if (ModelState.IsValid && /*this.ValidateVM(vm)*/vm.Validate(ModelState, FakeDb.Instance.Pizzas))
                {
                    Pizza pizza = vm.Pizza;

                    pizza.Pate = FakeDb.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);

                    pizza.Ingredients = FakeDb.Instance.IngredientsDisponible.Where(
                        x => vm.IdsIngredients.Contains(x.Id))
                        .ToList();

                    pizza.Id = FakeDb.Instance.Pizzas.Count == 0 ? 1 : FakeDb.Instance.Pizzas.Max(x => x.Id) + 1;

                    FakeDb.Instance.Pizzas.Add(pizza);

                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                    vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                        .ToList();

                    return View(vm);
                }
            }
            catch (Exception e)
            {
                vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                    x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                    .ToList();

                return View(vm);
            }
        }


        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
