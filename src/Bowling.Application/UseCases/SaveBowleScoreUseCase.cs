using Bowling.Application.Services;
using Bowling.Domain.Entities;

namespace Bowling.Application.UseCases
{
    internal class SaveBowlerScoreUseCase : IRequestHandler<Score, bool>
    {
        private readonly IFileService _fileService;

        public SaveBowlerScoreUseCase(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool Handle(Score data)
        {
            _fileService.Write(data.Value);

            return true;
        }
    }
}
