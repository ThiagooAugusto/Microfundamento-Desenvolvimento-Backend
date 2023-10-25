using mf_dev_backend_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace mf_dev_backend_2023.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            //injeção de dependencia an ApplicationDbContext instance created for each request
            //and passed to the controller to perform a unit-of-work before being disposed when the request ends.
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }


        //exibe o formulário
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            //verifica se todos campos foram preenchidos
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        //recebe o id da rota do item
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) 
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);
            if(dados == null)
                return NotFound();

            //retorna um formulario para editar os dados
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details (int? id) {

            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);
            if (dados == null)
                return NotFound();

            return View(dados); 
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);
            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);
            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
           await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
