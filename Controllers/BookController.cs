using BookList.Data;
using BookList.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMongoCollection<Book>? _books;
        public BookController(MongoDbService mongoDbService)
        {
            _books = mongoDbService.Database?.GetCollection<Book>("book");
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _books.Find(FilterDefinition<Book>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> GetById(string id)
        {
            var filter = Builders<Book>.Filter.Eq(x => x.Id, id);
            var book = _books.Find(filter).FirstOrDefault();
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            await _books?.InsertOneAsync(book);
            return CreatedAtAction(nameof(GetById), new {id = book.Id}, book);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(x => x.Id, book.Id);
            //var update = Builders<Book>.Update
            //    .Set(x => x.Title, book.Title)
            //    .Set(x => x.Author, book.Author);
            //await _books.UpdateOneAsync(filter, update);
            await _books.ReplaceOneAsync(filter, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Book>.Filter.Eq(x=>x.Id, id);
            await _books.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
