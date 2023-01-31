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
		public ActionResult GetByName(string name)
		{
			Empleado empleado = (from e in context.Empleados
								where e.Nombre == name
								select e).SingleOrDefault();

			if (empleado == null)
			{
				return NotFound();
			}

			return View("GetByName", empleado);
		}

		private Empleado TraerUna(int id)
		{
			return context.Empleados.Find(id);
		}
	}
}
