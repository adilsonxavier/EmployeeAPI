using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeRegister.Models;

namespace EmployeeRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly EmployeeDBContext _context;

        public SkillsController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        [Route("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkillsEmployee(int id)
        {
            /* return await _context.SkillEmployees
                .Where(x=> x.EmployeeId == id)
                .Select(x =>new SkillEmployee {
                     SkillId = x.SkillId,
                     EmployeeId = x.EmployeeId,
                     SkillName = _context.Skills.FirstOrDefault(s => s.SkillId == x.SkillId).SkillName
                     //SkillName = (from s in _context.Skills where s.SkillId == x.SkillId select s.SkillName).FirstOrDefault()

                  })
                 .ToListAsync();
            */

            return await _context.Skills
                .Select(x => new Skill { 
                    SkillId = x.SkillId,
                    SkillName = x.SkillName,
                   // Checked = _context.SkillEmployees.FirstOrDefault(se => se.EmployeeId == id && se.SkillId == x.SkillId)!= null ? true : false
                    Checked = (from se in _context.SkillEmployees where se.EmployeeId == id && se.SkillId == x.SkillId select se).Any() //? true : false
                })
                
                .ToListAsync();
        }


        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills(int id, Skill skill)
        {
            if (id != skill.SkillId)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutSkillsEmployee(int id,[FromBody] IEnumerable<Skill> skills)
        {
            //Deletar antigos
            var skillsAntigos = _context.SkillEmployees.Where(x => x.EmployeeId == id).ToList();
            if(skillsAntigos != null)
            {
                _context.SkillEmployees.RemoveRange(skillsAntigos);
                
            }

            List<SkillEmployee> skillsNovos = skills.Where(x => x.Checked == true).Select(x => new SkillEmployee()
            {
                EmployeeId = id,
                SkillId = x.SkillId
            }).ToList();

            _context.SkillEmployees.AddRange(skillsNovos);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.SkillId }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}
