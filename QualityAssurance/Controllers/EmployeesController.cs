using System.Threading.Tasks;
using QualityAssurance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualityAssurance.Models;
using QualityAssurance.Models.ModelsView;
using System.Collections.Generic;

namespace QualityAssurance.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employeeView = new EmployeeView()
            {
                //Employee = await _unitOfWork.Employees.GetAllAsync(),
                //Department = await _unitOfWork.Department.GetAllAsync(),
                //Division = await _unitOfWork.Division.GetAllAsync()

                Employee = await _context.Employee.ToListAsync(),
                Department = await  _context.Department.ToListAsync(),
                Division = await _context.Division.ToListAsync()
            };

            return Ok(employeeView);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _unitOfWork.Employees.GetSingleOrDefault(m => m.Eid == id);

            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Eid,EName,Job,Academic,Jurisdiction,Donor,DateOfHiring,DateOfReappiontment")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Eid,EName,Job,Academic,Jurisdiction,Donor,DateOfHiring,DateOfReappiontment")] Employee employee)
        {
            if (id != employee.Eid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Employees.Update(employee);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Eid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.Employees.GetSingleOrDefault(m => m.Eid == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _unitOfWork.Employees.GetSingleOrDefault(m => m.Eid == id);

            _unitOfWork.Employees.Remove(employee);

            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _unitOfWork.Employees.GetAny(e => e.Eid == id);
        }

    }
}
