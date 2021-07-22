using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wildlife.Models;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace wildlife.Controllers
{
    public class CertificateDetailsController : Controller
    {
        private readonly WildLifeDemoContext _context;
        private IHostingEnvironment Environment;
        public CertificateDetailsController(WildLifeDemoContext context, IHostingEnvironment _environment)
        {
            _context = context;
            Environment = _environment;
        }

        // GET: CertificateDetails
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CertificateDetails.ToListAsync());
        }
         
        public async Task<IActionResult> ReexportFaunadownload( )
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "csf");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            var path1 = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot/csf", "Re-exportFauna.xlsx");

            string _filePath = path + "/Re-exportFauna.xlsx";

            var memory = new MemoryStream();
            //using (var stream = new FileStream(path, FileMode.Open ))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path)); 

            //return View();
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.ms-excel"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        // GET: CertificateDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateDetail = await _context.CertificateDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificateDetail == null)
            {
                return NotFound();
            }

            return View(certificateDetail);
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateDetail = await _context.CertificateDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificateDetail == null)
            {
                return NotFound();
            }

            return View(certificateDetail);
        }

        // GET: CertificateDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        public string GetIp()
        {
            //string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (string.IsNullOrEmpty(ip))
            //{
            //    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //}

            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            return remoteIpAddress.ToString();
            //string ip = "";//  Request.UserHostAddress; 
            //return ip;
        }


        

        // POST: CertificateDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CertificateDetail certificateDetail)
        {
            if (ModelState.IsValid)
            {
                string ipaddress = GetIp();
                 

                certificateDetail.Recorddate = System.DateTime.Now;
                certificateDetail.UserId ="U001";
                certificateDetail.Ip = ipaddress;
                _context.Add(certificateDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificateDetail);
        }

        // GET: CertificateDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateDetail = await _context.CertificateDetails.FindAsync(id);
            if (certificateDetail == null)
            {
                return NotFound();
            }
            return View(certificateDetail);
        }

        // POST: CertificateDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  CertificateDetail certificateDetail)
        {
            if (id != certificateDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificateDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateDetailExists(certificateDetail.Id))
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
            return View(certificateDetail);
        }

        // GET: CertificateDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateDetail = await _context.CertificateDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificateDetail == null)
            {
                return NotFound();
            }

            return View(certificateDetail);
        }

        // POST: CertificateDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificateDetail = await _context.CertificateDetails.FindAsync(id);
            _context.CertificateDetails.Remove(certificateDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateDetailExists(int id)
        {
            return _context.CertificateDetails.Any(e => e.Id == id);
        }
    }
}
