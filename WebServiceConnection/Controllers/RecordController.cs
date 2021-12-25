public class RecordController : ApiController
   {
       private ApplicationDbContext _context;
       public RecordController()
       {
           _context = new ApplicationDbContext();
       }
 
       [Authorize]
       [HttpPost]
       public IHttpActionResult Save(Record record)
       {
           if (record == null) return NotFound();
 
           Record newRecord = new Record
           {
               Temp = record.Temp,
               Hum = record.Hum
           };
           _context.Records.Add(newRecord);
           _context.SaveChanges();
           return Ok();
       }
   }
