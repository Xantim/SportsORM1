using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeague = _context.Leagues.Where(a => a.Name.Contains("Womens"));
            ViewBag.HockeyLeague = _context.Leagues.Where(b => b.Sport.Contains("Hockey"));
            ViewBag.NonFootballLeague = _context.Leagues.Where(c => c.Sport != ("Football"));
            ViewBag.ConferenceLeague = _context.Leagues.Where(d => d.Name.Contains("Conference"));
            ViewBag.AtlanticLeague = _context.Leagues.Where(e => e.Name.Contains("Atlantic"));
            ViewBag.DallasTeams = _context.Teams.Where(f => f.Location == "Dallas");
            ViewBag.RaptorTeams = _context.Teams.Where(g => g.TeamName.Contains("Raptors"));
            ViewBag.CityTeams = _context.Teams.Where(h => h.Location.Contains("City"));
            ViewBag.TTeams = _context.Teams.Where(i => i.TeamName.Substring(0,1) == "T");
            ViewBag.AlphaSortTeams = _context.Teams.OrderBy(j => j.Location);
            ViewBag.DescSortTeams = _context.Teams.OrderByDescending(k => k.Location);
            ViewBag.CooperPlayers = _context.Players.Where(l => l.LastName.Contains("Cooper"));

            // ViewBag.AlphaSortTeams = Player.Join(Team,
            // Player => Player[0],
            // Team => Team[0],
            // (Player,Team) =>
            // {
            //     return Team + " " + Player;
            // });
            
            ViewBag.JoshuaPlayers = _context.Players.Where(m => m.FirstName.Contains("Joshua"));
            ViewBag.CooperNotJoshuaPlayers = _context.Players.Where(l => l.LastName.Contains("Cooper") && ! l.FirstName.Contains("Joshua"));
            ViewBag.AlexanderOrWyattPlayers = _context.Players.Where(n => n.FirstName.Contains("Alexander") || n.FirstName.Contains("Wyatt"));


            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}