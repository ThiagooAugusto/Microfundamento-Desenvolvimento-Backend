using mf_dev_backend_2023.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace mf_dev_backend_2023.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Relatorio(int? id)
        {
            if(id == null)
                return NotFound();

            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
                return NotFound();

            var consumos = await _context.Consumos.Where(c => c.VeiculoId == id).OrderByDescending(c=>c.Data).ToListAsync();

            decimal total = consumos.Sum(c => c.Valor);

            //A view não recebe mais de uma informação, assim usamos a viewbag. Assim ao criarmos a view podemos recuperar mais de uma
            //informação através de variáveis viewbag

            ViewBag.Total = total;
            ViewBag.Veiculo = veiculo;


            return View(consumos);
        }
    }
}
