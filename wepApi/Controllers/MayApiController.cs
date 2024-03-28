using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wepApi.Models;

namespace wepApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MayApiController : ControllerBase
    {


        private  readonly ProductContext _context;

        public MayApiController(ProductContext context)
        {
            _context = context;
        }



        //Veritabanından get ile veri çekelim!
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var providers =await _context._products.ToListAsync();

            if ( providers == null)
            {
                return StatusCode(404, "Maalef içerde veri yok!");
            }

            return Ok(providers);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =await _context._products.FirstOrDefaultAsync(p => p.Id == id);

            if(product == null)
            {
                return StatusCode(402, "402 hata kodu : internetteki bir sunucu başka bir sunucudan geçersiz yanıt aldı.");
            }

            return Ok(product);
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////


        //Veritabanına veri ekleyelim!

        //POST ile eklenildiğini biliyoruz! - Bu işlem KAYDETME VE EKLEME İŞLEMİ YAPMAYA YARAR!
        [HttpPost]
        public async Task<IActionResult> Post(Products entity)
        {
            _context._products.Add(entity);
            await _context.SaveChangesAsync();

            //burası önemli!
            return CreatedAtAction(nameof(GetProduct), new { Id = entity.Id}  , entity);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////


        //Veritabanında ki bir veriyi güncelleyelim!
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Products entity , int? id)
        {
            if ( id != entity.Id)
            {
                return BadRequest();
            }

            var datas = await _context._products.FirstOrDefaultAsync(z => z.Id == id);

            if ( datas == null)
            {
                return NotFound();
            }

            //update satırı
            datas.Id = entity.Id;
            datas.Name = entity.Name;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch(Exception)
            {
                return NotFound();
            }


            //Bu ise 204 durum kodu bastırır ve güncelleme başarılıdır anlamı taşır!
            return NoContent();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////7
        ///



        //Şimdi de Delete işlemi yapacağız!

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            if( id == null) 
            {
                return NotFound();
            }

            var DeleteData = await _context._products.FirstOrDefaultAsync(k => k.Id == id);

            if(DeleteData == null)
            {
                return NotFound();
            }

            //delete satırı
            _context._products.Remove(DeleteData);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch(Exception)
            {
                return NotFound();
            }

            //Aynı mantıkla da burda da NoContent() ile değer döndürmeliyiz!
            //201 durum kodu döndürür!
            return NoContent();
            
        }

        
        


        


    }
}
