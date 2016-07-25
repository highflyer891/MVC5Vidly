using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        // GET api/Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies()
        {
          return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET api/Movies/5
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        // POST api/Movies
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + movie.Id.ToString()),movieDto);
        }

        [HttpPut]
        // PUT api/Movies/5
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movie);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        // DELETE api/Movies/5
        public IHttpActionResult DeleteMovie(int id)
        {

            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}