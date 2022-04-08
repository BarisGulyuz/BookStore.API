using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.DTOs.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AuthorCreateDto> _createValidator;
        private readonly IValidator<AuthorUpdateDto> _updateValidator;

        public AuthorManager(IAuthorRepository authorRepository, IMapper mapper, IValidator<AuthorCreateDto> createValidator, IValidator<AuthorUpdateDto> updateValidator)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result> AddAsync(AuthorCreateDto authorCreateDto)
        {
            var result = _createValidator.Validate(authorCreateDto);
            if (result.IsValid)
            {
                var author = _mapper.Map<Author>(authorCreateDto);
                await _authorRepository.AddAsync(author);
                return Result.Success();
            }
            return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
        }

        public async Task<Result> DeleteAsync(int authorId)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == authorId);
            if (author == null) return Result.Failure("There is no data for this query");
            await _authorRepository.DeleteAsync(author);
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
                var result = _updateValidator.Validate(authorUpdateDto);
                if (result.IsValid)
                {
                    var author = _mapper.Map<AuthorUpdateDto, Author>(authorUpdateDto, oldAuthor);
                    await _authorRepository.Update(author);
                    return Result.Success();
                }
                return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
            }
            return Result.Failure("There no data for this query");
        }
    }
}
