using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.Author;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorManager(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Result> AddAsync(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            await _authorRepository.AddAsync(author, autoSave: true);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int authorId)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == authorId);
            if (author == null)
            {
                return Result.Failure("There is no data for this query");
            }
            await _authorRepository.DeleteAsync(author, autoSave: true);
            return Result.Success();
        }

        public async Task<DataResult<List<AuthorGetDto>>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync(x => x.Status);
            if (authors.Count > 0)
            {
                var authorsReturn = _mapper.Map<List<AuthorGetDto>>(authors);
                return DataResult<List<AuthorGetDto>>.Success(authorsReturn);
            }
            return DataResult<List<AuthorGetDto>>.Failure("There is no data to return");

        }

        public async Task<DataResult<AuthorGetDto>> GetByIdAsync(int authorId)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == authorId);
            if (author != null)
            {
                var authorReturn = _mapper.Map<AuthorGetDto>(author);
                return DataResult<AuthorGetDto>.Success(authorReturn);
            }
            return DataResult<AuthorGetDto>.Failure("There is no data to return");
        }

        public async Task<Result> UpdateAsync(AuthorUpdateDto authorUpdateDto)
        {
            var oldAuthor = await _authorRepository.GetAsync(x => x.Id == authorUpdateDto.Id);
            if (oldAuthor != null)
            {
                var author = _mapper.Map<AuthorUpdateDto, Author>(authorUpdateDto, oldAuthor);
                await _authorRepository.UpdateAsync(author, autoSave: true);
                return Result.Success();
            }
            return Result.Failure("There no data for this query");
        }
    }
}
