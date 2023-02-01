using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
	public class EmpleadoController : Controller
	{
		private readonly DBEmpleadosContext context;

		public EmpleadoController(DBEmpleadosContext context)
		{
			this.context = context;
		}

		//GET /Empleado/Index
		[HttpGet]
		public IActionResult Index()
		{
			var operas = context.Empleados.ToList();
			return View(operas);
		}


		//GET /Empleado/Create
		[HttpGet]
		public ActionResult Create()
		{
			Empleado empleado = new Empleado();
			return View("Create", empleado);
		}

		//POST /Empleado/Create
		[HttpPost]
		public ActionResult Create(Empleado empleado)
		{
			if (ModelState.IsValid)
			{
				context.Empleados.Add(empleado);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(empleado);
		}

		//GET Empleado/Details/{id}
		[HttpGet]
		public ActionResult Details(int id)
		{
			var empleado = TraerUna(id);

			if (empleado == null)
			{
				return NotFound();
			}

			return View("Details", empleado);
		}

		//GET Empelado/GetByName/{name}
		[HttpGet]
		public ActionResult GetByTitulo(string titulo)
		{
			var empleados = (from e in context.Empleados
							 where e.Titulo == titulo
							 select e).ToList();

			if (empleados == null)
			{
				return NotFound();
			}

			return View("GetByName", empleados);
		}

		private Empleado TraerUna(int id)
		{
			return context.Empleados.Find(id);
		}

		//GET Empleado/Edit/{id}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			Empleado empleado = TraerUna(id);

			if (empleado == null) return NotFound();

			return View("Edit", empleado);

		}

		//POST Empleado/Edit
		[HttpPost]
		public ActionResult Edit(Empleado empleado)
		{
			if (empleado == null) return NotFound();

			context.Empleados.Update(empleado);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		//GET Empleado/Delete/{id}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var empleado = TraerUna(id);

			if (empleado == null) return NotFound();

			return View("Delete", empleado);
		}

		//POST Empleado/delete/{id}
		[ActionName("Delete")]
		[HttpPost]
		public ActionResult DeleteConfirmed(int id)
		{
			Empleado empleado = TraerUna(id);

			if (empleado == null) return NotFound();

			context.Empleados.Remove(empleado);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
