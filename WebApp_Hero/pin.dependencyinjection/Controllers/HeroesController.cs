using Microsoft.AspNetCore.Mvc;
using pin.dependencyinjection.Interfaces;
using pin.dependencyinjection.Model;

namespace pin.dependencyinjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly ILogger<HeroesController> _logger;

        public HeroesController(ILogger<HeroesController> logger, IHeroVault heroVault)
        {
            _logger = logger;
            HeroVault = heroVault;
        }

        public IHeroVault HeroVault { get; }

        [HttpGet()]
        public IActionResult GetHeroes()
        {
            var heroes = HeroVault.GetHeroes();

            return Ok(heroes);
        }

        [HttpPost("{id_attacker}/attack/{id_defender}")]
        public IActionResult Attack(string id_attacker, string id_defender)
        {
            var attacker = HeroVault.GetHero(id_attacker);
            if(attacker == null) 
            {
                return NotFound(id_attacker);
            }

            var defender = HeroVault.GetHero(id_defender);
            if (defender == null)
            {
                return NotFound(defender);
            }

            try
            {
                var damage = attacker.UseWeapon();

                if (damage == null)
                    return Ok($"{id_attacker} missed {id_defender}");

                var defenderHp = defender.Defend(damage.Value);

                return Ok($"{id_attacker} hit {id_defender} with {damage} damage, {id_defender} has {defenderHp} Hp left");
            }
            catch (DeadHeroException e)
            {
                return Ok(e.Message);
            }
        }
    }
}
