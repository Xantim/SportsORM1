using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;


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
            List<Team> ATLTeams = _context.Teams
                .Include(o => o.CurrLeague)
                .Where(o => o.CurrLeague.Name.Contains("Atlantic Soccer"))
                .ToList();
                ViewBag.ATLTeams = ATLTeams;
            
            List<Player> BostonPlayers = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.Location.Contains("Boston"))
                .ToList();
                ViewBag.BostonPlayers = BostonPlayers;
            
            List<Player> CurrBasePlayers = _context.Players
                .Include(q => q.CurrentTeam)
                .Include(r => r.CurrentTeam.CurrLeague)
                .Where(q => q.CurrentTeam.CurrLeague.Sport.Contains("Baseball"))
                .Where(q => q.CurrentTeam.CurrLeague.Name.Contains("International Collegiate"))
                .ToList();
                ViewBag.CurrBasePlayers = CurrBasePlayers;

            List<Player> CurrFootLopezPlayers = _context.Players
                .Include(s => s.CurrentTeam)
                .Include(s => s.CurrentTeam.CurrLeague)
                .Where(s => s.CurrentTeam.CurrLeague.Sport == "Football")
                .Where(s => s.LastName == "Lopez")
                .ToList();
                ViewBag.CurrFootLopezPlayers = CurrFootLopezPlayers;

            List<Player> FootballPlayers = _context.Players
                .Include(t => t.CurrentTeam)
                .Include(t => t.CurrentTeam.CurrLeague)
                .Where(t => t.CurrentTeam.CurrLeague.Sport == "Football")
                .ToList();
                ViewBag.FootballPlayers = FootballPlayers;    

            // List<Team> SophiaPlayerTeams = _context.Teams
            //     .Include(u => u.CurrentPlayers)
            //     // .ThenInclude(v => v.FirstName)
            //     .Where(u => u.CurrentPlayers.FirstName == "Sophia")
            //     .ToList();
            //     ViewBag.SophiaPlayerTeams = SophiaPlayerTeams;

            // List<League> SophiaPlayerLeagues = _context.Leagues
            // .Include(v => v.Teams)
            // // .Include(v => v.CurrentPlayers)
            // .Where(v => v.CurrentPlayers.FirstName =="Sophia")
            // .ToList();
            // ViewBag.SophiaPlayerLeagues;

            List<Player> FloresNonRough = _context.Players
                .Include(w => w.CurrentTeam)
                .Where(w => w.CurrentTeam.TeamName != "Roughriders")
                .Where(w => w.LastName == "Flores")
                .ToList();
                ViewBag.FloresNonRough = FloresNonRough;


            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}